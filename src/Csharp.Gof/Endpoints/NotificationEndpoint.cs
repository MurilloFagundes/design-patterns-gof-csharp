namespace Csharp.Gof.Controllers
{
    using Csharp.Gof.Api.HttpExtensions;
    using Csharp.Gof.Application.Features.Notifications.Commands;
    using Csharp.Gof.Domain.Models;
    using Wolverine;

    public static class NotificationEndpoint
    {
        public static void MapNotificationsEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapPost("/notification/sender", async (SenderNotificationCommand command, IMessageBus bus, HttpContext ctx) =>
            {
                var resultCommand = await bus.InvokeAsync<Result>(command);
                return resultCommand.ToHttpResult(ctx);
            });
        }
    }
}
