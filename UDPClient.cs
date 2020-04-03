using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SocketComUDP
{
	internal class UDPClient
	{
		public UdpClient client { get; set; }
		public IPEndPoint endPoint { get; set; }
		public UDPClient()
		{
			client = new UdpClient();
		}

		public void Connect(string ip, int port)
		{
			IPAddress address = IPAddress.Parse(ip);
			client.Connect(address, port);
			endPoint = new IPEndPoint(IPAddress.Any, port);
		}
		public void SendMessage(string message)
		{
			byte[] data = Encoding.UTF8.GetBytes(message);
			client.Send(data, data.Length);
		}
	}
}