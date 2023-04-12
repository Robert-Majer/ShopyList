using Microsoft.EntityFrameworkCore;
using ShopyList.DataAccess.Entities;

namespace ShopyList.DataAccess.CQRS.Queries.ShoppingListsQueries
{
    public class GetShoppingListsQuery : QueryBase<List<ShoppingList>>
    {
        public override async Task<List<ShoppingList>> Execute(ShopyListStorageContext context)
        {
            var shoppingLists = await context.ShoppingLists.ToListAsync();
            return shoppingLists;
        }
    }
}