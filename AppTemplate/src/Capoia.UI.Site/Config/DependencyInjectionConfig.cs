using Capoia.UI.Site.Data;
using Capoia.UI.Site.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace Capoia.UI.Site.Config
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddSingleton<IAuthorizationHandler, PermissaoNecessariaHandler>();

            services.AddTransient<IOrderRepository, OrderRepository>();

            return services;
        }
    }
}
