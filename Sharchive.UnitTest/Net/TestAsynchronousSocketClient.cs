using System;
using System.Collections.Generic;
using System.Threading;
using System.Net.Sockets;
using NUnit.Framework;

namespace Sharchive.Net.UnitTest
{
	[TestFixture()]
	public class TestAsynchronousSocketClient
	{
		private AsynchronousSocketListener _listener;

		[Test()]
		public void TestCase ()
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
			Assert.AreEqual(0, _clientReceivedMsgs.Count);
			Thread.Sleep(500);
			Assert.AreEqual("Hello", _serverReceivedMsgs[0]);
			Assert.AreEqual("Hello", _clientReceivedMsgs[0]);
			
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
			_listener.Send(client, msg);
		}
		
		private List<string> _clientReceivedMsgs;
		private List<string> _serverReceivedMsgs;
	}
}

