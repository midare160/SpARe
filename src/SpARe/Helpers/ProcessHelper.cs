using System.Diagnostics;

namespace SpARe.Helpers;

public static class ProcessHelper
{
	public static Process? StartWithShell(string fileName)
	{
		var startInfo = new ProcessStartInfo(fileName)
		{
			UseShellExecute = true
		};

		return Process.Start(startInfo);
	}

	public static async Task<Process?> StartAsNonAdminAsync(string fileName, CancellationToken cancellationToken = default)
	{
		using var explorerProcess = Process.Start("explorer", $"\"{fileName}\"");
		await explorerProcess.WaitForExitAsync(cancellationToken);

		var processName = Path.GetFileNameWithoutExtension(fileName);

		return Process.GetProcessesByName(processName).SingleOrDefault();
	}
}
