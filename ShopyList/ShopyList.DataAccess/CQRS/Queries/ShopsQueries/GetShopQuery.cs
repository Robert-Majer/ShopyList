using Microsoft.EntityFrameworkCore;
using ShopyList.DataAccess.Entities;

namespace ShopyList.DataAccess.CQRS.Queries.ShopsQueries
{
    public class GetShopQuery : QueryBase<Shop>
    {
        public int Id { get; set; }

        public override async Task<Shop> Execute(ShopyListStorageContext context)
        {
            var shop = await context.Shops.FirstOrDefaultAsync(x => x.Id == Id);
            return shop;
        }
    }
}