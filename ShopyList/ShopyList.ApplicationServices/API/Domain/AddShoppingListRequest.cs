using MediatR;

namespace ShopyList.ApplicationServices.API.Domain
{
    public class AddShoppingListRequest : IRequest<AddShoppingListResponse>
    {
        public string Name { get; set; }
    }
}