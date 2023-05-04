using FluentValidation;
using ShopyList.ApplicationServices.API.Domain.ShopsRequestResponse;

namespace ShopyList.ApplicationServices.API.Validators
{
    public class EditShopRequestValidator : AbstractValidator<EditShopRequest>
    {
        public EditShopRequestValidator()
        {
            this.RuleFor(x => x.Name).Length(4, 30);
        }
    }
}