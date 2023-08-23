using System.Collections.Concurrent;
using System.IO.Pipes;

namespace PublishSubscribe.MessageHandler;

public sealed class MessagePublisher : IMessagePublisher, IDisposable
{
    private readonly AutoResetEvent _messageEvent = new(false);
    private readonly ConcurrentQueue<(string PipeName, string? Message)> _messageQueue = new();
    private bool _isRunning = true;

    public MessagePublisher()
    {
        StartPublishingThread();
    }

    public void Dispose()
    {
        _isRunning = false;
        _messageEvent.Set(); // Release the waiting thread
        _messageEvent.Dispose();
    }

    public void PublishMessage(string pipeName, string message)
    {
        _messageQueue.Enqueue((pipeName, message));
        _messageEvent.Set();
    }

    private void StartPublishingThread()
    {
        var publishingThread = new Thread(PublishingLoop);
        publishingThread.Start();
    }

    private void PublishingLoop()
    {
        while (_isRunning)
        {
            while (_messageQueue.TryDequeue(out var tuple))
            {
                if (tuple.Message is null) continue;
                SendToPipe(tuple.PipeName, tuple.Message);
            }

            _messageEvent.WaitOne(); // Wait for new messages
        }
    }

    private static void SendToPipe(string pipeName, string message)
    {
        using var pipeServer = new NamedPipeServerStream(pipeName, PipeDirection.Out);
        pipeServer.WaitForConnection();

        using var writer = new StreamWriter(pipeServer);
        writer.WriteLine(message);
        writer.Flush();
    }
}