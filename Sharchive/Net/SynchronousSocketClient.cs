using System;

namespace Sharchive.Net
{
	public class SynchronousSocketClient : SocketClient
	{
		public SynchronousSocketClient ()
		{
		}

		public SynchronousSocketClient(MessagePacker messagePacker, Action<string> receivedMsgHandler)
			: base(messagePacker, receivedMsgHandler)
		{
		}

		public override void Send (string message)
		{
			base.Send (message);
			Receive();
		}
	}
}

