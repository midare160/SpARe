using Microsoft.Extensions.DependencyInjection;
using SpARe.Services;
using SpARe.Services.Exceptions;
using SpARe.Services.FileSystem;
using SpARe.Services.Forms;

namespace SpARe.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection serviceCollection)
        {
            return serviceCollection
                .AddSingleton<IExceptionHandler, ExceptionHandler>()
                .AddSingleton<IMessageFilter, MessageFilter>()
                .AddTransient<IFormFactory, FormFactory>()
                .AddTransient<IAdRemoverService, AdRemoverService>()
                .AddTransient<IFileService, FileService>();
        }

        public static IServiceCollection AddForms<TAssemblyMarker>(this IServiceCollection serviceCollection)
        {
            foreach (var type in typeof(TAssemblyMarker).Assembly.GetTypes())
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

            return serviceCollection;
        }
    }
}
