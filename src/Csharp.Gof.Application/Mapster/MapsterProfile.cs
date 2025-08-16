namespace Csharp.Gof.Application.Mapster
{
    using Csharp.Gof.Application.Features.Notifications.Commands;
    using Csharp.Gof.Domain.Models;
    using global::Mapster;
    using Microsoft.Extensions.DependencyInjection;

    public static class MapsterProfile
    {
        public static void AddMapsterConfiguration(this IServiceCollection services)
        {
            var config = TypeAdapterConfig.GlobalSettings;
            config.NewConfig<SenderNotificationCommand, Notification>()
                .Map(dest => dest, src => src);

            services.AddSingleton(config);
        }
    }
}
