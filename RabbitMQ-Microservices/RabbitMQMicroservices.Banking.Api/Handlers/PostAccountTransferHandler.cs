using MediatR;
using RabbitMQMicroservices.Banking.Domain.Commands;
using RabbitMQMicroservices.Banking.Domain.Interfaces;
using RabbitMQMicroservices.Banking.Domain.Requests;
using RabbitMQMicroservices.Banking.Domain.Responses;
using RabbitMQMicroservices.Domain.Core.Bus;
using System.Threading;
using System.Threading.Tasks;

namespace RabbitMQMicroservices.Banking.Api.Handlers
{

    public class PostAccountTransferHandler : IRequestHandler<PostAccountTransferRequest, PostAccountTransferResponse>
    {

        private readonly IAccountRepository _accountRepository;
        private readonly IEventBus _bus;

        public PostAccountTransferHandler(IAccountRepository accountRepository, IEventBus bus)
        {
            _accountRepository = accountRepository;
            _bus = bus;
        }
        public async Task<PostAccountTransferResponse> Handle(PostAccountTransferRequest request, CancellationToken cancellationToken)
        {
            var createTransferCommand = new CreateTransferCommand(
                    request.AccountTransferModel.SourceAccount,
                    request.AccountTransferModel.TargetAccount,
                    request.AccountTransferModel.TransferAmount
                );

            //Calls TransferCommandHandler ->
            //it just runs mediator.Send ->
            //it runs TransferCommandHandler.Handle
            _bus.SendCommand(createTransferCommand);
            return new PostAccountTransferResponse();
        }
    }
}
