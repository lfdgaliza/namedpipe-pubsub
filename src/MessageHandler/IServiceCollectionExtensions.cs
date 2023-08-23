using Microsoft.Extensions.DependencyInjection;

namespace PublishSubscribe.MessageHandler;

public static class IServiceCollectionExtensions
{
    public static IServiceCollection AddMessageHandler(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<IMessagePublisher, MessagePublisher>();
        return serviceCollection;
    }
}