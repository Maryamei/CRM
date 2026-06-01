using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CRM.Application.Common.Behaviors;
using CRM.Application.Common.Interfaces;
using CRM.Application.Customers.Commands.Create;
using CRM.Context;
using CRM.Domain.Interfaces;
using CRM.Infrastructure.Persistence;
using CRM.Infrastructure.Repositories;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CRM.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfraStructureServices(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddDbContext<CRMContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IReadDbContext, ReadDbContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(CreateCustomerCommand).Assembly);

                // ثبت Pipeline Behavior شما هم باید اینجا یا پایینش باشه
                cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            });

            // ۲. ثبت ولیدیتورها (نیاز به پکیج FluentValidation.DependencyInjectionExtensions دارد)
            services.AddValidatorsFromAssembly(typeof(CreateCustomerCommand).Assembly);
            return services;
        }

    }
}
