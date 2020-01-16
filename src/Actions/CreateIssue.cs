using System;

namespace git_gears
{
public class CreateIssue : BaseAction
{
	public static int Execute(CreateIssueOptions opts)
	{
		SanitizeOptions((CommonOptions) opts);
		Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);

		var gear = GearFactory.CreateGear(opts.Remote);
		Console.WriteLine($"gear: {gear.ToString()}");

		if (gear != null)
		{
			IssueInfo? issue = gear.CreateIssue(new CreateIssueParams{title = opts.Title, body = opts.Body});
			if (issue.HasValue)
			{
				Console.WriteLine($"Created new issue on {opts.Remote}");
				Console.WriteLine($"#{issue.Value.Number} - {issue.Value.Title} - {issue.Value.Url}");
				Console.WriteLine($"{issue.Value.Body}");
			}
			else
			{
				Console.WriteLine($"Failed to create an issue on {opts.Remote}.");
			}
		}
		return 0;
	}
}
}
