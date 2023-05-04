using FluentValidation;
using ShopyList.ApplicationServices.API.Domain.ProductsRequestResponse;

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