using System.IO.Pipes;

var subscriberId = Guid.NewGuid();
using (var pipeServer = new NamedPipeServerStream("connect", PipeDirection.Out, -1))
{
    pipeServer.WaitForConnection();

    using (var writer = new StreamWriter(pipeServer))
    {
        writer.Write(subscriberId);
        writer.Flush();
    }
}

while (true) Console.WriteLine(Pull());

string Pull()
{
    using var pipeClient = new NamedPipeClientStream(".", subscriberId.ToString(), PipeDirection.In);
    // TODO: if timeout, try reconnect
    pipeClient.Connect();
    var reader = new StreamReader(pipeClient);
    return reader.ReadToEnd();
}