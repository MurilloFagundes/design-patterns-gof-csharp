using Csharp.Gof.Domain.Enums;

namespace Csharp.Gof.Domain.Models
{
    public record Error(ErrorCode Code, string Message)
    {
        public static Error InvalidInput(string parameter) => new(ErrorCode.INVALID_FIELD_VALUE, $"Valor de entrada inválido: {parameter}");
        public static Error None = new(ErrorCode.NONE, string.Empty);
        public static Error NullOrEmpty = new(ErrorCode.NULL_OR_EMPTY_PAYLOAD, "Payload nulo ou vazio.");
        public static Error InvalidPayloadFormat = new(ErrorCode.INVALID_PAYLOAD_FORMAT, "Formato de payload inválido.");
        public static Error MissingRequiredField = new(ErrorCode.MISSING_REQUIRED_FIELD, "Campo obrigatório ausente.");
        public static Error Unauthorized = new(ErrorCode.UNAUTHORIZED, "Não autorizado.");
        public static Error Forbidden = new(ErrorCode.FORBIDDEN, "Acesso proibido.");
        public static Error TokenExpired = new(ErrorCode.TOKEN_EXPIRED, "Token expirado.");
        public static Error ResourceNotFound = new(ErrorCode.RESOURCE_NOT_FOUND, "Recurso não encontrado.");
        public static Error ResourceAlreadyExists = new(ErrorCode.RESOURCE_ALREADY_EXISTS, "Recurso já existe.");
        public static Error ResourceConflict = new(ErrorCode.RESOURCE_CONFLICT, "Conflito de recurso.");
        public static Error ValidationFailed = new(ErrorCode.VALIDATION_FAILED, "Falha de validação.");
        public static Error InvalidFieldValue = new(ErrorCode.INVALID_FIELD_VALUE, "Valor de campo inválido.");
        public static Error InternalError = new(ErrorCode.INTERNAL_ERROR, "Erro interno.");
        public static Error ServiceUnavailable = new(ErrorCode.SERVICE_UNAVAILABLE, "Serviço indisponível.");
        public static Error Timeout = new(ErrorCode.TIMEOUT, "Tempo de resposta excedido.");
    }
}
