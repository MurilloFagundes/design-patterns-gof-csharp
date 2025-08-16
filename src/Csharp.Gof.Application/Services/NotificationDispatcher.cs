namespace Csharp.Gof.Application.Services
{
    using Csharp.Gof.Application.Interfaces;
    using Csharp.Gof.Domain.Models;
    using Csharp.Gof.Domain.NotificationStrategy;

    public class NotificationDispatcher : INotificationDispatcher
    {
        private readonly IReadOnlyDictionary<string, IDispatchStrategy> _strategies;

        public NotificationDispatcher(IEnumerable<IDispatchStrategy> strategies)
        {
            _strategies = new Dictionary<string, IDispatchStrategy>(StringComparer.OrdinalIgnoreCase)
            {
                ["email"] = strategies.OfType<EmailDispatchStrategy>().Single(),
                ["sms"] = strategies.OfType<SmsDispatchStrategy>().Single(),
                ["push"] = strategies.OfType<PushDispatchStrategy>().Single(),
                ["whatsapp"] = strategies.OfType<WhatsappDispatchStrategy>().Single()
            };
        }

        public async Task<Result> DispatchAsync(Notification payload, CancellationToken ct = default)
        {
            if (!_strategies.TryGetValue(payload.Channel.ToLower(), out var strategy))
                return Result.Failure(Error.InvalidInput(payload.Channel));

            return await strategy.DispatchAsync(payload, ct);
        }
    }
}
