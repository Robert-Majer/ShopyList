using AutoMapper;
using MediatR;
using ShopyList.ApplicationServices.API.Domain.ProductsRequestResponse;
using ShopyList.DataAccess.CQRS;
using ShopyList.DataAccess.CQRS.Commands.ProductsCommands;

namespace ShopyList.ApplicationServices.API.Handlers.ProductsHandlers
{
    public class AddProductHandler : IRequestHandler<AddProductRequest, AddProductResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;

        public AddProductHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
        }

        public async Task<AddProductResponse> Handle(AddProductRequest request, CancellationToken cancellationToken)
        {
            var product = this.mapper.Map<DataAccess.Entities.Product>(request);
            var command = new AddProductCommand() { Parameter = product };
            var productFromDb = await this.commandExecutor.Execute(command);
            return new AddProductResponse()
            {
                Data = this.mapper.Map<Domain.Models.Product>(productFromDb)
            };
        }
    }
}