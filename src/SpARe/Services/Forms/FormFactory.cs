using Microsoft.Extensions.DependencyInjection;
using SpARe.Services.Forms;

namespace SpARe.Services
{
    public class FormFactory : IFormFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public FormFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public T GetForm<T>() where T : IForm =>
            _serviceProvider.GetRequiredService<T>();
    }
}
