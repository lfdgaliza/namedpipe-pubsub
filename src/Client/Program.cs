using PublishSubscribe.MessageHandler;

IMessageSubscriber
    subscriber =
        new MessageSubscriber(new MessagePublisher(), "provider"); // instead of provider, it could be the topic

while (true)
{
    var person = subscriber.Pull();
    Console.WriteLine(person);
}