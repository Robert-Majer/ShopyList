using FluentValidation;
using ShopyList.ApplicationServices.API.Domain.ShoppingListsRequestResponse;

namespace ShopyList.ApplicationServices.API.Validators
{
    public class AddShoppingListRequestValidator : AbstractValidator<AddShoppingListRequest>
    {
        public AddShoppingListRequestValidator()
        {
            this.RuleFor(x => x.Name).Length(5, 30);
        }
    }
}