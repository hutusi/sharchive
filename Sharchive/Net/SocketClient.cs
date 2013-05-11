using System;
using System.Net.Sockets;
using System.Net;
using System.IO;

namespace Sharchive
{
	public class SocketClient : IDisposable
	{
		public SocketClient ()
		{
		}

		public SocketClient (string hostname, int port)
		{
			_hostname = hostname;
			_port = port;
		}

		public void Start()
		{
			_client = new TcpClient(_hostname, _port);
		}

		public void Stop()
		{
			_client.Close();
		}

		public void Dispose()
		{
			if (_client != null)
				_client.Close();
		}

		public void Send(string message)
		{

		}

		private void _Send(string message)
		{
		}

		private void _Write(string buffer)
		{

		}

		private string _hostname;
		private int _port;
		private TcpClient _client;
	}
}

