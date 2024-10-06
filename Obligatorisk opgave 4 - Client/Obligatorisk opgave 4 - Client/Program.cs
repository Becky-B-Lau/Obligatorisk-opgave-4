
using System.Net.Sockets;
using System.Runtime.Intrinsics.Arm;

TcpClient clientSocket = new TcpClient("127.0.0.1", 13000);
Console.WriteLine("client is ready");

Stream ns = clientSocket.GetStream();
StreamReader sr = new StreamReader(ns);
StreamWriter sw = new StreamWriter(ns);
sw.AutoFlush = true;



while (true)
{
    string serverAnswer = sr.ReadLine();
    Console.WriteLine("S: " + serverAnswer);
    
    if (serverAnswer == "Enter first number: " || serverAnswer ==  "Enter second number: " || serverAnswer == "Select operation " +
                    "1. Random " +
                    "2. Add " +
                    "3. Subtract ")
    {
        string clientMessage = Console.ReadLine();
        sw.WriteLine(clientMessage);
    }
}

ns.Close();
clientSocket.Close();


