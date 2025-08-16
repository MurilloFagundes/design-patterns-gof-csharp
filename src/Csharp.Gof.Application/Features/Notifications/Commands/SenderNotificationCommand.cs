namespace Csharp.Gof.Application.Features.Notifications.Commands
{
    public record SenderNotificationCommand(string To, string? Subject, string Text, string Channel);
}
