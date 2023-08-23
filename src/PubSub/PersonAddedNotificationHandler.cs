using System.Text.Json;
using MediatR;
using PublishSubscribe.Application.UseCases.Persons.Add;
using PublishSubscribe.Infra.MessageHandler;

namespace PublishSubscribe.Plugins.PubSub;

public sealed class PersonAddedNotificationHandler : INotificationHandler<PersonAddedNotification>
{
    private readonly IMessagePublisher _messagePublisher;

    public PersonAddedNotificationHandler(IMessagePublisher messagePublisher)
    {
        _messagePublisher = messagePublisher;
    }

    public Task Handle(PersonAddedNotification notification, CancellationToken cancellationToken)
    {
        var personJson = JsonSerializer.Serialize(notification.Person);
        // We could implement an outbox pattern here to increase reliability
        _messagePublisher.PublishMessage(personJson);
        return Task.CompletedTask;
    }
}