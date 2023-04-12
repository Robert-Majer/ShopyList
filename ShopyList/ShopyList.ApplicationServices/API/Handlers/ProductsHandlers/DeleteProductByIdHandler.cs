using AutoMapper;
using MediatR;
using ShopyList.ApplicationServices.API.Domain.ProductsRequestResponse;
using ShopyList.DataAccess.CQRS;
using ShopyList.DataAccess.CQRS.Commands.ProductsCommands;

namespace ShopyList.ApplicationServices.API.Handlers.ProductsHandlers
{
    public class DeleteProductByIdHandler : IRequestHandler<DeleteProductByIdRequest, DeleteProductByIdResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;

        public DeleteProductByIdHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
        }

        public async Task<DeleteProductByIdResponse> Handle(DeleteProductByIdRequest request, CancellationToken cancellationToken)
        {
            var command = new DeleteProductByIdCommand()
            {
                Id = request.ProductId
            };
            var productFromDb = await this.commandExecutor.Execute(command);
            return new DeleteProductByIdResponse()
            {
                Data = this.mapper.Map<Domain.Models.Product>(productFromDb)
            };
        }
    }
}