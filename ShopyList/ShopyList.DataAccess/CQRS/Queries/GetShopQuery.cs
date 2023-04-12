using Microsoft.EntityFrameworkCore;
using ShopyList.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopyList.DataAccess.CQRS.Queries
{
    public class GetShopQuery : QueryBase<Shop>
    {
        public int Id { get; set; }

        public override async Task<Shop> Execute(ShopyListStorageContext context)
        {
            var shop = await context.Shops.FirstOrDefaultAsync(x => x.Id == this.Id);
            return shop;
        }
    }
}