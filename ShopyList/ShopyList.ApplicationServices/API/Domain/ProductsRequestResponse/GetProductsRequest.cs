using MediatR;

namespace ShopyList.ApplicationServices.API.Domain.ProductsRequestResponse
{
    public class GetProductsRequest : IRequest<GetProductsResponse>
    {
    }
}