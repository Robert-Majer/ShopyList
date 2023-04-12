using MediatR;

namespace ShopyList.ApplicationServices.API.Domain.ProductsRequestResponse
{
    public class GetProductByIdRequest : IRequest<GetProductByIdResponse>
    {
        public int ProductId { get; set; }
    }
}