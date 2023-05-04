using FluentValidation;
using ShopyList.ApplicationServices.API.Domain.ProductsRequestResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopyList.ApplicationServices.API.Validators
{
    public class AddProductRequestValidator : AbstractValidator<AddProductRequest>
    {
        public AddProductRequestValidator()
        {
            this.RuleFor(x => x.Name).Length(3, 30);
            this.RuleFor(x => x.Price).GreaterThanOrEqualTo(0.01).WithMessage("WRONG_RANGE");
        }
    }
}