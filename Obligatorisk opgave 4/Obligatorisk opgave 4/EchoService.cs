using Obligatorisk_opgave_4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorisk_opgave_4
{
    internal class EchoService
    {
        private TcpClient connectionSocket;

        public EchoService(TcpClient connectionSocket)
        {
            // TODO: Complete member initialization
            this.connectionSocket = connectionSocket;
        }
        internal void HandleClient()
        {
            Stream ns = connectionSocket.GetStream();
            StreamReader reader = new StreamReader(ns);
            StreamWriter writer = new StreamWriter(ns);
            writer.AutoFlush = true; // enable automatic flushing

            
            string answer;
            while (true)
            {
                writer.WriteLine("Enter first number: ");
                string n1 = reader.ReadLine();
                writer.WriteLine("Enter second number: ");
                string n2 = reader.ReadLine();
                writer.WriteLine("Select operation " +
                    "1. Random " +
                    "2. Add " +
                    "3. Subtract ");
                string operation = reader.ReadLine();
                Calculator c = new Calculator();

                if (operation == "1")
                {
                    int m = c.Random(int.Parse(n1), int.Parse(n2));
                    answer = "The answer is: " + m;
                }
                else if (operation == "2")
                {
                    int m = c.Add(int.Parse(n1), int.Parse(n2));
                    answer = "The answer is: " + m;
                }
                else if (operation == "3")
                {
                    int m = c.Subtract(int.Parse(n1), int.Parse(n2));
                    answer = "The answer is: " + m;
                }
                else
                {
                    answer = "Invalid input";
                }
                writer.WriteLine(answer);

            }
            ns.Close();
            connectionSocket.Close();
        }

    }
}



