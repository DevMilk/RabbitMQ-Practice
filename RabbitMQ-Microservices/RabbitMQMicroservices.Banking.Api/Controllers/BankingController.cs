using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabbitMQMicroservices.Banking.Domain.Models;
using RabbitMQMicroservices.Banking.Domain.Requests;
using RabbitMQMicroservices.Banking.Domain.Responses;
using System.Collections.Generic;

namespace RabbitMQMicroservices.Banking.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BankingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BankingController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public ActionResult<GetAllAccountsResponse> AllAccounts([FromQuery] GetAllAccountsRequest request){
            return Ok(_mediator.Send(request));
        }

        [HttpGet]
        public ActionResult<GetAccountResponse> Account([FromQuery] GetAccountRequest request){
            return Ok(_mediator.Send(request));
        }

        [HttpPost]
        public ActionResult<PostAccountTransferResponse> AccountTransfer([FromBody] PostAccountTransferRequest request)
        {
            return Ok(_mediator.Send(request));
        }
    }
}
