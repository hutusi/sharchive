using System;
using NUnit.Framework;

namespace Sharchive.TypeExtensions.UnitTest
{
	[TestFixture()]
	public class TestConverter
	{
//		[Test()]
//		public void BytesToInt()
//		{
//			byte[] a = {(byte)'0', (byte)'1', (byte)'2', (byte)'3'};
//			Assert.AreEqual(123, Converter.BytesToInt(a));
//		}

		[Test()]
		public void CharsToInt()
		{
			char[] a = {'0', '1', '2', '3'};
			Assert.AreEqual(123, Converter.CharsToInt(a));
		}

		[Test()]
		public void PadIntToString()
		{
			Assert.AreEqual("00000123", Converter.PadIntToString(123, 8));
		}

		[Test()]
		public void PadIntToChars()
		{
			int len = 123;
			char[] expect = {'0', '0', '0', '0', '0', '1', '2', '3'};
			char[] lens = Converter.PadIntToChars(len, 8);
			Assert.AreEqual(expect, lens);
		}
	}
}

