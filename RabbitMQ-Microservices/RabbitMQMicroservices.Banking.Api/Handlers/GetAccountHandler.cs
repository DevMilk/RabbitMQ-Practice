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
    public class GetAccountHandler : IRequestHandler<GetAccountRequest, GetAccountResponse>
    {

        private readonly IAccountRepository _accountRepository;

        public GetAccountHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public async Task<GetAccountResponse> Handle(GetAccountRequest request, CancellationToken cancellationToken)
        {
            return new GetAccountResponse
            {
                Account = await _accountRepository.GetAccount(request.Id)
            };
        }
    }
}
