namespace Csharp.Gof.Domain.NotificationStrategy
{
    using Csharp.Gof.Domain.Models;
    using Microsoft.Extensions.Logging;

    public class PushDispatchStrategy : IDispatchStrategy
    {
        private readonly ILogger<PushDispatchStrategy> _logger;

        public PushDispatchStrategy(ILogger<PushDispatchStrategy> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Result> DispatchAsync(Notification payload, CancellationToken ct = default)
        {
            _logger.LogInformation("Push disparado.");
            var result = Result.Success();
            return await Task.FromResult(result);
        }
    }
}
