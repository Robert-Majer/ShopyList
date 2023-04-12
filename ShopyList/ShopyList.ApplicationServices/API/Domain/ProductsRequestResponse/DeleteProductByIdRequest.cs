using MediatR;

namespace ShopyList.ApplicationServices.API.Domain.ProductsRequestResponse
{
    public class DeleteProductByIdRequest : IRequest<DeleteProductByIdResponse>
    {
        public int ProductId { get; set; }
    }
}