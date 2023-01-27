using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopyList.ApplicationServices.API.Domain;

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
    }
}