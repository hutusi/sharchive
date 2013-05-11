using System;
using NUnit.Framework;

namespace Sharchive.TypeExtensions.UnitTest
{
	[TestFixture()]
	public class TestObjectExtensions
	{
		[Test()]
		public void TryToString ()
		{
			var a = 1;
			Assert.AreEqual("1", a.TryToString());
			
			string b = null;
			Assert.IsNull(b.TryToString());
		}

		[Test()]
		public void TryToInt()
		{
			var s = "123";
			Assert.AreEqual(123, s.TryToInt());
		}

		[Test()]
		public void TryToDouble()
		{
			var s = "12.3";
			Assert.AreEqual(12.3, s.TryToDouble());
		}
	}
}

