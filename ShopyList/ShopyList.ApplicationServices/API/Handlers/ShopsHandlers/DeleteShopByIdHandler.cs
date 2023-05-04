using AutoMapper;
using MediatR;
using ShopyList.ApplicationServices.API.Domain.ShopsRequestResponse;
using ShopyList.ApplicationServices.API.ErrorHandling;
using ShopyList.DataAccess.CQRS;
using ShopyList.DataAccess.CQRS.Commands.ShopsCommands;

namespace ShopyList.ApplicationServices.API.Handlers.ShopsHandlers
{
    public class DeleteShopByIdHandler : IRequestHandler<DeleteShopByIdRequest, DeleteShopByIdResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;

        public DeleteShopByIdHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
        }

        public async Task<DeleteShopByIdResponse> Handle(DeleteShopByIdRequest request, CancellationToken cancellationToken)
        {
            var command = new DeleteShopByIdCommand()
            {
                Id = request.ShopId
            };
            var shopFromDb = await this.commandExecutor.Execute(command);

            if (shopFromDb == null)
            {
                return new DeleteShopByIdResponse()
                {
                    Error = new Domain.ErrorModel(ErrorType.NotFound)
                };
            }

            return new DeleteShopByIdResponse()
            {
                Data = this.mapper.Map<Domain.Models.Shop>(shopFromDb)
            };
        }
    }
}