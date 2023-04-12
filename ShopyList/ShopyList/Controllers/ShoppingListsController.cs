using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopyList.ApplicationServices.API.Domain.ShoppingListsRequestResponse;

namespace ShopyList.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShoppingListsController : ControllerBase
    {
        private readonly IMediator mediator;

        public ShoppingListsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllShoppingLists([FromQuery] GetShoppingListsRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpGet]
        [Route("{shoppingListId}")]
        public async Task<IActionResult> GetById([FromRoute] int shoppingListId)
        {
            var request = new GetShoppingListByIdRequest()
            {
                ShoppingListId = shoppingListId
            };
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddShoppingList([FromBody] AddShoppingListRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpPut]
        [Route("")]
        public async Task<IActionResult> EditShoppingList([FromBody] EditShoppingListRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpDelete]
        [Route("{shoppingListId}")]
        public async Task<IActionResult> DeleteShoppingListById([FromRoute] int shoppingListId)
        {
            var request = new DeleteShoppingListByIdRequest()
            {
                ShoppingListId = shoppingListId
            };
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
    }
}