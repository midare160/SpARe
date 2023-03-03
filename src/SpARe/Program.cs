using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using SpARe;
using SpARe.Extensions;
using SpARe.Options;
using SpARe.Properties;
using SpARe.Services;
using SpARe.Services.Exceptions;
using SpARe.Services.Http;
using SpARe.Services.IO;
using SpARe.UI;
using WindowsFormsLifetime;

var builder = Host.CreateApplicationBuilder(args);

builder.Configuration.AddAsJsonStream(Resources.appsettings_static);
builder.Services.AddOptions<GitHubOptions>().Bind(builder.Configuration.GetSection(GitHubOptions.Name));

builder.Services.AddWindowsFormsLifetime<MainForm>(preApplicationRunAction: serviceProvider =>
{
    var exceptionHandler = serviceProvider.GetRequiredService<IExceptionHandler>();
    AppDomain.CurrentDomain.UnhandledException += (s, e) => exceptionHandler.HandleException(e.ExceptionObject as Exception);
    Application.ThreadException += (s, e) => exceptionHandler.HandleException(e.Exception);

    Application.AddMessageFilter(serviceProvider.GetRequiredService<IMessageFilter>());
});

builder.Services.AddFormsFromAssemblyContainingType<IAssemblyMarker>();
builder.Services.AddSingleton<IExceptionDialog, ExceptionDialog>();
builder.Services.AddSingleton<IExceptionHandler, ExceptionHandler>();
builder.Services.AddSingleton<IMessageFilter, MessageFilter>();
builder.Services.AddTransient<IAdRemoverService, AdRemoverService>();
builder.Services.AddTransient<IFileService, FileService>();
builder.Services.AddTransient<IInstallerService, InstallerService>();
builder.Services.AddTransient<IGitHubClient, GitHubClient>();

builder.Services.AddHttpClient<IGitHubClient, GitHubClient>((services, client) =>
{
    var options = services.GetRequiredService<IOptions<GitHubOptions>>();
    GitHubClient.Configure(client, options.Value.RepositoryApiUrl);
});

builder.Services.AddMediatR(config => config.RegisterServicesFromAssemblyContaining<IAssemblyMarker>());

var app = builder.Build();
await app.RunAsync();
