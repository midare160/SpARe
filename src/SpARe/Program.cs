using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SpARe.Extensions;
using SpARe.Services;
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
        private static async Task Main(string[] args)
        {
            await Host.CreateDefaultBuilder(args)
                .ConfigureServices(s =>
                {
                    AddHosts(s);
                    AddServices(s);
                    AddForms(s);
                })
                .StartAsync();
        }

        private static void AddHosts(IServiceCollection serviceCollection)
        {
            serviceCollection.AddHostedService<ApplicationHostedService>();
        }

        private static void AddServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IFormFactory, FormFactory>();
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
