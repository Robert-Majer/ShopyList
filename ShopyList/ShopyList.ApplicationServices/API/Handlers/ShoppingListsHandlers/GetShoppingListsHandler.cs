using AutoMapper;
using MediatR;
using ShopyList.ApplicationServices.API.Domain.ShoppingListsRequestResponse;
using ShopyList.DataAccess.CQRS;
using ShopyList.DataAccess.CQRS.Queries.ShoppingListsQueries;

namespace ShopyList.ApplicationServices.API.Handlers.ShoppingListsHandlers
{
    public class GetShoppingListsHandler : IRequestHandler<GetShoppingListsRequest, GetShoppingListsResponse>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public GetShoppingListsHandler(IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }

        public async Task<GetShoppingListsResponse> Handle(GetShoppingListsRequest request, CancellationToken cancellationToken)
        {
            var query = new GetShoppingListsQuery();
            var shoppingLists = await queryExecutor.Execute(query);
            var mappedShoppingLists = mapper.Map<List<Domain.Models.ShoppingList>>(shoppingLists);
            var response = new GetShoppingListsResponse()
            {
                Data = mappedShoppingLists
            };
            return response;
        }
    }
}