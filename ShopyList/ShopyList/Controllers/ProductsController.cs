using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopyList.ApplicationServices.API.Domain.ProductsRequestResponse;

namespace ShopyList.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ApiControllerBase
    {
        public ProductsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [Route("")]
        public Task<IActionResult> GetAllProducts([FromQuery] GetProductsRequest request)
        {
            return this.HandleRequest<GetProductsRequest, GetProductsResponse>(request);
        }

        [HttpGet]
        [Route("{productId}")]
        public Task<IActionResult> GetById([FromRoute] int productId)
        {
            var request = new GetProductByIdRequest()
            {
                ProductId = productId
            };
            return this.HandleRequest<GetProductByIdRequest, GetProductByIdResponse>(request);
        }

        [HttpPost]
        [Route("")]
        public Task<IActionResult> AddProduct([FromBody] AddProductRequest request)
        {
            return this.HandleRequest<AddProductRequest, AddProductResponse>(request);
        }

        [HttpPut]
        [Route("")]
        public Task<IActionResult> EditProduct([FromBody] EditProductRequest request)
        {
            return this.HandleRequest<EditProductRequest, EditProductResponse>(request);
        }

        [HttpDelete]
        [Route("{productId}")]
        public Task<IActionResult> DeleteProduct([FromRoute] int productId)
        {
            var request = new DeleteProductByIdRequest()
            {
                ProductId = productId
            };
            return this.HandleRequest<DeleteProductByIdRequest, DeleteProductByIdResponse>(request);
        }
    }
}