using Lab.Quiz.BL.Services.TestService;
using Lab.Quiz.BL.Services.TestService.Mapping;
using Lab.Quiz.Common.Mapping;
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
            services.AddScoped<IManualMapperProfile, TestCardMapperProfile>();
            services.AddScoped<IManualMapperProfile, TestCardCollectionMapperProfile>();

            return services;
        }
    }
}
