using System.Collections.Concurrent;
using System.IO.Pipes;
using Polly;
using Polly.Timeout;

namespace PublishSubscribe.MessageHandler;

public sealed class MessagePublisher : IMessagePublisher
{
    private readonly ConcurrentDictionary<string, bool> _subscribers = new();
    private readonly string _topic;
    private bool _canDiscover;

    public MessagePublisher(string topic)
    {
        _topic = topic;
        StartDiscoveringSubscribers();
    }

    private static TimeSpan Timeout => TimeSpan.FromSeconds(10);

    public void StartDiscoveringSubscribers()
    {
        if (_canDiscover) return;
        _canDiscover = true;
        var listenToNewSubscribers = new Thread(DiscoverSubscribers);
        listenToNewSubscribers.Start();
    }

    public void StopDiscoveringSubscribers()
    {
        _canDiscover = false;
    }

    public void PublishMessage(string message)
    {
        Parallel.ForEach(_subscribers, subscriberId =>
        {
            // TODO log
            using var pipeServer = new NamedPipeServerStream(subscriberId.Key, PipeDirection.Out);

            var policy = Policy.Timeout(Timeout, TimeoutStrategy.Pessimistic,
                (_, _, _) =>
                {
                    // TODO log
                    _subscribers.TryRemove(subscriberId);
                });

            policy.Execute(() =>
            {
                // TODO log
                pipeServer.WaitForConnection();
                // TODO log
                using var writer = new StreamWriter(pipeServer);
                writer.Write(message);
                writer.Flush();
            });
        });
    }

    private void DiscoverSubscribers()
    {
        while (_canDiscover)
        {
            // TODO: Try/Catch
            try
            {
                using var pipeClient = new NamedPipeClientStream(".", _topic, PipeDirection.In);
                using var reader = new StreamReader(pipeClient);
                pipeClient.Connect();
                if (!pipeClient.IsConnected) continue;
                var subscriberId = reader.ReadToEnd();
                pipeClient.Close();
                // TODO: validate and log
                _subscribers.TryAdd(subscriberId, true);
            }
            catch (Exception e)
            {
                // TODO: log && sleep
                Console.WriteLine(e);
            }

            // If I don't wait 1ms sometimes I receive an IO exception.
            // Maybe the SO needs a tick to manage resources
            // TODO investigate
            Thread.Sleep(1);
        }
    }
}