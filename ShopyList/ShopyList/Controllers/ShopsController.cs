using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopyList.ApplicationServices.API.Domain;
using ShopyList.ApplicationServices.API.Domain.ShopsRequestResponse;

namespace ShopyList.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShopsController : ControllerBase
    {
        private readonly IMediator mediator;

        public ShopsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllShops([FromQuery] GetShopsRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpGet]
        [Route("{shopId}")]
        public async Task<IActionResult> GetById([FromRoute] int shopId)
        {
            var request = new GetShopByIdRequest()
            {
                ShopId = shopId
            };
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddShop([FromBody] AddShopRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpPut]
        [Route("")]
        public async Task<IActionResult> EditShop([FromBody] EditShopRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpDelete]
        [Route("{shopId}")]
        public async Task<IActionResult> DeleteShopById([FromRoute] int shopId)
        {
            var request = new DeleteShopByIdRequest()
            {
                ShopId = shopId
            };
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
    }
}