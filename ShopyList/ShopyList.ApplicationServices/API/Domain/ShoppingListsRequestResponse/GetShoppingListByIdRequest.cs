using MediatR;

namespace ShopyList.ApplicationServices.API.Domain.ShoppingListsRequestResponse
{
    public class GetShoppingListByIdRequest : IRequest<GetShoppingListByIdResponse>
    {
        public int ShoppingListId { get; set; }
    }
}