using MediatR;

namespace ShopyList.ApplicationServices.API.Domain.ShoppingListsRequestResponse
{
    public class AddShoppingListRequest : IRequest<AddShoppingListResponse>
    {
        public string Name { get; set; }
    }
}