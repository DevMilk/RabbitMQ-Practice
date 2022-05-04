using MediatR;
using RabbitMQMicroservices.Banking.Domain.Models;
using RabbitMQMicroservices.Banking.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQMicroservices.Banking.Domain.Requests
{
    public class PostAccountTransferRequest : IRequest<PostAccountTransferResponse>
    {
        public AccountTransfer AccountTransferModel { get; set; }
    }
}
