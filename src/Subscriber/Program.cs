using System.IO.Pipes;
using Polly;
using Polly.Timeout;

var subscriberId = Guid.NewGuid();
var timeout = Policy.Timeout(TimeSpan.FromSeconds(1), TimeoutStrategy.Pessimistic);
var i = 1;
const string TopicName = "connect";

Connect();

while (true) Console.WriteLine(Pull());

void Connect()
{
    try
    {
        using var pipeServer = new NamedPipeServerStream(TopicName, PipeDirection.Out, -1);
        Console.WriteLine("Trying: " + i++);

        timeout.Execute(pipeServer.WaitForConnection);

        Console.WriteLine($"Listening to topic {TopicName}!");

        using var writer = new StreamWriter(pipeServer);
        writer.Write(subscriberId);
        writer.Flush();
    }
    catch (TimeoutRejectedException e)
    {
        // TODO: Investigate why retry policy was not working properly
        Connect();
    }
}

string Pull()
{
    using var pipeClient = new NamedPipeClientStream(".", subscriberId.ToString(), PipeDirection.In);
    // TODO: if timeout, try reconnect
    pipeClient.Connect();
    var reader = new StreamReader(pipeClient);
    return reader.ReadToEnd();
}