using MediatR;

namespace ShopyList.ApplicationServices.API.Domain.ShopsRequestResponse
{
    public class DeleteShopByIdRequest : IRequest<DeleteShopByIdResponse>
    {
        public int ShopId { get; set; }
    }
}