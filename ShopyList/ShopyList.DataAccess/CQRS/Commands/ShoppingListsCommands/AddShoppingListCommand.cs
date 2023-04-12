using ShopyList.DataAccess.Entities;

namespace ShopyList.DataAccess.CQRS.Commands.ShoppingListsCommands
{
    public class AddShoppingListCommand : CommandBase<ShoppingList, ShoppingList>
    {
        public override async Task<ShoppingList> Execute(ShopyListStorageContext context)
        {
            await context.ShoppingLists.AddAsync(Parameter);
            await context.SaveChangesAsync();
            return Parameter;
        }
    }
}