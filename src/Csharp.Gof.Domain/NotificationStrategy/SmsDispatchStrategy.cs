namespace Csharp.Gof.Domain.NotificationStrategy
{
    using Csharp.Gof.Domain.Models;
    using Microsoft.Extensions.Logging;

    public class SmsDispatchStrategy : IDispatchStrategy
    {
        private readonly ILogger<SmsDispatchStrategy> _logger;

        public SmsDispatchStrategy(ILogger<SmsDispatchStrategy> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Result> DispatchAsync(Notification payload, CancellationToken ct = default)
        {
            _logger.LogInformation("Sms disparado.");
            var result = Result.Success();
            return await Task.FromResult(result);
        }
    }
}
