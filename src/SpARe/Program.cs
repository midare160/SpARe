using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SpARe.Extensions;
using SpARe.Services;

namespace SpARe
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        private static async Task Main(string[] args)
        {
            var builder = Host.CreateApplicationBuilder(args);
            
            builder.Services.AddHostedService<ApplicationHostedService>();
            builder.Services.AddServices();
            builder.Services.AddForms<IAssemblyMarker>();

            var host = builder.Build();

            await host.RunAsync();
        }
    }
}
