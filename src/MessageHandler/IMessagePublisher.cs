namespace PublishSubscribe.MessageHandler;

public interface IMessagePublisher
{
    void PublishMessage(string pipeName, string message);
}