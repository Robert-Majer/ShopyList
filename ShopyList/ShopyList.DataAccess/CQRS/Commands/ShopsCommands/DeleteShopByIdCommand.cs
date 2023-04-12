using Microsoft.EntityFrameworkCore;
using ShopyList.DataAccess.Entities;

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