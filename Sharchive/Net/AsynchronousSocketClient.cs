using System;
using System.Threading;

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

		public override void Start ()
		{
			base.Start ();

			_receivingThread = new Thread(() => ContinuousReceive());
			_receivingThread.Start();
		}

		private void ContinuousReceive()
		{
			while (true) {
				Receive();
			}
		}

		public override void Stop ()
		{
			if (_receivingThread != null)
				_receivingThread.Start();

			base.Stop ();
		}

		private Thread _receivingThread;
	}
}

