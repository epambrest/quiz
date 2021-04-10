using System.Collections.Generic;
using System.Linq;
using Lab.Quiz.Common.Mapping;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Lab.Quiz.Common.DependencyInjection
{
    public static class BootstrapExtensions
    {
        public static IServiceCollection AddCommonBootstrap(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IMapper, ManualModelMapper>();
            services.AddScoped<ICollection<IManualMapperProfile>>(sp => sp.GetServices<IManualMapperProfile>().ToList());
            return services;
        }
    }
}
