namespace PublishSubscribe.Infra.MessageHandler;

public interface IMessagePublisher
{
    void StartDiscoveringSubscribers();
    void StopDiscoveringSubscribers();

    void PublishMessage(string message);
}