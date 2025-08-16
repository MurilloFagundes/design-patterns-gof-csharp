namespace Csharp.Gof.Application.Features.Notifications.Commands
{
    using Csharp.Gof.Application.Interfaces;
    using Csharp.Gof.Domain.Models;
    using global::Mapster;

    public static class SenderNotificationHandler
    {
        public static async Task<Result> Handle(SenderNotificationCommand command, INotificationDispatcher notificationDispatcher)
        {
            return await notificationDispatcher.DispatchAsync(command.Adapt<Notification>());
        }
    }
}
