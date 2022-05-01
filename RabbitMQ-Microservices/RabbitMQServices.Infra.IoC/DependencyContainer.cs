using Microsoft.Extensions.DependencyInjection;
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
        }
    }
}
