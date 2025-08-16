namespace Csharp.Gof.Domain.Enums
{
    public enum ErrorCode
    {
        // 1xxx - Payload/Request errors
        NONE = 0,
        NULL_OR_EMPTY_PAYLOAD = 1000,
        INVALID_PAYLOAD_FORMAT = 1001,
        MISSING_REQUIRED_FIELD = 1002,

        // 2xxx - Authentication/Authorization errors
        UNAUTHORIZED = 2000,
        FORBIDDEN = 2001,
        TOKEN_EXPIRED = 2002,

        // 3xxx - Resource errors
        RESOURCE_NOT_FOUND = 3000,
        RESOURCE_ALREADY_EXISTS = 3001,
        RESOURCE_CONFLICT = 3002,

        // 4xxx - Validation errors
        VALIDATION_FAILED = 4000,
        INVALID_FIELD_VALUE = 4001,

        // 5xxx - Internal/Server errors
        INTERNAL_ERROR = 5000,
        SERVICE_UNAVAILABLE = 5001,
        TIMEOUT = 5002
    }
}
