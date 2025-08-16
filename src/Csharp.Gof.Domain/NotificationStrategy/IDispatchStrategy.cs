namespace Csharp.Gof.Domain.NotificationStrategy
{
    using Csharp.Gof.Domain.Models;

    public interface IDispatchStrategy
    {
        Task<Result> DispatchAsync(Notification payload, CancellationToken ct = default);
    }
}
