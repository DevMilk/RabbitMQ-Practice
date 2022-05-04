using RabbitMQMicroservices.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQMicroservices.Banking.Domain.Events
{
    public class TransferCreatedEvent : Event
    {
        public TransferCreatedEvent(long from, long to, decimal amount)
        {
            From = from;
            To = to;
            Amount = amount;
        }

        public long From { get; private set; }
        public long To { get; private set; }
        public decimal Amount { get; private set; }
    }
}
