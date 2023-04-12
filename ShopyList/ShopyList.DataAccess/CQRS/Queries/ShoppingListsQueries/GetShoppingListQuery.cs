using Microsoft.EntityFrameworkCore;
using ShopyList.DataAccess.Entities;

namespace ShopyList.DataAccess.CQRS.Queries.ShoppingListsQueries
{
    public class GetShoppingListQuery : QueryBase<ShoppingList>
    {
        public int Id { get; set; }

        public override async Task<ShoppingList> Execute(ShopyListStorageContext context)
        {
            var shoppingList = await context.ShoppingLists.FirstOrDefaultAsync(x => x.Id == Id);
            return shoppingList;
        }
    }
}