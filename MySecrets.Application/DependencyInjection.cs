using Microsoft.Extensions.DependencyInjection;

namespace MySecrets.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            return services;
        }
    }
}
