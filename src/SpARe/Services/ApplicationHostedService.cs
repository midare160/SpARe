using Microsoft.Extensions.Hosting;
using SpARe.Services.Exceptions;

namespace SpARe.Services
{
	public class ApplicationHostedService : IHostedService
	{
		private readonly IHostApplicationLifetime _applicationLifetime;
		private readonly IFormFactory _formFactory;
		private readonly IExceptionHandler _exceptionHandler;
		private readonly IMessageFilter _messageFilter;

		private int _exitCode;

		public ApplicationHostedService(
			IHostApplicationLifetime applicationLifetime,
			IExceptionHandler exceptionHandler,
			IFormFactory formFactory,
			IMessageFilter messageFilter)
		{
			_applicationLifetime = applicationLifetime;
			_formFactory = formFactory;
			_exceptionHandler = exceptionHandler;
			_messageFilter = messageFilter;
		}

		public Task StartAsync(CancellationToken cancellationToken)
		{
			_applicationLifetime.ApplicationStarted.Register(() => Task.Run(Start));

			return Task.CompletedTask;
		}

		public Task StopAsync(CancellationToken cancellationToken)
		{
			Application.Exit();

			Environment.ExitCode = _exitCode;

			return Task.CompletedTask;
		}

		private void Start()
		{
			try
			{
				Run();
			}
			catch (Exception ex)
			{
				_exitCode = 1;
				_exceptionHandler.Handle(ex);
			}
			finally
			{
				_applicationLifetime.StopApplication();
			}
		}

		private void Run()
		{
			// To customize application configuration such as set high DPI settings or default font,
			// see https://aka.ms/applicationconfiguration.
			ApplicationConfiguration.Initialize();

			AppDomain.CurrentDomain.UnhandledException += _exceptionHandler.OnAppDomainException;
			Application.ThreadException += _exceptionHandler.OnThreadException;

			Application.AddMessageFilter(_messageFilter);
			Application.Run(_formFactory.GetForm<MainForm>());
		}
	}
}
