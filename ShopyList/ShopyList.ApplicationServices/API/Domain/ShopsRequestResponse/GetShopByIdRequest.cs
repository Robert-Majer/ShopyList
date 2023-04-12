using MediatR;

namespace ShopyList.ApplicationServices.API.Domain.ShopsRequestResponse
{
    public class GetShopByIdRequest : IRequest<GetShopByIdResponse>
    {
        public int ShopId { get; set; }
    }
}