using System;
using System.Net.Sockets;
using System.Net;
using System.IO;

namespace Sharchive.Net
{
	public class SocketClient : IDisposable
	{
		public SocketClient ()
		{
		}

		public SocketClient(MessagePacker messagePacker, Action<string> receivedMsgHandler)
		{
			_messagePacker = messagePacker;
			_receivedMsgHandler = receivedMsgHandler;
		}

		public void StartToConnect(string hostname, int port)
		{
			_hostname = hostname;
			_port = port;
			Start();
		}

		public void Start()
		{
			_client = new TcpClient(_hostname, _port);
		}

		public void Stop()
		{
			if (_client != null)
				_client.Close();
		}

		public void Dispose()
		{
			if (_client != null)
				_client.Close();
		}

		public void Send(string message)
		{
			var msg = _messagePacker.Wrap(message);
			_Write(msg.ToString());
		}

		private void _Write(string buffer)
		{
			var stream = _client.GetStream();
			using (var streamWriter = new StreamWriter(stream)) {
				streamWriter.Write(buffer);
				streamWriter.Flush();
			}
		}

		public string Receive()
		{
			var msg = _Read();
			if (_receivedMsgHandler != null)
				_receivedMsgHandler(msg);
			return msg;
		}

		private string _Read()
		{
			var stream = _client.GetStream();
			using (var streamReader = new StreamReader(stream)) {
				return _messagePacker.ExtractContent(streamReader);
			}
		}

		private string _hostname;
		private int _port;
		private TcpClient _client;

		private Action<string> _receivedMsgHandler;
		private MessagePacker _messagePacker;
	}
}

