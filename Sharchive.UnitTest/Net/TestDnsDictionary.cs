using System;
using NUnit.Framework;

namespace Sharchive.Net.UnitTest
{
	[TestFixture()]
	public class TestDnsDictionary
	{
		[Test()]
		public void Find ()
		{
			Assert.AreEqual("127.0.0.1", DnsDictionary.GetIp("localhost"));
		}
	}
}

