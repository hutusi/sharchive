using System;
using System.IO;

using Sharchive.TypeExtensions;

namespace Sharchive.Net
{
	public class TLVMessagePacker : MessagePacker
	{
		public TLVMessagePacker (string type, int lengthOfLengthBytes)
		{
			_lengthOfLengthBytes = lengthOfLengthBytes;
			_typeChars = type.ToCharArray();
		}

		public override string ExtractContent(StreamReader streamReader)
		{
			char[] typeBytes = _ReadBytes(streamReader, _typeChars.Length);
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


		private char[] _typeChars;
		private int _lengthOfLengthBytes;
	}
}

