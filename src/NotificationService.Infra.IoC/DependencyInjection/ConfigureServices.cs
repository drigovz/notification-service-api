using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace NotificationService.Infra.IoC.DependencyInjection
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            var handlers = AppDomain.CurrentDomain.Load("NotificationService.Application");
            services.AddMediatR(handlers);

            string senderEmailAddress = configuration["Email:Sender"],
                   smtpEmailAddress = configuration["Email:Smtp"];
            int httpPort = configuration["Email:Port"] != null ? Convert.ToInt32(configuration["Email:Port"]) : 587;

            services.AddFluentEmail(senderEmailAddress)
                    .AddRazorRenderer()
                    .AddSmtpSender(smtpEmailAddress, httpPort);

            return services;
        }
    }
}
