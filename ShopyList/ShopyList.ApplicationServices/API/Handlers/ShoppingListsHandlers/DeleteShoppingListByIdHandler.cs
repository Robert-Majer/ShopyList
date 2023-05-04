using AutoMapper;
using MediatR;
using ShopyList.ApplicationServices.API.Domain.ShoppingListsRequestResponse;
using ShopyList.ApplicationServices.API.ErrorHandling;
using ShopyList.DataAccess.CQRS;
using ShopyList.DataAccess.CQRS.Commands.ShoppingListsCommands;

namespace ShopyList.ApplicationServices.API.Handlers.ShoppingListsHandlers
{
    public class DeleteShoppingListByIdHandler : IRequestHandler<DeleteShoppingListByIdRequest, DeleteShoppingListByIdResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;

        public DeleteShoppingListByIdHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
        }

        public async Task<DeleteShoppingListByIdResponse> Handle(DeleteShoppingListByIdRequest request, CancellationToken cancellationToken)
        {
            var command = new DeleteShoppingListByIdCommand()
            {
                Id = request.ShoppingListId
            };
            var shoppingListFromDb = await this.commandExecutor.Execute(command);

            if (shoppingListFromDb == null)
            {
                return new DeleteShoppingListByIdResponse()
                {
                    Error = new Domain.ErrorModel(ErrorType.NotFound)
                };
            }

            return new DeleteShoppingListByIdResponse()
            {
                Data = this.mapper.Map<Domain.Models.ShoppingList>(shoppingListFromDb)
            };
        }
    }
}