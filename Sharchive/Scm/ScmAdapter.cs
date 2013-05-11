using System;
using System.Collections.Generic;

namespace Sharchive
{
	public class ScmAdapter
	{
		public ScmAdapter ()
		{
		}

		public virtual bool Add(string path)
		{
			throw new NotImplementedException();
		}

		public virtual IEnumerable<string> Add(ICollection<string> paths)
		{
			return _InvokeByCollection(Add, paths);
		}


		///// private methods

		private IEnumerable<string> _InvokeByCollection(Func<string, bool> func, ICollection<string> paths)
		{
			foreach(var path in paths)
			{
				if (func(path))
					yield return path;
			}
		}
	}
}

