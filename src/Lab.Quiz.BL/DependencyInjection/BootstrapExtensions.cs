using Lab.Quiz.BL.Services.TestService;
using Lab.Quiz.DAL.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Lab.Quiz.BL.DependencyInjection
{
    public static class BootstrapExtensions
    {
        public static IServiceCollection AddBusinessLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDataLayer(configuration);
            services.AddScoped<ITestCardService, TestCardService>();


            //services
            //    .Configure<CosmosDbConfig>(o => configuration.GetSection(nameof(CosmosDbConfig)).Bind(o))
            //    .AddScoped<IApiProxyUnitOfWorkFactory, ApiProxyUnitOfWorkFactory>()
            //    .AddScoped<IApiProxyUnitOfWork>(c => c.GetRequiredService<IApiProxyUnitOfWorkFactory>().Create());

            return services;
        }
    }
}
