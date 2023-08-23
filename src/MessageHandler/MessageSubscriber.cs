using System.IO.Pipes;

namespace PublishSubscribe.MessageHandler;

public class MessageSubscriber : IMessageSubscriber
{
    private readonly string _identifier;

    public MessageSubscriber(IMessagePublisher messagePublisher, string providerName)
    {
        _identifier = Guid.NewGuid().ToString();
        messagePublisher.PublishMessage(providerName, $":connect:{_identifier}");
    }

    public string Pull()
    {
        using var pipeClient = new NamedPipeClientStream(".", _identifier, PipeDirection.In);

        // TODO log
        pipeClient.Connect();
        // TODO log

        var reader = new StreamReader(pipeClient);
        return reader.ReadToEnd();
    }
}