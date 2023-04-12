using ShopyList.DataAccess.Entities;

namespace ShopyList.DataAccess.CQRS.Commands.ShopsCommands
{
    public class AddShopCommand : CommandBase<Shop, Shop>
    {
        public override async Task<Shop> Execute(ShopyListStorageContext context)
        {
            await context.Shops.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}