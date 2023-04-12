using AutoMapper;
using MediatR;
using ShopyList.ApplicationServices.API.Domain;
using ShopyList.DataAccess;

namespace ShopyList.ApplicationServices.API.Handlers
{
    public class GetShoppingListsHandler : IRequestHandler<GetShoppingListsRequest, GetShoppingListsResponse>
    {
        private readonly IRepository<DataAccess.Entities.ShoppingList> shoppingListRepository;
        private readonly IMapper mapper;

        public GetShoppingListsHandler(IRepository<DataAccess.Entities.ShoppingList> shoppingListRepository, IMapper mapper)
        {
            this.shoppingListRepository = shoppingListRepository;
            this.mapper = mapper;
        }

        public Task<GetShoppingListsResponse> Handle(GetShoppingListsRequest request, CancellationToken cancellationToken)
        {
            var shoppingLists = this.shoppingListRepository.GetAll();
            var mappedShoppingList = this.mapper.Map<List<Domain.Models.ShoppingList>>(shoppingLists);

            var response = new GetShoppingListsResponse()
            {
                Data = mappedShoppingList
            };
            return Task.FromResult(response);
        }
    }
}