using System;
using System.Collections.Generic;
using System.Threading;
using System.Net.Sockets;
using NUnit.Framework;

namespace Sharchive.Net.UnitTest
{
	[TestFixture()]
	public class TestAsynchronousSocketListener
	{
		private AsynchronousSocketListener _listener;

		[TestFixtureSetUp()]
		public void Init()
		{

		}

		[Test()]
		public void LVListen()
		{
			_listener = new AsynchronousSocketListener(new LVMessagePacker(8), _ServerReceived, 54321);

			_listener.Start();
			_listener.StartToListen();

			_clientReceivedMsgs = new List<string>();
			_serverReceivedMsgs = new List<string>();

			var client = new AsynchronousSocketClient(new LVMessagePacker(8), _ClientReceived);
			client.StartToConnect("localhost", 54321);

			Thread.Sleep(500);

			client.Send("Hello");
			Thread.Sleep(500);
			Assert.AreEqual("Hello", _serverReceivedMsgs[0]);

			client.Stop();
			_listener.Stop();
		}

		[Test()]
		public void TLVListen()
		{
			char[] type = {'@', '@', '#' , '$', '@'};
			_listener = new AsynchronousSocketListener(new TLVMessagePacker(type, 8), _ServerReceived, 54321);
			
			_listener.Start();
			_listener.StartToListen();
			
			_clientReceivedMsgs = new List<string>();
			_serverReceivedMsgs = new List<string>();
			
			var client = new AsynchronousSocketClient(new TLVMessagePacker(type, 8), _ClientReceived);
			client.StartToConnect("localhost", 54321);
			
			Thread.Sleep(500);
			
			client.Send("Hello");
			Thread.Sleep(500);
			Assert.AreEqual("Hello", _serverReceivedMsgs[0]);

			client.Stop();
			_listener.Stop();
		}

		private void _ClientReceived(string msg)
		{
			_clientReceivedMsgs.Add(msg);
		}

		private void _ServerReceived(TcpClient client, string msg)
		{
			_serverReceivedMsgs.Add(msg);
		}

		private List<string> _clientReceivedMsgs;
		private List<string> _serverReceivedMsgs;
	}
}

