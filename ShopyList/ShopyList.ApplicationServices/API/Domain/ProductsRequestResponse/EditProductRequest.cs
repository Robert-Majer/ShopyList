using MediatR;

namespace ShopyList.ApplicationServices.API.Domain.ProductsRequestResponse
{
    public class EditProductRequest : IRequest<EditProductResponse>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}