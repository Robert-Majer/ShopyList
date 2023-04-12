using AutoMapper;
using MediatR;
using ShopyList.ApplicationServices.API.Domain.ShoppingListsRequestResponse;
using ShopyList.DataAccess.CQRS;
using ShopyList.DataAccess.CQRS.Queries.ShoppingListsQueries;

namespace ShopyList.ApplicationServices.API.Handlers.ShoppingListsHandlers
{
    public class GetShoppingListByIdHandler : IRequestHandler<GetShoppingListByIdRequest, GetShoppingListByIdResponse>
    {
        private readonly IQueryExecutor queryExecutor;
        private readonly IMapper mapper;

        public GetShoppingListByIdHandler(IQueryExecutor queryExecutor, IMapper mapper)
        {
            this.queryExecutor = queryExecutor;
            this.mapper = mapper;
        }

        public async Task<GetShoppingListByIdResponse> Handle(GetShoppingListByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetShoppingListQuery()
            {
                Id = request.ShoppingListId
            };

            var shoppingList = await this.queryExecutor.Excecute(query);
            var mappedShoppingList = this.mapper.Map<Domain.Models.ShoppingList>(shoppingList);
            var response = new GetShoppingListByIdResponse()
            {
                Data = mappedShoppingList
            };
            return response;
        }
    }
}