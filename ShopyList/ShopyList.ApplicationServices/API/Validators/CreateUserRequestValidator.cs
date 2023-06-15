using FluentValidation;
using ShopyList.ApplicationServices.API.Domain.ProductsRequestResponse;
using ShopyList.ApplicationServices.API.Domain.UserRequestResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopyList.ApplicationServices.API.Validators
{
    public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
    {
        public CreateUserRequestValidator()
        {
            this.RuleFor(x => x.FirstName).Length(3, 30);
            this.RuleFor(x => x.LastName).Length(3, 30);
            this.RuleFor(x => x.Username).Length(3, 30);
            this.RuleFor(x => x.Password).Length(8, 30);
        }
    }
}
