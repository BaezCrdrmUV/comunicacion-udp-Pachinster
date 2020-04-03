using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SocketComUDP
{
	class UDPServer
	{
		public UdpClient listener { get; set; }
		public IPEndPoint endPoint { get; set; }

		private string ip;
		private int port;

		public UDPServer(string ip, int port)
		{
			IPAddress address = IPAddress.Parse(ip);
			this.listener = new UdpClient(port);
			Console.WriteLine("Servidor iniciado en la dirección {0}:{1}",
					address.MapToIPv4().ToString(), port.ToString());
		}

		internal void Listen()
		{
			if (listener != null)
			{
				while (true)
				{
					Console.WriteLine("Esperando conexión de cliente...");
					string msg = "";

					while (msg != null && !msg.StartsWith("bye"))
					{
						IPEndPoint endPointLocal = endPoint;

						byte[] buffer = listener.Receive(ref endPointLocal);
						Console.WriteLine($"Received broadcast from {endPointLocal} :");
						msg = Encoding.ASCII.GetString(buffer);
						Console.WriteLine(msg);

					}
				}
			}
		}
	}
}
