using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SpARe.Extensions;
using SpARe.Services;
using SpARe.Services.Exceptions;
using SpARe.Services.FileSystem;
using SpARe.Services.Forms;
using SpARe.Services.Hosts;
using System.Reflection;

namespace SpARe
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main(string[] args)
        {
            Host.CreateDefaultBuilder(args)
                .ConfigureServices(s =>
                {
                    AddHosts(s);
                    AddServices(s);
                    AddForms(s);
                })
                .Start();
        }

        private static void AddHosts(IServiceCollection serviceCollection)
        {
            serviceCollection.AddHostedService<ApplicationHostedService>();
        }

        private static void AddServices(IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddTransient<IExceptionHandler, ExceptionHandler>()
                .AddTransient<IFormFactory, FormFactory>()
                .AddTransient<IAdRemoverService, AdRemoverService>()
                .AddTransient<IFileService, FileService>();
        }

        private static void AddForms(IServiceCollection serviceCollection)
        {
            foreach (var type in Assembly.GetExecutingAssembly().GetTypes())
            {
                if (type.IsImplementationOf<ISingletonForm>())
                {
                    serviceCollection.AddSingleton(type);
                    continue;
                }

                if (type.IsImplementationOf<ITransientForm>())
                {
                    serviceCollection.AddTransient(type);
                }
            }
        }
    }
}
