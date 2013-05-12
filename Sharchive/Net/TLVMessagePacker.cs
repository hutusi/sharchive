using System;
using System.IO;
using System.Text;

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

		public TLVMessagePacker (char[] type, int lengthOfLengthBytes)
		{
			_lengthOfLengthBytes = lengthOfLengthBytes;
			_typeChars = type;
		}

		public override string ExtractContent(StreamReader streamReader)
		{
			_ReadMessageType(streamReader);
			char[] lengthBytes = _ReadBytes(streamReader, _lengthOfLengthBytes);
			int length = Converter.CharsToInt(lengthBytes);
			char[] contents = _ReadBytes(streamReader, length);
			return Converter.CharsToString(contents);
		}

		private void _ReadMessageType(StreamReader streamReader)
		{
			int pos = 0;
			while(pos < _typeChars.Length) {
				var ch = streamReader.Read();
				if (ch == _typeChars[pos])
					pos++;
				else  // read type mismatch, reset
					pos = 0;
			}
		}

		public override string Wrap(string message)
		{
			var lengthString = Converter.PadIntToString(message.Length, _lengthOfLengthBytes);
			StringBuilder builder = new StringBuilder();
			builder.Append(_typeChars);
			builder.Append(lengthString);
			builder.Append(message);
			return builder.ToString();
		}

		private char[] _typeChars;
		private int _lengthOfLengthBytes;
	}
}

