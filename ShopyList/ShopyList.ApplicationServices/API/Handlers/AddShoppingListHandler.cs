using AutoMapper;
using MediatR;
using ShopyList.ApplicationServices.API.Domain;
using ShopyList.ApplicationServices.API.Domain.Models;
using ShopyList.DataAccess.CQRS;
using ShopyList.DataAccess.CQRS.Commands;

namespace ShopyList.ApplicationServices.API.Handlers
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
            var shoppingList = this.mapper.Map<DataAccess.Entities.ShoppingList>(request);
            var command = new AddShoppingListCommand() { Parameter = shoppingList };
            var shoppingListFromDb = await this.commandExecutor.Execute(command);
            return new AddShoppingListResponse
            {
                Data = this.mapper.Map<ShoppingList>(shoppingListFromDb)
            };
        }
    }
}