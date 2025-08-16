namespace Csharp.Gof.Api.HttpExtensions
{
    using Csharp.Gof.Domain.Enums;
    using Csharp.Gof.Domain.Models;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;

    public static class ResultHttpMapping
    {
        // Result sem payload
        public static IResult ToHttpResult(this Result result, HttpContext ctx)
        {
            if (result.IsSuccess) return Results.NoContent(); // 204 para comandos

            var (status, problem) = CreateProblem(result.Errors, ctx);
            return Results.Problem(problem.Detail, statusCode: status, title: problem.Title, type: problem.Type,
                                   extensions: problem.Extensions);
        }

        // Result com payload
        public static IResult ToHttpResult<T>(this Result<T> result, HttpContext ctx)
        {
            if (result.IsSuccess) return Results.Ok(result.Value); // 200 com o valor

            var (status, problem) = CreateProblem(result.Errors, ctx);
            return Results.Problem(problem.Detail, statusCode: status, title: problem.Title, type: problem.Type,
                                   extensions: problem.Extensions);
        }

        private static (int status, ProblemDetails problem) CreateProblem(
            IReadOnlyList<Error> errors, HttpContext ctx)
        {
            var first = errors[0];
            var status = first.Code switch
            {
                ErrorCode.UNAUTHORIZED => StatusCodes.Status401Unauthorized,
                ErrorCode.FORBIDDEN => StatusCodes.Status403Forbidden,
                ErrorCode.RESOURCE_NOT_FOUND => StatusCodes.Status404NotFound,
                ErrorCode.RESOURCE_CONFLICT => StatusCodes.Status409Conflict,
                ErrorCode.VALIDATION_FAILED
                    or ErrorCode.INVALID_FIELD_VALUE
                    or ErrorCode.MISSING_REQUIRED_FIELD
                                                => StatusCodes.Status422UnprocessableEntity,
                ErrorCode.SERVICE_UNAVAILABLE => StatusCodes.Status503ServiceUnavailable,
                ErrorCode.TIMEOUT => StatusCodes.Status504GatewayTimeout,
                _ => StatusCodes.Status500InternalServerError
            };

            var traceId = Activity.Current?.Id ?? ctx.TraceIdentifier;

            var pd = new ProblemDetails
            {
                Title = first.Message,
                Detail = first.Message,
                Status = status,
                Type = $"urn:error:{first.Code}",
                Instance = ctx.Request.Path
            };

            pd.Extensions["traceId"] = traceId;
            pd.Extensions["errors"] = errors.Select(e => new {
                code = e.Code.ToString(),
                msg = e.Message,
            }).ToArray();

            return (status, pd);
        }
    }
}
