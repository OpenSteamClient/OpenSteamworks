//==========================  AUTO-GENERATED FILE  ================================
//
// This file is partially auto-generated.
// If functions are removed, your changes to that function will be lost.
// Parameter types and names however are preserved if the function stays unchanged.
// Feel free to change parameters to be more accurate. 
//
//=============================================================================

#pragma once

#include "clienttypes.h"

class IClientHTTP
{
public:
    virtual HTTPRequestHandle CreateHTTPRequest(EHTTPMethod eHTTPRequestMethod, const char *pchAbsoluteURL) = 0; //argc: 2, index 1
    virtual bool SetHTTPRequestContextValue(HTTPRequestHandle hRequest, uint64 ulContextValue) = 0; //argc: 3, index 2
    virtual bool SetHTTPRequestNetworkActivityTimeout(HTTPRequestHandle hRequest, uint32 unTimeoutSeconds) = 0; //argc: 2, index 3
    virtual bool SetHTTPRequestHeaderValue(HTTPRequestHandle hRequest, const char *pchHeaderName, const char *pchHeaderValue) = 0; //argc: 3, index 4
    virtual bool SetHTTPRequestGetOrPostParameter(HTTPRequestHandle hRequest, const char *pchParamName, const char *pchParamValue) = 0; //argc: 3, index 5
    virtual bool SendHTTPRequest(HTTPRequestHandle hRequest, SteamAPICall_t *pCallHandle) = 0; //argc: 2, index 6
    virtual bool SendHTTPRequestAndStreamResponse(HTTPRequestHandle hRequest, SteamAPICall_t *pCallHandle) = 0; //argc: 2, index 7
    virtual bool DeferHTTPRequest(HTTPRequestHandle hRequest) = 0; //argc: 1, index 8
    virtual bool PrioritizeHTTPRequest(HTTPRequestHandle hRequest) = 0; //argc: 1, index 9
    virtual bool CancelHTTPRequest(HTTPRequestHandle hRequest) = 0; //argc: 1, index 10
    virtual bool GetHTTPResponseHeaderSize(HTTPRequestHandle hRequest, const char *pchHeaderName, uint32 *unResponseHeaderSize) = 0; //argc: 3, index 11
    virtual bool GetHTTPResponseHeaderValue(HTTPRequestHandle hRequest, const char *pchHeaderName, uint8 *pHeaderValueBuffer, uint32 unBufferSize) = 0; //argc: 4, index 12
    virtual bool GetHTTPResponseBodySize(HTTPRequestHandle hRequest, uint32 *unBodySize) = 0; //argc: 2, index 13
    virtual bool GetHTTPResponseBodyData(HTTPRequestHandle hRequest, uint8 *pBodyDataBuffer, uint32 unBufferSize) = 0; //argc: 3, index 14
    virtual bool GetHTTPStreamingResponseBodyData(HTTPRequestHandle hRequest, uint32 cOffset, uint8 *pBodyDataBuffer, uint32 unBufferSize) = 0; //argc: 4, index 15
    virtual bool ReleaseHTTPRequest(HTTPRequestHandle hRequest) = 0; //argc: 1, index 16
    virtual bool GetHTTPDownloadProgressPct(HTTPRequestHandle hRequest, float *pflPercentOut) = 0; //argc: 2, index 17
    virtual bool SetHTTPRequestRawPostBody(HTTPRequestHandle hRequest, const char *pchContentType, uint8 *pubBody, uint32 unBodyLen) = 0; //argc: 4, index 18
    virtual HTTPCookieContainerHandle CreateCookieContainer(bool bAllowResponsesToModify) = 0; //argc: 1, index 19
    virtual bool ReleaseCookieContainer(HTTPCookieContainerHandle hCookieContainer) = 0; //argc: 1, index 20
    virtual bool SetCookie(HTTPCookieContainerHandle hCookieContainer, const char *pchHost, const char *pchUrl, const char *pchCookie) = 0; //argc: 4, index 21
    virtual bool SetHTTPRequestCookieContainer(HTTPRequestHandle hRequest, HTTPCookieContainerHandle hCookieContainer) = 0; //argc: 2, index 22
    virtual bool SetHTTPRequestUserAgentInfo(HTTPRequestHandle hRequest, const char *pchUserAgentInfo) = 0; //argc: 2, index 23
    virtual bool SetHTTPRequestRequiresVerifiedCertificate(HTTPRequestHandle hRequest, bool bRequireVerifiedCertificate) = 0; //argc: 2, index 24
    virtual bool SetHTTPRequestAbsoluteTimeoutMS(HTTPRequestHandle hRequest, uint32 unMilliseconds) = 0; //argc: 2, index 25
    virtual bool GetHTTPRequestWasTimedOut(HTTPRequestHandle hRequest, bool *pbWasTimedOut) = 0; //argc: 2, index 26
    virtual bool SetHTTPRequestRedirectsEnabled(HTTPRequestHandle hRequest, bool bRedirectsEnabled) = 0; //argc: 2, index 27
    virtual bool SaveHTTPResponseBodyToDisk(HTTPRequestHandle hRequest, const char *pszFilename, SteamAPICall_t *pCallHandle) = 0; //argc: 3, index 28
};