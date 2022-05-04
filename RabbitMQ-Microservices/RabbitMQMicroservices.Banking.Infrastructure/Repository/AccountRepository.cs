using RabbitMQMicroservices.Banking.Domain.Interfaces;
using RabbitMQMicroservices.Banking.Domain.Models;
using RabbitMQMicroservices.Banking.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQMicroservices.Banking.Infrastructure.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly BankingDbContext _ctx;

        public AccountRepository(BankingDbContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<IEnumerable<Account>> GetAccounts()
        {
            return _ctx.Accounts;
        }
        public async Task<Account> GetAccount(long id)
        {
            return await _ctx.Accounts.FindAsync(id);
        }

        public void Transfer(AccountTransfer accountTransfer)
        {
            throw new NotImplementedException();
        }
    }
}
