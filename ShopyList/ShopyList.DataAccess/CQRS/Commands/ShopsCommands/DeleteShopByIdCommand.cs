using Microsoft.EntityFrameworkCore;
using ShopyList.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopyList.DataAccess.CQRS.Commands.ShopsCommands
{
    public class DeleteShopByIdCommand : CommandBase<Shop, Shop>
    {
        public int Id { get; set; }

        public override async Task<Shop> Execute(ShopyListStorageContext context)
        {
            var removeShop = await context.Shops.SingleOrDefaultAsync(x => x.Id == this.Id);
            context.Shops.Remove(removeShop);
            await context.SaveChangesAsync();
            return removeShop;
        }
    }
}