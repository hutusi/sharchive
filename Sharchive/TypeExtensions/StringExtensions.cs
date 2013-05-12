using System;

namespace Sharchive.TypeExtensions
{
	public static class StringExtensions
	{
		public static byte[] ToByteArray(this string str)
		{
			var chars = str.ToCharArray();
			var bytes = new byte[str.Length];
			for (int i = 0; i < chars.Length; ++i) {
				bytes[i] = (byte)chars[i];
			}
			return bytes;
		}
	}
}

