using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopyList.ApplicationServices.API.Domain.ProductsRequestResponse;

namespace ShopyList.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProductsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllProducts([FromQuery] GetProductsRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpGet]
        [Route("{productId}")]
        public async Task<IActionResult> GetById([FromRoute] int productId)
        {
            var request = new GetProductByIdRequest()
            {
                ProductId = productId
            };
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddProduct([FromBody] AddProductRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
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