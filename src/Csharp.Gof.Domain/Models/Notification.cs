namespace Csharp.Gof.Domain.Models
{
    public sealed record Notification(string To, string? Subject, string Text, string Channel);
}
