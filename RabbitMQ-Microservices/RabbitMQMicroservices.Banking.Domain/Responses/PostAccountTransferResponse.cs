using RabbitMQMicroservices.Banking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQMicroservices.Banking.Domain.Responses
{
    public class PostAccountTransferResponse
    {
        public bool isSuccess { get; set; }
    }
}
