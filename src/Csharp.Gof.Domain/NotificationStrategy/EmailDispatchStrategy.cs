namespace Csharp.Gof.Domain.NotificationStrategy
{
    using Csharp.Gof.Domain.Models;
    using Microsoft.Extensions.Logging;

    public class EmailDispatchStrategy : IDispatchStrategy
    {
        private readonly ILogger<EmailDispatchStrategy> _logger;

        public EmailDispatchStrategy(ILogger<EmailDispatchStrategy> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Result> DispatchAsync(Notification payload, CancellationToken ct = default)
        {
            _logger.LogInformation("Email disparado.");
            var result = Result.Success();
            return await Task.FromResult(result);
        }
    }
}
