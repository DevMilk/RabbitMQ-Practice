using MediatR;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQMicroservices.Banking.Application.Interfaces;
using RabbitMQMicroservices.Banking.Application.Services;
using RabbitMQMicroservices.Banking.Domain.Interfaces;
using RabbitMQMicroservices.Banking.Infrastructure.Context;
using RabbitMQMicroservices.Banking.Infrastructure.Repository;
using RabbitMQMicroservices.Domain.Core.Bus;
using RabbitMQMicroservices.Infra.Bus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQServices.Infra.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Bus
            services.AddTransient<IEventBus, RabbitMQBus>();
            

            //Application Services
            services.AddTransient<IAccountService, AccountService>();

            //Repository
            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<BankingDbContext>();
        }
    }
}
