namespace SpARe.Services.IO;

public interface IInstallerService
{
    Task InstallAsync(byte[] bytes, CancellationToken cancellationToken = default);
}
