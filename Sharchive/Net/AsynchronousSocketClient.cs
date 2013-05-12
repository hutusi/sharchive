using System;

namespace Sharchive.Net
{
	public class AsynchronousSocketClient : SocketClient
	{
		public AsynchronousSocketClient ()
		{
		}
		public AsynchronousSocketClient(MessagePacker messagePacker, Action<string> receivedMsgHandler)
			: base(messagePacker, receivedMsgHandler)
		{
		}
	}
}

