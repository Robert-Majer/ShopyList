using Microsoft.EntityFrameworkCore;
using ShopyList.DataAccess.Entities;

namespace ShopyList.DataAccess.CQRS.Commands.ShoppingListsCommands
{
    public class EditShoppingListCommand : CommandBase<ShoppingList, ShoppingList>
    {
        public override async Task<ShoppingList> Execute(ShopyListStorageContext context)
        {
            var editShoppingList = await context.ShoppingLists.SingleOrDefaultAsync(x => x.Id == this.Parameter.Id);
            editShoppingList.Name = this.Parameter.Name;
            await context.SaveChangesAsync();
            return editShoppingList;
        }
    }
}