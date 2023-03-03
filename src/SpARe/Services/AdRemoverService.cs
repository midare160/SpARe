using SpARe.Services.IO;

namespace SpARe.Services
{
    public class AdRemoverService : IAdRemoverService
	{
		private readonly IFileService _fileService;

		public AdRemoverService(IFileService fileService)
		{
			_fileService = fileService;
		}

		public Task RevertAsync()
		{
			return Task.FromException(new NotImplementedException());
		}

		public Task StartAsync()
		{
			return Task.FromException(new NotImplementedException());
		}
	}
}
