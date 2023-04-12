using ShopyList.DataAccess.Entities;

namespace ShopyList.DataAccess.CQRS.Commands.ProductsCommands
{
    public class AddProductCommand : CommandBase<Product, Product>
    {
        public override async Task<Product> Execute(ShopyListStorageContext context)
        {
            await context.Products.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}