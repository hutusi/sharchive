using System;
using System.IO;

namespace Sharchive.Net
{
	public class MessagePacker
	{
		public MessagePacker ()
		{
		}

		public virtual string ExtractContent(StreamReader streamReader)
		{
			throw new NotImplementedException();
		}

		public virtual string Wrap(string message)
		{
			throw new NotImplementedException();
		}
	}
}

