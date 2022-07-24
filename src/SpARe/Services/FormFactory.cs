using Microsoft.Extensions.DependencyInjection;

namespace SpARe.Services
{
    public class FormFactory : IFormFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public FormFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public T GetForm<T>() where T : Form =>
            _serviceProvider.GetRequiredService<T>();
    }
}
