using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Runtime.Versioning;
using System.Text;
using Microsoft.Win32;
using OpenSteamClient.Logging;

namespace OpenSteamworks.Utils;

public static class SteamPIDFile
{
    [SupportedOSPlatform("linux")]
    private static bool TryGetPIDFilePath([NotNullWhen(true)] out string? pidFilePath)
    {
        var homevar = Environment.GetEnvironmentVariable("HOME");
        if (string.IsNullOrEmpty(homevar))
        {
            Logging.GeneralLogger.Error("HOME not set");
            pidFilePath = null;
            return false;
        }
            
        pidFilePath = Path.Combine(homevar, ".steam/steam.pid");
        if (!Path.Exists(pidFilePath))
        {
            Logging.GeneralLogger.Error($"steam.pid not found at '{pidFilePath}'");
            pidFilePath = null;
            return false;
        }

        return true;
    }
    
    
    /// <summary>
    /// Get the PID of the currently running Steam instance.
    /// </summary>
    /// <param name="steamPID">The PID of the running Steam process</param>
    /// <returns>True if Steam is running and it's PID was detected successfully.</returns>
    public static bool TryGetGlobalInstancePID(out int steamPID)
    {
        steamPID = 0;
        if (OperatingSystem.IsWindows())
        {
            try
            {
                var pidObj = Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\WOW6432Node\\Valve\\Steam", "SteamPID", 0);
                if (pidObj == null)
                {
                    Logging.GeneralLogger.Error("Registry key missing or not set");
                    return false;
                }
                
                if (pidObj is not int steamPID2)
                {
                    Logging.GeneralLogger.Error($"Registry key of an invalid type {pidObj.GetType().Name}");
                    return false;
                }

                steamPID = steamPID2;
                return true;
            }
            catch (Exception e)
            {
                Logging.GeneralLogger.Error($"Failed to read SteamPID registry key.");
                Logging.GeneralLogger.Error(e);
                return false;
            }
        } else if (OperatingSystem.IsLinux())
        {
            if (!TryGetPIDFilePath(out var path))
            {
                return false;
            }

            var content = File.ReadAllText(path, Encoding.UTF8);
            if (string.IsNullOrEmpty(content))
            {
                Logging.GeneralLogger.Error($"pidfile '{path}' is empty.");
                return false;
            }

            if (!int.TryParse(content, out steamPID))
            {
                Logging.GeneralLogger.Error($"steam.pid contains invalid data: '{steamPID}'");
                return false;
            }
            
            return true;
        }

        return false;
    }

    /// <summary>
    /// Sets the Steam pidfile to the specified value.
    /// This function may throw, unlike TryGetGlobalInstancePID.
    /// </summary>
    public static void SetSteamPID(int steamPID)
    {
        if (OperatingSystem.IsWindows()) {
            //TODO: ValveSteam needs to be installed for this to work. This registry key has special permissions allowing any user to write to it.
            Microsoft.Win32.Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\WOW6432Node\\Valve\\Steam", "SteamPID", steamPID);
        } else if (OperatingSystem.IsLinux())
        {
            if (!TryGetPIDFilePath(out var path))
            {
                throw new Exception("Failed to get path to pidfile.");
            }

            File.WriteAllText(path, steamPID.ToString(), Encoding.UTF8);
        }
    }
}