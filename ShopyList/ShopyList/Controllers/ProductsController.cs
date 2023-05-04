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
        public async Task<IActionResult> GetAllProducts([FromQuery] GetProductsRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        // =================> przerobiony get w Handlerze
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

        // przerobiony post
        [HttpPost]
        [Route("")]
        public Task<IActionResult> AddProduct([FromBody] AddProductRequest request)
        {
            return this.HandleRequest<AddProductRequest, AddProductResponse>(request);
        }

        [HttpPut]
        [Route("")]
        public async Task<IActionResult> EditProduct([FromBody] EditProductRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpDelete]
        [Route("{productId}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] int productId)
        {
            var request = new DeleteProductByIdRequest()
            {
                ProductId = productId
            };
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
    }
}