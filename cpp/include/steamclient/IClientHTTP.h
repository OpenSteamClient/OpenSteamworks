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
    virtual unknown_ret CreateHTTPRequest() = 0; //argc: 2, index 1
    virtual unknown_ret SetHTTPRequestContextValue() = 0; //argc: 3, index 2
    virtual unknown_ret SetHTTPRequestNetworkActivityTimeout() = 0; //argc: 2, index 3
    virtual unknown_ret SetHTTPRequestHeaderValue() = 0; //argc: 3, index 4
    virtual unknown_ret SetHTTPRequestGetOrPostParameter() = 0; //argc: 3, index 5
    virtual unknown_ret SendHTTPRequest() = 0; //argc: 2, index 6
    virtual unknown_ret SendHTTPRequestAndStreamResponse() = 0; //argc: 2, index 7
    virtual unknown_ret DeferHTTPRequest() = 0; //argc: 1, index 8
    virtual unknown_ret PrioritizeHTTPRequest() = 0; //argc: 1, index 9
    virtual unknown_ret CancelHTTPRequest() = 0; //argc: 1, index 10
    virtual unknown_ret GetHTTPResponseHeaderSize() = 0; //argc: 3, index 11
    virtual unknown_ret GetHTTPResponseHeaderValue() = 0; //argc: 4, index 12
    virtual unknown_ret GetHTTPResponseBodySize() = 0; //argc: 2, index 13
    virtual unknown_ret GetHTTPResponseBodyData() = 0; //argc: 3, index 14
    virtual unknown_ret GetHTTPStreamingResponseBodyData() = 0; //argc: 4, index 15
    virtual unknown_ret ReleaseHTTPRequest() = 0; //argc: 1, index 16
    virtual unknown_ret GetHTTPDownloadProgressPct() = 0; //argc: 2, index 17
    virtual unknown_ret SetHTTPRequestRawPostBody() = 0; //argc: 4, index 18
    virtual unknown_ret CreateCookieContainer() = 0; //argc: 1, index 19
    virtual unknown_ret ReleaseCookieContainer() = 0; //argc: 1, index 20
    virtual unknown_ret SetCookie() = 0; //argc: 4, index 21
    virtual unknown_ret SetHTTPRequestCookieContainer() = 0; //argc: 2, index 22
    virtual unknown_ret SetHTTPRequestUserAgentInfo() = 0; //argc: 2, index 23
    virtual unknown_ret SetHTTPRequestRequiresVerifiedCertificate() = 0; //argc: 2, index 24
    virtual unknown_ret SetHTTPRequestAbsoluteTimeoutMS() = 0; //argc: 2, index 25
    virtual unknown_ret GetHTTPRequestWasTimedOut() = 0; //argc: 2, index 26
    virtual unknown_ret SetHTTPRequestRedirectsEnabled() = 0; //argc: 2, index 27
    virtual unknown_ret SaveHTTPResponseBodyToDisk() = 0; //argc: 3, index 28
};