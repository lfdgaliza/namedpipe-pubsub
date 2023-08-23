namespace PublishSubscribe.Infra.MessageHandler;

public interface ISubscription
{
    /// <summary>
    ///     You can get a subscriptionId by using the SubscribeTo method
    /// </summary>
    /// <param name="subscriptionId"></param>
    /// <returns></returns>
    string Pull(Guid subscriptionId);

    /// <summary>
    ///     Connect to a topic so it can be pulled
    /// </summary>
    /// <param name="topicName"></param>
    /// <returns>Subscription ID</returns>
    Guid SubscribeTo(string topicName);
}