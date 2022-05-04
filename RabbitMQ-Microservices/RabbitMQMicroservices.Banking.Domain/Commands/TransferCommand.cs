using RabbitMQMicroservices.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQMicroservices.Banking.Domain.Commands
{
    public abstract class TransferCommand : Command
    {
        public long From { get; protected set; }
        public long To { get; protected set; }
        public decimal Amount { get; protected set; }
    }
}
