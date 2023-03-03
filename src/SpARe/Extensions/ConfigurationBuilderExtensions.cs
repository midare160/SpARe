using Microsoft.Extensions.Configuration;

namespace SpARe.Extensions
{
    public static class ConfigurationBuilderExtensions
    {
        public static IConfigurationBuilder AddAsJsonStream(this IConfigurationBuilder builder, byte[] bytes)
        {
            using var stream = new MemoryStream(bytes, false);

            return builder.AddJsonStream(stream);
        }
    }
}
