using Microsoft.EntityFrameworkCore;
using ShopyList.DataAccess.Entities;

namespace ShopyList.DataAccess.CQRS.Commands.ShoppingListsCommands
{
    public class DeleteShoppingListByIdCommand : CommandBase<ShoppingList, ShoppingList>
    {
        public int Id { get; set; }

        public override async Task<ShoppingList> Execute(ShopyListStorageContext context)
        {
            var removeShoppingList = await context.ShoppingLists.SingleOrDefaultAsync(x => x.Id == this.Id);
            if (removeShoppingList == null)
            {
                return null;
            }
            context.ShoppingLists.Remove(removeShoppingList);
            await context.SaveChangesAsync();
            return removeShoppingList;
        }
    }
}