using System;

namespace Sharchive.Scm
{
	public class SvnAdapter : ScmAdapter
	{
		public SvnAdapter ()
		{
		}

		public override bool Add (string path)
		{
			return base.Add (path);
		}
	}
}

