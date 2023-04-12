using MediatR;

namespace ShopyList.ApplicationServices.API.Domain.ShoppingListsRequestResponse
{
    public class EditShoppingListRequest : IRequest<EditShoppingListResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}