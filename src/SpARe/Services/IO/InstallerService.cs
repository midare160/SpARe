using SpARe.Helpers;
using SpARe.Utility;

namespace SpARe.Services.IO;

public class InstallerService : IInstallerService
{
    private readonly IFileService _fileService;

    public InstallerService(IFileService fileService)
    {
        _fileService = fileService;
    }

    public async Task InstallAsync(byte[] bytes, CancellationToken cancellationToken = default)
    {
        var tempFile = Path.GetTempFileName();
        var tempExe = Path.ChangeExtension(tempFile, "exe");

        using var _ = new Disposable(() =>
        {
            _fileService.Delete(tempExe);
            _fileService.Delete(tempFile);
        });

        await File.WriteAllBytesAsync(tempExe, bytes, cancellationToken);

        using var installerProcess = await ProcessHelper.StartAsNonAdminAsync(tempExe, cancellationToken);
        await installerProcess!.WaitForExitAsync(cancellationToken);
    }
}
