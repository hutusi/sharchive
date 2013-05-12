using System;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Collections.Generic;

namespace Sharchive.Net
{
	public class SocketListener
	{
		public SocketListener()
		{
			_threadByClient = new Dictionary<TcpClient, Thread>();
		}

		public SocketListener (MessagePacker messagePacker, Action<TcpClient, string> receivedMsgHandler, int port)
			: this()
		{
			_port = port;
			_maxClients = 10;

			_messagePacker = messagePacker;
			_receivedMsgHandler = receivedMsgHandler;
		}

		public void Start()
		{	
			IPAddress localAddr = IPAddress.Parse("127.0.0.1");
			_listener = new TcpListener(localAddr, _port);
			_listener.Start();
		}

		public void Stop()
		{
			EndListen();
			EndAllRespondThreads();
			
			if (_listener != null)
				_listener.Stop();
		}

		public void StartToListen()
		{
			_listenThread = new Thread(() => Listen());
			_listenThread.Start();
		}

		public void EndListen()
		{
			if (_listenThread != null) {
				_listenThread.Abort();
				_listenThread = null;
			}
		}

		public void EndAllRespondThreads()
		{
			foreach (var thread in _threadByClient.Values) {
				if (thread != null)
					thread.Abort();
			}
			_threadByClient.Clear();
		}

		public void Listen()
		{
			while(true) {
				TcpClient client = _listener.AcceptTcpClient(); 
				var thread = new Thread(new ParameterizedThreadStart(_RespondClient));
				thread.Start(client);
				_threadByClient[client] = thread;
			}
		}

		private void _RespondClient(object param)
		{
			TcpClient client = param as TcpClient;
			try {
				NetworkStream stream = client.GetStream();
				var streamReader = new StreamReader(stream);
				while(true) {
					var s = _messagePacker.ExtractContent(streamReader);
					if (_receivedMsgHandler != null)
						_receivedMsgHandler(client, s);
				}
			}
			catch (Exception ex) {
			}
		}

		private TcpListener _listener;
		private int _port;
		private int _maxClients;
		private Thread _listenThread;
		private Dictionary<TcpClient, Thread> _threadByClient;

		private Action<TcpClient, string> _receivedMsgHandler;
		private MessagePacker _messagePacker;
	}
}

