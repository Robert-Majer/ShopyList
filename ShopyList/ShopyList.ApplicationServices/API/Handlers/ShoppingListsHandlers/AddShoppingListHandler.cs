using AutoMapper;
using MediatR;
using ShopyList.ApplicationServices.API.Domain.Models;
using ShopyList.ApplicationServices.API.Domain.ShoppingListsRequestResponse;
using ShopyList.DataAccess.CQRS;
using ShopyList.DataAccess.CQRS.Commands.ShoppingListsCommands;

namespace ShopyList.ApplicationServices.API.Handlers.ShoppingListsHandlers
{
    public class AddShoppingListHandler : IRequestHandler<AddShoppingListRequest, AddShoppingListResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public AddShoppingListHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }

        public async Task<AddShoppingListResponse> Handle(AddShoppingListRequest request, CancellationToken cancellationToken)
        {
            var shoppingList = mapper.Map<DataAccess.Entities.ShoppingList>(request);
            var command = new AddShoppingListCommand() { Parameter = shoppingList };
            var shoppingListFromDb = await commandExecutor.Execute(command);
            return new AddShoppingListResponse
            {
                Data = mapper.Map<ShoppingList>(shoppingListFromDb)
            };
        }
    }
}