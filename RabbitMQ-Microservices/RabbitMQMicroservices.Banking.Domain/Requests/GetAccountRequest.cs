using MediatR;
using RabbitMQMicroservices.Banking.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQMicroservices.Banking.Domain.Requests
{
    public class GetAccountRequest : IRequest<GetAccountResponse>
    {
        public long Id { get; set; }
    }
}
