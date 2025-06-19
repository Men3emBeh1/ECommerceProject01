using Microsoft.Extensions.DependencyInjection;
using Services.Abstractions;
using Services.MappingProfiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public static class ApplicationServicesRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IserviceManager, ServiceManager>();
            services.AddAutoMapper(typeof(MapperAssemblyReference).Assembly);
            return services;
        }
    }
}
