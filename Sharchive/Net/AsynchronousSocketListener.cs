using System;
using System.Net.Sockets;

namespace Sharchive.Net
{
	public class AsynchronousSocketListener : SocketListener
	{
		public AsynchronousSocketListener (MessagePacker messagePacker, Action<TcpClient, string> receivedMsgHandler, int port)
			: base(messagePacker, receivedMsgHandler, port)
		{
		}
	}
}

