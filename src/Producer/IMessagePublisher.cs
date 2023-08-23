namespace Producer;

public interface IMessagePublisher
{
    void StartDiscoveringSubscribers();
    void StopDiscoveringSubscribers();

    void PublishMessage(string message);
}