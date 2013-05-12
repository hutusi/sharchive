using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

using Sharchive.TypeExtensions;

namespace Sharchive.Net
{
	public class LVMessagePacker : MessagePacker
	{
		public LVMessagePacker (int lengthOfLengthBytes)
		{
			_lengthOfLengthBytes = lengthOfLengthBytes;
		}

		public override string ExtractContent(StreamReader streamReader)
		{
			char[] lengthBytes = _ReadBytes(streamReader, _lengthOfLengthBytes);
			int length = Converter.CharsToInt(lengthBytes);
			char[] contents = _ReadBytes(streamReader, length);
			return Converter.CharsToString(contents);
		}

		private char[] _ReadBytes(StreamReader streamReader, int length)
		{
			char[] buffer = new char[length];
			int readLength = 0;
			while (readLength < length)
			{
				readLength += streamReader.Read(buffer, 0, length - readLength);
			}
			return buffer;
		}

		public override string Wrap(string message)
		{
			var lengthString = Converter.PadIntToString(message.Length, _lengthOfLengthBytes);
			StringBuilder builder = new StringBuilder();
			builder.Append(lengthString);
			builder.Append(message);
			return builder.ToString();
		}

		private int _lengthOfLengthBytes;
	}
}

