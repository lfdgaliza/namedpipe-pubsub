using PublishSubscribe.MessageHandler;

namespace Microsoft.Extensions.DependencyInjection;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddMessageHandler(this IServiceCollection services)
    {
        services.AddSingleton<IMessagePublisher>(new MessagePublisher("person"));
        return services;
    }
}