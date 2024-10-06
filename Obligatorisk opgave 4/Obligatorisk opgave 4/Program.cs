using Obligatorisk_opgave_4;
using System.Net.Sockets;
using System.Net;

Calculator c = new Calculator();
Console.WriteLine(c.Add(5, 5));
Console.WriteLine(c.Subtract(5, 5));
Console.WriteLine(c.Random(5, 10));


TcpListener listener = new TcpListener(IPAddress.Any, 13000);
listener.Start();

while (true)
{
    TcpClient socket = listener.AcceptTcpClient();
    Console.WriteLine("Server activated now");


    EchoService service = new EchoService(socket);
    Task.Run(() => service.HandleClient());
}

listener.Stop();

