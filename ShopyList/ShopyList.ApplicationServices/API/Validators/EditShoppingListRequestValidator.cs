using FluentValidation;
using ShopyList.ApplicationServices.API.Domain.ShoppingListsRequestResponse;

namespace ShopyList.ApplicationServices.API.Validators
{
    public class EditShoppingListRequestValidator : AbstractValidator<EditShoppingListRequest>
    {
        public EditShoppingListRequestValidator()
        {
            this.RuleFor(x => x.Name).Length(5, 30);
        }
    }
}