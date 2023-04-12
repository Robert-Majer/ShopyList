using Microsoft.EntityFrameworkCore;
using ShopyList.DataAccess.Entities;

namespace ShopyList.DataAccess.CQRS.Queries.ShopsQueries
{
    public class GetShopsQuery : QueryBase<List<Shop>>
    {
        public override async Task<List<Shop>> Execute(ShopyListStorageContext context)
        {
            var shops = await context.Shops.ToListAsync();
            return shops;
        }
    }
}