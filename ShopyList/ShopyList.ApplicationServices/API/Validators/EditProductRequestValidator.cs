using FluentValidation;
using ShopyList.ApplicationServices.API.Domain.ProductsRequestResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopyList.ApplicationServices.API.Validators
{
    public class EditProductRequestValidator : AbstractValidator<EditProductRequest>
    {
        public EditProductRequestValidator()
        {
            this.RuleFor(x => x.Name).Length(3, 30);
        }
    }
}