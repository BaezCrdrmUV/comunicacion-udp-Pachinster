using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocketComUDP
{
	class Program
	{
		static void Main(string[] args)
        {
            if (args == null)
            {
                Console.WriteLine("null");
            }
            if (args[0] == "server")
            {
                UDPServer server = new UDPServer("127.0.0.1", 8080);
                server.Listen();
            }
            else if (args[0] == "client")
            {
                UDPClient cliente = new UDPClient();
                cliente.Connect("127.0.0.1", 8080);
                while (true)
                {
                    cliente.SendMessage(Console.ReadLine());
                };
            }
        }
    }
}
