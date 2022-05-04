using RabbitMQMicroservices.Banking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQMicroservices.Banking.Domain.Interfaces
{
    public interface IAccountRepository
    {
        Task<IEnumerable<Account>> GetAccounts();
        Task<Account> GetAccount(long id);
        void Transfer(AccountTransfer accountTransfer);
    }
}
