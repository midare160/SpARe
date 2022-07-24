using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SpARe.Services;
using SpARe.Services.Hosts;
using System.Reflection;

namespace SpARe
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        private static async Task Main(string[] args)
        {
            await Host.CreateDefaultBuilder(args)
                .UseEnvironment(Environments.Development)
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
            var formTypes = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(t => t != typeof(MainForm) && t.IsSubclassOf(typeof(Form)));

            foreach (var formType in formTypes)
            {
                serviceCollection.AddTransient(formType);
            }

            serviceCollection.AddSingleton<MainForm>();
        }
    }
}
