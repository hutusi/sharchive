using System;

namespace Sharchive.TypeExtensions
{
	public static class ObjectExtensions
	{
		public static string TryToString(this object obj, string defaultValue = null)
		{
			if (obj == null)
				return defaultValue;
			else
				return obj.ToString();
		}

		public static int TryToInt(this object obj, int defaultValue = 0)
		{
			try {
				var val = Convert.ToInt32(obj);
				return val;
			}
			catch (Exception) {
				return defaultValue;
			}
		}

		public static double TryToDouble(this object obj, double defaultValue = 0)
		{
			try {
				var val = Convert.ToDouble(obj);
				return val;
			}
			catch (Exception) {
				return defaultValue;
			}
		}

		public static object TryGetPropertyValue(this object obj, Type objType, string property, object defaultValue = null)
		{
			try{
				// todo 
			}
			catch (Exception){
			}

			return defaultValue;
		}

		public static void TrySetPropertyValue(this object obj, Type objType, string property, object val)
		{
		}
	}
}

