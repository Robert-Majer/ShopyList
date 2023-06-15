using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopyList.ApplicationServices.API.Domain.UserRequestResponse;

namespace ShopyList.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ApiControllerBase
    {
        public UsersController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [Route("")]
        public Task<IActionResult> GetAll([FromQuery] GetUsersRequest request)
        {
            return this.HandleRequest<GetUsersRequest, GetUsersResponse>(request);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("")]
        public Task<IActionResult> CreateUser([FromBody] CreateUserRequest request)
        {
            return this.HandleRequest<CreateUserRequest, CreateUserResponse>(request);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public Task<IActionResult> Post ([FromBody] ValidateUserRequest request)
        {
            return this.HandleRequest<ValidateUserRequest, ValidateUserResponse>(request);
        }
    }
}
