using dCaf.Core;
using PaymentApp.Data;
using PaymentApp.Data.Queries;
using PaymentApp.Service;
using PaymentApp.Service.QueryHandlers;
using PaymentApp.Core.DomainModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace PaymentApp.Api.App_Start
{
    public static class DependcyInjectionConfig
    {
        public static IServiceCollection RegisterDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
            });
            services
                .AddScoped<ICommandQueryService, CommandQueryService>()
                .RegisterApiHandlers()
                .RegisterMemberCommandsAndQueries();

            return services;
        }
    }
}
