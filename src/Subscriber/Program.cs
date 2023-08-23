using PublishSubscribe.MessageHandler;

Console.Write("Subscribe to: ");
var topicName = Console.ReadLine();

ISubscription subscription = new Subscription();
var subscriptionId = subscription.SubscribeTo(topicName!);

while (true) Console.WriteLine(subscription.Pull(subscriptionId));