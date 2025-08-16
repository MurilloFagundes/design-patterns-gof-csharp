namespace Csharp.Gof.Application.DependencyInjection
{
    using Csharp.Gof.Application.Interfaces;
    using Csharp.Gof.Application.Mapster;
    using Csharp.Gof.Application.Services;
    using Csharp.Gof.Domain.NotificationStrategy;
    using Microsoft.Extensions.DependencyInjection;
    
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMapsterConfiguration();
            services.AddScoped<IDispatchStrategy, EmailDispatchStrategy>();
            services.AddScoped<IDispatchStrategy, SmsDispatchStrategy>();
            services.AddScoped<IDispatchStrategy, PushDispatchStrategy>();
            services.AddScoped<IDispatchStrategy, WhatsappDispatchStrategy>();
            services.AddScoped<INotificationDispatcher, NotificationDispatcher>();

            return services;
        }
    }
}
