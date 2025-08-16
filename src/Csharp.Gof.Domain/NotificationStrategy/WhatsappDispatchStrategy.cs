using Csharp.Gof.Domain.Models;
using Microsoft.Extensions.Logging;

namespace Csharp.Gof.Domain.NotificationStrategy
{
    public class WhatsappDispatchStrategy : IDispatchStrategy
    {
        private readonly ILogger<WhatsappDispatchStrategy> _logger;

        public WhatsappDispatchStrategy(ILogger<WhatsappDispatchStrategy> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<Result> DispatchAsync(Notification payload, CancellationToken ct = default)
        {
            _logger.LogInformation("Whatsapp disparado.");
            var result = Result.Success();
            return await Task.FromResult(result);
        }
    }
}
