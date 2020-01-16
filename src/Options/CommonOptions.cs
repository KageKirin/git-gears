using CommandLine;

namespace git_gears
{
public abstract class CommonOptions
{
	[Option('v', "verbose", Required = false, HelpText = "Verbose printing of internal actions.")]
	public bool Verbose
	{
		get;
		set;
	}

	[Value(0, MetaName = "remote", HelpText = "Remote.", Default = null)] // null -> use current upstream OR origin
		public string Remote
	{
		get;
		set;
	}

	[Value(1, MetaName = "branch", HelpText = "Branch.", Default = null)] // null -> use current branch
		public string Branch
	{
		get;
		set;
	}
}
}
