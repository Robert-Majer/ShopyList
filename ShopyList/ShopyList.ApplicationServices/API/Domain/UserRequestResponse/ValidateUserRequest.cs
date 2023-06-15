using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopyList.ApplicationServices.API.Domain.UserRequestResponse
{
    public class ValidateUserRequest : IRequest<ValidateUserResponse>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
