using ApiFerid.Business.Services.Abstractions;
using ApiFerid.Business.Services.Implementations;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiFerid.Business.ServiceRegistrations
{
 public static class BusinessServiceRegistration
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<ICloudinaryService, CloudinaryService>();

            services.AddAutoMapper(x => { }, typeof(BusinessServiceRegistration).Assembly);

            return services;
        }
    }
}
