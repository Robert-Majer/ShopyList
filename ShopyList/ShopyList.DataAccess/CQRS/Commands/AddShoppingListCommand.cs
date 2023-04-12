using ShopyList.DataAccess.Entities;

namespace ShopyList.DataAccess.CQRS.Commands
{
    public class AddShoppingListCommand : CommandBase<ShoppingList, ShoppingList>
    {
        public override async Task<ShoppingList> Execute(ShopyListStorageContext context)
        {
            await context.ShoppingLists.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}