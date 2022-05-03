using RabbitMQMicroservices.Banking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQMicroservices.Banking.Domain.Responses
{
    public class GetAllAccountsResponse
    {
        public IEnumerable<Account> Accounts { get; set; }
    }
}
