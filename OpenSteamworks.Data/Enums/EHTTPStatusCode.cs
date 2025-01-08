namespace OpenSteamworks.Data.Enums;

public enum EHTTPStatusCode
{
    Invalid, // Invalid
    Continue = 100, // Continue
    SwitchingProtocols, // Switching Protocols
    OK = 200, // OK
    Created, // Created
    Accepted, // Accepted
    NonAuthoritativeInformation, // Non-Authoritative Information
    NoContent, // No Content
    ResetContent, // Reset Content
    PartialContent, // Partial Content
    MultipleChoices = 300, // Multiple Choices
    MovedPermanently, // Moved Permanently
    Found, // Found
    SeeOther, // See Other
    NotModified, // Not Modified
    UseProxy, // Use Proxy
    TemporaryRedirect = 307, // Temporary Redirect
    BadRequest = 400, // Bad Request
    Unauthorized, // Unauthorized
    PaymentRequired, // Payment Required
    Forbidden, // Forbidden
    NotFound, // Not Found
    MethodNotAllowed, // Method Not Allowed
    NotAcceptable, // Not Acceptable
    ProxyAuthenticationRequired, // Proxy Authentication Required
    RequestTimeout, // Request Timeout
    Conflict, // Conflict
    Gone, // Gone
    LengthRequired, // Length Required
    PreconditionFailed, // Precondition Failed
    RequestEntityTooLarge, // Request Entity Too Large
    RequestURITooLarge, // Request-URI Too Large
    UnsupportedMediaType, // Unsupported Media Type
    RequestedRangeNotSatisfiable, // Requested range not satisfiable
    ExpectationFailed, // Expectation Failed
    UnknownHTTP4xx, // Unknown HTTP 4xx
    TooManyRequests = 429, // Too Many Requests
    ConnectionClosed = 444, // Connection closed
    InternalServerError = 500, // Internal Server Error
    NotImplemented, // Not Implemented
    BadGateway, // Bad Gateway
    ServiceUnavailable, // Service Unavailable
    GatewayTimeout, // Gateway Time-out
    HTTPVersionNotSupported, // HTTP Version not supported
    UnknownHTTP5xx = 599, // Unknown HTTP 5xx
};