using System;
using System.Threading.Tasks;

namespace git_gears
{
public class ListRepos
{
	public static async Task<int> ExecuteAsync(ListReposOptions opts)
	{
		Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);

		var gear = GearFactory.CreateGear(opts.Remote);
		Console.WriteLine($"gear: {gear.ToString()}");
		if (gear != null)
		{
			Console.WriteLine("-- ListRepos --");
			var repos = await gear.ListReposAsync();
			foreach (var i in repos)
			{
				Console.WriteLine($"{i.Name} - {i.Description} - {i.Url}");
			}
		}

		return 0;
	}
}
}
