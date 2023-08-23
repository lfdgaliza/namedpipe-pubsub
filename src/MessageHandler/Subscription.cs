using System.IO.Pipes;
using Polly;
using Polly.Timeout;

namespace PublishSubscribe.Infra.MessageHandler;

public class Subscription : ISubscription
{
    public string Pull(Guid subscriptionId)
    {
        using var pipeClient = new NamedPipeClientStream(".", subscriptionId.ToString(), PipeDirection.In);
        // TODO: if timeout, try reconnect
        pipeClient.Connect();
        var reader = new StreamReader(pipeClient);
        return reader.ReadToEnd();
    }


    public Guid SubscribeTo(string topicName)
    {
        var subscriptionId = Guid.NewGuid();
        var timeout = Policy.Timeout(TimeSpan.FromSeconds(1), TimeoutStrategy.Pessimistic);
        var i = 1;

        Connect();

        return subscriptionId;

        void Connect()
        {
            try
            {
                using var pipeServer = new NamedPipeServerStream(topicName, PipeDirection.Out, -1);
                Console.WriteLine("Trying: " + i++);

                timeout.Execute(pipeServer.WaitForConnection);

                Console.WriteLine($"Listening to topic {topicName}!");

                using var writer = new StreamWriter(pipeServer);
                writer.Write(subscriptionId);
                writer.Flush();
            }
            catch (TimeoutRejectedException)
            {
                // TODO: Investigate why retry policy was not working properly
                Connect();
            }
        }
    }
}