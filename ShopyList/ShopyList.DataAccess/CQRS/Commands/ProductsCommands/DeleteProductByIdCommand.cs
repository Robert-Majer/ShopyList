using Microsoft.EntityFrameworkCore;
using ShopyList.DataAccess.Entities;

namespace ShopyList.DataAccess.CQRS.Commands.ProductsCommands
{
    public class DeleteProductByIdCommand : CommandBase<Product, Product>
    {
        public int Id { get; set; }

        public override async Task<Product> Execute(ShopyListStorageContext context)
        {
            var removeProduct = await context.Products.SingleOrDefaultAsync(x => x.Id == this.Id);
            context.Products.Remove(removeProduct);
            await context.SaveChangesAsync();
            return removeProduct;
        }
    }
}