using PublishSubscribe.Plugins.PubSub;

namespace Microsoft.Extensions.DependencyInjection;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddPubSubPlugin(this IServiceCollection services)
    {
        services
            .AddMessageHandler()
            .AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<PersonAddedNotificationHandler>());

        return services;
    }
}