using AutoMapper;
using MediatR;
using ShopyList.ApplicationServices.API.Domain.ShoppingListsRequestResponse;
using ShopyList.DataAccess.CQRS;
using ShopyList.DataAccess.CQRS.Commands.ShoppingListsCommands;

namespace ShopyList.ApplicationServices.API.Handlers.ShoppingListsHandlers
{
    public class EditShoppingListHandler : IRequestHandler<EditShoppingListRequest, EditShoppingListResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public EditShoppingListHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }

        public async Task<EditShoppingListResponse> Handle(EditShoppingListRequest request, CancellationToken cancellationToken)
        {
            var shoppingList = this.mapper.Map<DataAccess.Entities.ShoppingList>(request);
            var command = new EditShoppingListCommand() { Parameter = shoppingList };
            var shoppingListFromDb = await this.commandExecutor.Execute(command);
            return new EditShoppingListResponse()
            {
                Data = this.mapper.Map<Domain.Models.ShoppingList>(shoppingListFromDb)
            };
        }
    }
}