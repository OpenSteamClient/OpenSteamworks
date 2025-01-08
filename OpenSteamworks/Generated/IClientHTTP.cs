//==========================  AUTO-GENERATED FILE  ================================
//
// This file is partially auto-generated.
// If functions are removed, your changes to that function will be lost.
// Parameter types and names however are preserved if the function stays unchanged.
// Feel free to change parameters to be more accurate. 
//=============================================================================

using System;
using CppSourceGen.Attributes;
using OpenSteamworks.Data;
using OpenSteamworks.Data.Enums;

namespace OpenSteamworks.Generated;

[CppClass]
public unsafe interface IClientHTTP
{
    public HHTTPRequest CreateHTTPRequest(EHTTPMethod eHTTPRequestMethod, string absoluteURL);  // argc: 2, index: 1, ipc args: [bytes4, string], ipc returns: [bytes4]
    public bool SetHTTPRequestContextValue(HHTTPRequest req, ulong ulContextValue);  // argc: 3, index: 2, ipc args: [bytes4, bytes8], ipc returns: [bytes1]
    public bool SetHTTPRequestNetworkActivityTimeout(HHTTPRequest req, uint unTimeoutSeconds);  // argc: 2, index: 3, ipc args: [bytes4, bytes4], ipc returns: [bytes1]
    public bool SetHTTPRequestHeaderValue(HHTTPRequest req, string headerName, string headerValue);  // argc: 3, index: 4, ipc args: [bytes4, string, string], ipc returns: [bytes1]
    public bool SetHTTPRequestGetOrPostParameter(HHTTPRequest req, string paramName, string paramValue);  // argc: 3, index: 5, ipc args: [bytes4, string, string], ipc returns: [bytes1]
    public bool SendHTTPRequest(HHTTPRequest req, out SteamAPICall_t pCallHandle);  // argc: 2, index: 6, ipc args: [bytes4], ipc returns: [bytes1, bytes8]
    public bool SendHTTPRequestAndStreamResponse(HHTTPRequest req, out SteamAPICall_t pCallHandle);  // argc: 2, index: 7, ipc args: [bytes4], ipc returns: [bytes1, bytes8]
    public bool DeferHTTPRequest(HHTTPRequest req);  // argc: 1, index: 8, ipc args: [bytes4], ipc returns: [bytes1]
    public bool PrioritizeHTTPRequest(HHTTPRequest req);  // argc: 1, index: 9, ipc args: [bytes4], ipc returns: [bytes1]
    public bool CancelHTTPRequest(HHTTPRequest req);  // argc: 1, index: 10, ipc args: [bytes4], ipc returns: [bytes1]
    public bool GetHTTPResponseHeaderSize(HHTTPRequest req, string headerName, out UInt32 unResponseHeaderSize);  // argc: 3, index: 11, ipc args: [bytes4, string], ipc returns: [bytes1, bytes4]
    public bool GetHTTPResponseHeaderValue(HHTTPRequest req, string headername, Span<byte> val, uint length);  // argc: 4, index: 12, ipc args: [bytes4, string, bytes4], ipc returns: [bytes1, bytes_length_from_mem]
    public bool GetHTTPResponseBodySize(HHTTPRequest req, out uint len);  // argc: 2, index: 13, ipc args: [bytes4], ipc returns: [bytes1, bytes4]
    public bool GetHTTPResponseBodyData(HHTTPRequest req, Span<byte> val, uint length);  // argc: 3, index: 14, ipc args: [bytes4, bytes4], ipc returns: [bytes1, bytes_length_from_mem]
    public bool GetHTTPStreamingResponseBodyData(HHTTPRequest req, uint cOffset, Span<byte> pBodyDataBuffer, uint unBufferSize);  // argc: 4, index: 15, ipc args: [bytes4, bytes4, bytes4], ipc returns: [bytes1, bytes_length_from_mem]
    public bool ReleaseHTTPRequest(HHTTPRequest req);  // argc: 1, index: 16, ipc args: [bytes4], ipc returns: [bytes1]
    public bool GetHTTPDownloadProgressPct(HHTTPRequest req, out float pflPercentOut);  // argc: 2, index: 17, ipc args: [bytes4], ipc returns: [bytes1, bytes4]
    public bool SetHTTPRequestRawPostBody(HHTTPRequest req, string contentType, ReadOnlySpan<byte> pubBody, uint unBodyLen);  // argc: 4, index: 18, ipc args: [bytes4, string, bytes4, bytes_length_from_mem], ipc returns: [bytes1]
    public HHTTPCookieContainer CreateCookieContainer(bool bAllowResponsesToModify);  // argc: 1, index: 19, ipc args: [bytes1], ipc returns: [bytes4]
    public bool ReleaseCookieContainer(HHTTPCookieContainer hCookieContainer);  // argc: 1, index: 20, ipc args: [bytes4], ipc returns: [bytes1]
    public bool SetCookie(HHTTPCookieContainer hCookieContainer, string host, string url, string cookie);  // argc: 4, index: 21, ipc args: [bytes4, string, string, string], ipc returns: [bytes1]
    public bool SetHTTPRequestCookieContainer(HHTTPRequest req, HHTTPCookieContainer hCookieContainer);  // argc: 2, index: 22, ipc args: [bytes4, bytes4], ipc returns: [bytes1]
    public bool SetHTTPRequestUserAgentInfo(HHTTPRequest req, string userAgentInfo);  // argc: 2, index: 23, ipc args: [bytes4, string], ipc returns: [bytes1]
    public bool SetHTTPRequestRequiresVerifiedCertificate(HHTTPRequest req, bool bRequireVerifiedCertificate);  // argc: 2, index: 24, ipc args: [bytes4, bytes1], ipc returns: [bytes1]
    public bool SetHTTPRequestAbsoluteTimeoutMS(HHTTPRequest req, uint timeoutMS);  // argc: 2, index: 25, ipc args: [bytes4, bytes4], ipc returns: [bytes1]
    public bool GetHTTPRequestWasTimedOut(HHTTPRequest req, out bool bTimedOut);  // argc: 2, index: 26, ipc args: [bytes4], ipc returns: [bytes1, bytes1]
    public bool SetHTTPRequestRedirectsEnabled(HHTTPRequest req, bool bRedirectsEnabled);  // argc: 2, index: 27, ipc args: [bytes4, bytes1], ipc returns: [bytes1]
    public bool SaveHTTPResponseBodyToDisk(HHTTPRequest req, string pszFilename, out SteamAPICall_t pCallHandle);  // argc: 3, index: 28, ipc args: [bytes4, string], ipc returns: [bytes1, bytes8]
}