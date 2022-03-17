using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace NotificationService.Infra.IoC.DependencyInjection
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            var handlers = AppDomain.CurrentDomain.Load("NotificationService.Application");
            services.AddMediatR(handlers);

            return services;
        }
    }
}
