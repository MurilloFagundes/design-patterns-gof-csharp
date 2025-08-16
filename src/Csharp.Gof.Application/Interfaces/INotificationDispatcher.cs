namespace Csharp.Gof.Application.Interfaces
{
    using Csharp.Gof.Domain.Models;

    public interface INotificationDispatcher
    {
        Task<Result> DispatchAsync(Notification payload, CancellationToken ct = default);
    }
}
