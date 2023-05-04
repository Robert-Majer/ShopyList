using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopyList.ApplicationServices.API.Domain.ShoppingListsRequestResponse;

namespace ShopyList.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShoppingListsController : ApiControllerBase
    {
        public ShoppingListsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [Route("")]
        public Task<IActionResult> GetAllShoppingLists([FromQuery] GetShoppingListsRequest request)
        {
            return this.HandleRequest<GetShoppingListsRequest, GetShoppingListsResponse>(request);
        }

        [HttpGet]
        [Route("{shoppingListId}")]
        public Task<IActionResult> GetById([FromRoute] int shoppingListId)
        {
            var request = new GetShoppingListByIdRequest()
            {
                ShoppingListId = shoppingListId
            };
            return this.HandleRequest<GetShoppingListByIdRequest, GetShoppingListByIdResponse>(request);
        }

        [HttpPost]
        [Route("")]
        public Task<IActionResult> AddShoppingList([FromBody] AddShoppingListRequest request)
        {
            return this.HandleRequest<AddShoppingListRequest, AddShoppingListResponse>(request);
        }

        [HttpPut]
        [Route("")]
        public Task<IActionResult> EditShoppingList([FromBody] EditShoppingListRequest request)
        {
            return this.HandleRequest<EditShoppingListRequest, EditShoppingListResponse>(request);
        }

        [HttpDelete]
        [Route("{shoppingListId}")]
        public Task<IActionResult> DeleteShoppingListById([FromRoute] int shoppingListId)
        {
            var request = new DeleteShoppingListByIdRequest()
            {
                ShoppingListId = shoppingListId
            };
            return this.HandleRequest<DeleteShoppingListByIdRequest, DeleteShoppingListByIdResponse>(request);
        }
    }
}