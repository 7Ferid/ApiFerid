using ApiFerid.Business.Dtos.TokenDtos;
using ApiFerid.Business.Services.Abstractions;
using ApiFerid.Business.Services.Implementations;
using ApiFerid.Business.Validators.EmployeeValidators;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiFerid.Business.ServiceRegistrations
{
 public static class BusinessServiceRegistration
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddFluentValidationAutoValidation();


            services.AddValidatorsFromAssemblyContaining<EmployeeCreateDtoValidator>();

            AddServices(services);

            services.AddAutoMapper(x => { }, typeof(BusinessServiceRegistration).Assembly);

            var jwtOptionsDto = configuration.GetSection("JWTOptions").Get<JWTOptionsDto>() ?? new();

            services.AddAuthentication(config =>
            {
                config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ValidIssuer = jwtOptionsDto.Issuer,
                    ValidAudience = jwtOptionsDto.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptionsDto.SecretKey)),
                    RoleClaimType = "Role"
                };
            });


            return services;
        }
        private static void AddServices(IServiceCollection services)
        {
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<ICloudinaryService, CloudinaryService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IJWTService, JWTService>();
        }
    }
}
