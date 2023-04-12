using MediatR;

namespace ShopyList.ApplicationServices.API.Domain.ShoppingListsRequestResponse
{
    public class DeleteShoppingListByIdRequest : IRequest<DeleteShoppingListByIdResponse>
    {
        public int ShoppingListId { get; set; }
    }
}