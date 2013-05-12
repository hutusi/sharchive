using System;

namespace Sharchive.Scm
{
	public class ScmItem
	{
		public string Name { get; set; }
		public string FullName { get; set; }

		public ScmItemStatus Status { get; set; }
		public ScmItemType Type { get; set; }

		public ScmItemRepositoryInfo RepositoryInfo { get; set; }

		public ScmItem ()
		{
		}
	}
}

