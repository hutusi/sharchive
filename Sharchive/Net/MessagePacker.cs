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

		protected char[] _ReadBytes(StreamReader streamReader, int length)
		{
			char[] buffer = new char[length];
			int readLength = 0;
			while (readLength < length)
			{
				readLength += streamReader.Read(buffer, 0, length - readLength);
			}
			return buffer;
		}
	}
}

