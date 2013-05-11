using System;
using System.Collections.Generic;
using System.Net;

namespace Sharchive.Net
{
	public class DnsDictionary
	{
		public static string GetIp(string hostname)
		{
			if (!_dnsCollection.ContainsKey(hostname))
				_FindDns(hostname);
			return _dnsCollection[hostname];;
		}

		private static void _FindDns(string hostname)
		{
			IPHostEntry ipHostInfo = Dns.GetHostEntry(hostname);
			IPAddress ipAddress = ipHostInfo.AddressList[0];
			_dnsCollection[hostname] = ipAddress.ToString();
		}

		private static Dictionary<string, string> _dnsCollection = new Dictionary<string, string>();
	}
}

