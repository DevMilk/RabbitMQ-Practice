using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQMicroservices.Banking.Domain.Models
{
    public class AccountTransfer
    {
        public long SourceAccount { get; set; }
        public long TargetAccount { get; set; }
        public decimal TransferAmount { get; set; }

    }
}
