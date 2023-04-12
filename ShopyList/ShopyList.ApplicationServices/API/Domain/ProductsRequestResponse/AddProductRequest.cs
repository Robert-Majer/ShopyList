using MediatR;

namespace ShopyList.ApplicationServices.API.Domain.ProductsRequestResponse
{
    public class AddProductRequest : IRequest<AddProductResponse>
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public double Price { get; set; }
    }
}