using System;

namespace Sharchive.TypeExtensions
{
	public static class Converter
	{
//		public static string BytesToString(byte[] bytes)
//		{
//		}
//
//		public static int BytesToInt(byte[] bytes)
//		{
//			var str = String.Join("", bytes);
//			return str.TryToInt();
//		}

		public static int CharsToInt(char[] chars)
		{
			var str = String.Join("", chars);
			return str.TryToInt();
		}

		public static string CharsToString(char[] chars)
		{
			return String.Join("", chars);
		}

		public static string PadIntToString(int intValue, int length)
		{
			return intValue.ToString("00000000");
		}

		public static char[] PadIntToChars(int intValue, int length)
		{
			return PadIntToString(intValue, length).ToCharArray();
		}
	}
}

