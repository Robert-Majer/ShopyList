using FluentValidation;
using ShopyList.ApplicationServices.API.Domain.ShopsRequestResponse;

namespace ShopyList.ApplicationServices.API.Validators
{
    public class AddShopRequestValidator : AbstractValidator<AddShopRequest>
    {
        public AddShopRequestValidator()
        {
            this.RuleFor(x => x.Name).Length(4, 30);
        }
    }
}