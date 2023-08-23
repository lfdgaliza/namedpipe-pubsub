using PublishSubscribe.Infra.MessageHandler;

// Console.Write("Subscribe to: ");
// var topicName = Console.ReadLine();

ISubscription subscription = new Subscription();
var subscriptionId = subscription.SubscribeTo("person");

while (true) Console.WriteLine(subscription.Pull(subscriptionId));