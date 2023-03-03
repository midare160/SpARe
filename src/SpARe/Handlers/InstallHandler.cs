using MediatR;
using SpARe.Properties;
using SpARe.Requests;
using SpARe.Services.IO;

namespace SpARe.Handlers
{
    public class InstallHandler : IRequestHandler<InstallRequest>
    {
        private readonly IInstallerService _installerService;

        public InstallHandler(IInstallerService installerService)
        {
            _installerService = installerService;
        }

        public Task Handle(InstallRequest request, CancellationToken cancellationToken) =>
            _installerService.InstallAsync(Resources.spotify_installer1_0_8, cancellationToken);
    }
}
