using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopyList.ApplicationServices.API.Domain.ShopsRequestResponse;

namespace ShopyList.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ShopsController : ApiControllerBase
    {
        public ShopsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [Route("")]
        public Task<IActionResult> GetAllShops([FromQuery] GetShopsRequest request)
        {
            return this.HandleRequest<GetShopsRequest, GetShopsResponse>(request);
        }

        [HttpGet]
        [Route("{shopId}")]
        public Task<IActionResult> GetById([FromRoute] int shopId)
        {
            var request = new GetShopByIdRequest()
            {
                ShopId = shopId
            };
            return this.HandleRequest<GetShopByIdRequest, GetShopByIdResponse>(request);
        }

        [HttpPost]
        [Route("")]
        public Task<IActionResult> AddShop([FromBody] AddShopRequest request)
        {
            return this.HandleRequest<AddShopRequest, AddShopResponse>(request);
        }

        [HttpPut]
        [Route("")]
        public Task<IActionResult> EditShop([FromBody] EditShopRequest request)
        {
            return this.HandleRequest<EditShopRequest, EditShopResponse>(request);
        }

        [HttpDelete]
        [Route("{shopId}")]
        public Task<IActionResult> DeleteShopById([FromRoute] int shopId)
        {
            var request = new DeleteShopByIdRequest()
            {
                ShopId = shopId
            };
            return this.HandleRequest<DeleteShopByIdRequest, DeleteShopByIdResponse>(request);
        }
    }
}