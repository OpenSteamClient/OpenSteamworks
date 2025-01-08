using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using JetBrains.Annotations;
using OpenSteamClient.Logging;
using OpenSteamworks.Callbacks;
using OpenSteamworks.Callbacks.Structs;
using OpenSteamworks.Data;
using OpenSteamworks.Data.Enums;
using OpenSteamworks.Data.Structs;
using OpenSteamworks.Exceptions;
using OpenSteamworks.Generated;

namespace OpenSteamworks.Helpers;

public sealed class UserHelper : IDisposable
{
    private readonly IClientUser clientUser;
    private readonly IClientUtils clientUtils;
    private readonly ILogger logger;

    private readonly IDisposable cbPostLogonState;
    private readonly IDisposable cbConnectFailure;
    public UserHelper(ISteamClient steamClient, ILoggerFactory loggerFactory)
    {
        this.clientUser = steamClient.IClientUser;
        this.clientUtils = steamClient.IClientUtils;
        
        this.logger = loggerFactory.CreateLogger("UserHelper");

        cbPostLogonState = steamClient.CallbackManager.Register<PostLogonState_t>(OnPostLogonState);
        cbConnectFailure = steamClient.CallbackManager.Register<SteamServerConnectFailure_t>(OnConnectFailure);
    }

    private void OnConnectFailure(ICallbackHandler handler, SteamServerConnectFailure_t cb)
    {
        loginTcs?.SetException(new WrappedEResultException(cb.m_EResult));
    }

    private void OnPostLogonState(ICallbackHandler handler, PostLogonState_t cb)
    {
        if (cb is { hasAppInfo: 1, connectedToCMs: 1 })
        {
            loginTcs?.SetResult();   
        }
    }

    [PublicAPI]
    public void ThrowIfLoggedOut()
    {
        if (!LoggedIn)
            throw new InvalidOperationException("This operation can only be performed when logged in.");
    }
    
    [PublicAPI]
    public IEnumerable<AppId_t> GetSubscribedApps()
    {
        ThrowIfLoggedOut();
        
        int numOwned = clientUser.GetSubscribedApps(null, 0, true);
        AppId_t[] arr = new AppId_t[numOwned];
        int got = clientUser.GetSubscribedApps(arr, arr.Length, true);
        
        //TODO: Could we deal with this better?
        if (numOwned != got)
            throw new APICallException($"GetSubscribedApps return count mismatch; changed from {numOwned} to {got}");

        return arr;
    }

    /// <summary>
    /// Check if the currently logged-in user owns an app.
    /// </summary>
    /// <param name="appid">The appid to check.</param>
    /// <returns>True if the app is owned, false if the app is not owned.</returns>
    [PublicAPI]
    public bool BIsSubscribedApp(AppId_t appid)
    {
        ThrowIfLoggedOut();
        return clientUser.BIsSubscribedApp(appid);
    }
    
    private TaskCompletionSource? loginTcs;
    
    /// <summary>
    /// Logs in with a JWT refresh token, which you can get from the new credentials or QR flow.
    /// </summary>
    /// <remarks>The login APIs are not thread-safe. Remembrance is determined by the token's source, and cannot be set. Extracts the SteamID from the token.</remarks>
    /// <param name="username">The username the token belongs to. A token should always be paired with a username.</param>
    /// <param name="refreshToken">The token to log in with. This must be a REFRESH token and not an AUTH token, even for ephemeral logins.</param>
    /// <returns>A task which will eventually resolve or error.</returns>
    [PublicAPI]
    public async Task LogOn(string username, string refreshToken)
    {
        if (string.IsNullOrEmpty(username))
            throw new ArgumentException("username must not be null.", nameof(username));
        
        if (string.IsNullOrEmpty(refreshToken))
            throw new ArgumentException("refreshToken must not be null.", nameof(refreshToken));
        
        if (loginTcs != null)
            throw new InvalidOperationException("Login is already in progress!");

        if (LoggedIn)
            throw new InvalidOperationException("Already logged in");
        
        var userSteamID = ParseTokenAndGetSteamID(refreshToken);
        clientUser.SetLoginToken(refreshToken, username);
        
        await LogOnInternal(userSteamID);
    }
    
    /// <summary>
    /// Logs in with a username/password combo. You must provide a Steam Guard code if SG is enabled.
    /// This is soft-deprecated in ClientDLL, you should use <see cref="LogOn(string,string)"/> instead.
    /// May sometimes not remember credentials.
    /// </summary>
    /// <param name="steamID">The SteamID of the account being logged in to.</param>
    /// <param name="username"></param>
    /// <param name="password"></param>
    /// <param name="steamGuardCode"></param>
    /// <param name="remember"></param>
    /// <remarks>The login APIs are not thread-safe.</remarks>
    /// <returns>A task which will eventually resolve or error.</returns>
    [PublicAPI]
    public async Task LogOn(CSteamID steamID, string username, string password, string? steamGuardCode, bool remember)
    {
        if (!steamID.IsValid())
            throw new ArgumentException("Login SteamID is invalid.", nameof(steamID));
        
        if (string.IsNullOrEmpty(username))
            throw new ArgumentException("username must not be null.", nameof(username));
        
        if (loginTcs != null)
            throw new InvalidOperationException("Login is already in progress!");
        
        if (LoggedIn)
            throw new InvalidOperationException("Already logged in");
        
        clientUser.SetLoginInformation(username, password, remember);
        if (!string.IsNullOrEmpty(steamGuardCode)) {
            clientUser.SetTwoFactorCode(steamGuardCode);
        }
        
        await LogOnInternal(steamID);
    }
    
    /// <summary>
    /// Logs in with cached credentials.
    /// </summary>
    /// <param name="steamID">The SteamID of the account being logged in to.</param>
    /// <param name="username"></param>
    /// <remarks>The login APIs are not thread-safe.</remarks>
    /// <returns>A task which will eventually resolve or error.</returns>
    [PublicAPI]
    public async Task LogOn(CSteamID steamID, string username)
    {
        if (!steamID.IsValid())
            throw new ArgumentException("Login SteamID is invalid.", nameof(steamID));

        if (!clientUser.BHasCachedCredentials(username))
            throw new WrappedEResultException(EResult.NoMatch);
        
        if (loginTcs != null)
            throw new InvalidOperationException("Login is already in progress!");
        
        if (LoggedIn)
            throw new InvalidOperationException("Already logged in");
        
        clientUser.SetAccountNameForCachedCredentialLogin(username);
        await LogOnInternal(steamID);
    }

    /// <summary>
    /// Logs on to Steam with the "anonymous" account, meant for gameserver usage.
    /// This account's functionality is limited.
    /// </summary>
    /// <remarks>The login APIs are not thread-safe.</remarks>
    /// <returns>A task which will eventually resolve or error.</returns>
    //TODO: What is the AccountID we're meant to use here?
    [PublicAPI]
    public async Task LogOnAnonymous()
        => await LogOn(new(1, EUniverse.Public, EAccountType.AnonUser), "anonymous", "g", null, false);
    
    /// <summary>
    /// Check if the given account name has cached credentials.
    /// </summary>
    [PublicAPI]
    public bool BHasCachedCredentials(string accountName)
        => clientUser.BHasCachedCredentials(accountName);

    private async Task LogOnInternal(CSteamID steamid)
    {
        loginTcs = new();
        
        var startLogonResult = clientUser.LogOn(steamid);
        if (startLogonResult != EResult.OK)
        {
            loginTcs = null;
            throw new WrappedEResultException(startLogonResult);
        }

        await loginTcs.Task;
        loginTcs = null;
    }

    private static CSteamID ParseTokenAndGetSteamID(string token)
    {
        // Parse the JWT (format roughly XXXXXX.XXXXXXXXXXXXXXXXXXXXXXXXXXXX.XXXXXXXXX)
        var splitParts = token.Split('.');
        if (splitParts.Length < 2)
            throw new ArgumentException("Not a valid JWT.", nameof(token));
        
        string payload = splitParts[1];

        // The base64 is not padded properly. Add padding if necessary (FromBase64String is standards-enforcing, meaning it doesn't take in anything but perfect strings)
        switch (payload.Length % 4) // Pad with trailing '='s
        {
            case 0: break; // No pad chars in this case
            case 2: payload += "=="; break; // Two pad chars
            case 3: payload += "="; break; // One pad char
            default: throw new ArgumentException("Illegal JWT payload", nameof(token));
        }

        JsonNode? obj = JsonNode.Parse(Encoding.UTF8.GetString(Convert.FromBase64String(payload)));
        if (obj == null)
            throw new ArgumentException("Failed to parse JWT payload", nameof(token));

        string? steamidStr = (string?)obj["sub"];
        if (string.IsNullOrEmpty(steamidStr))
            throw new ArgumentException("JWT payload does not contain 'subject' field.", nameof(token));
        
        if (!ulong.TryParse(steamidStr, out ulong result))
            throw new ArgumentException("JWT 'subject' field is not a numeric SteamID", nameof(token));

        return new CSteamID(result);
    }

    /// <summary>
    /// Is the current user logged in AND connected to Steam?
    /// </summary>
    [PublicAPI]
    public bool Online
        => clientUser.BConnected() && LoggedIn;

    /// <summary>
    /// Is Steam in offline mode? Does not necessitate a user being logged in.
    /// </summary>
    [PublicAPI]
    public bool Offline
    {
        get => clientUtils.GetOfflineMode();
        set => clientUtils.SetOfflineMode(value);
    }
    
    /// <summary>
    /// Is the current user logged in (potentially in offline mode)
    /// </summary>
    [PublicAPI]
    public bool LoggedIn
        => clientUser.BLoggedOn();

    /// <summary>
    /// Is the current user the "anonymous" user?
    /// </summary>
    [PublicAPI]
    public bool Anonymous
        => SteamID.AccountType == EAccountType.AnonUser;
    
    /// <summary>
    /// The SteamID of the currently logged-in user.
    /// </summary>
    [PublicAPI]
    public CSteamID SteamID 
        => clientUser.GetSteamID();
    
    /// <summary>
    /// The account name of the currently logged-in user.
    /// </summary>
    [PublicAPI]
    public string LoggedInAccountName
    {
        get
        {
            ThrowIfLoggedOut();
            if (!TryGetAccountName(CSteamID.Zero, out var name))
            {
                throw new APICallException("TryGetAccountName for current user failed!");
            }

            return name;
        }
    }
    
    /// <summary>
    /// Try to get the account name for a specified SteamID.
    /// Do not confuse with the username, the account name is used for login purposes only and cannot be changed.
    /// You only have access to locally cached account's account names.
    /// </summary>
    /// <param name="steamid"></param>
    /// <param name="accountName"></param>
    /// <returns></returns>
    [PublicAPI]
    public bool TryGetAccountName(CSteamID steamid, [NotNullWhen(true)] out string? accountName)
    {
        StringBuilder accountNameBuf = new(128);

        var success = steamid == CSteamID.Zero ? clientUser.GetAccountName(accountNameBuf, accountNameBuf.Capacity) : clientUser.GetAccountName(steamid, accountNameBuf, accountNameBuf.Capacity);
        accountName = success ? accountNameBuf.ToString() : null;
        return success;
    }

    public void Dispose()
    {
        loginTcs?.TrySetCanceled();

        cbPostLogonState.Dispose();
        cbConnectFailure.Dispose();
    }
}