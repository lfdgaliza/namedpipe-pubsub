namespace PublishSubscribe.MessageHandler;

public interface IMessageSubscriber
{
    string Pull();
}