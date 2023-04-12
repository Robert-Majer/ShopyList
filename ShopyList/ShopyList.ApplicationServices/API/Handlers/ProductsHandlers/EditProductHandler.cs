using AutoMapper;
using MediatR;
using ShopyList.ApplicationServices.API.Domain.ProductsRequestResponse;
using ShopyList.DataAccess.CQRS;
using ShopyList.DataAccess.CQRS.Commands.ProductsCommands;

namespace ShopyList.ApplicationServices.API.Handlers.ProductsHandlers
{
    public class EditProductHandler : IRequestHandler<EditProductRequest, EditProductResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;

        public EditProductHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
        }

        public async Task<EditProductResponse> Handle(EditProductRequest request, CancellationToken cancellationToken)
        {
            var product = this.mapper.Map<DataAccess.Entities.Product>(request);
            var command = new EditProductCommand() { Parameter = product };
            var productFromDb = await this.commandExecutor.Execute(command);
            return new EditProductResponse()
            {
                Data = this.mapper.Map<Domain.Models.Product>(productFromDb)
            };
        }
    }
}