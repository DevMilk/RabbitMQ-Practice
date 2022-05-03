using MediatR;
using RabbitMQMicroservices.Banking.Domain.Interfaces;
using RabbitMQMicroservices.Banking.Domain.Models;
using RabbitMQMicroservices.Banking.Domain.Requests;
using RabbitMQMicroservices.Banking.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RabbitMQMicroservices.Banking.Api.Handlers
{
    public class GetAllAccountsHandler : IRequestHandler<GetAllAccountsRequest, GetAllAccountsResponse>
    {

        private readonly IAccountRepository _accountRepository;

        public GetAllAccountsHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public async Task<GetAllAccountsResponse> Handle(GetAllAccountsRequest request, CancellationToken cancellationToken)
        {
            return new GetAllAccountsResponse
            {
                Accounts = await _accountRepository.GetAccounts()
            };
        }
    }
}
