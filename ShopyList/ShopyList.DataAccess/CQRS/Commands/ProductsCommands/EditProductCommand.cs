using Microsoft.EntityFrameworkCore;
using ShopyList.DataAccess.Entities;

namespace ShopyList.DataAccess.CQRS.Commands.ProductsCommands
{
    public class EditProductCommand : CommandBase<Product, Product>
    {
        public override async Task<Product> Execute(ShopyListStorageContext context)
        {
            var editProduct = await context.Products.SingleOrDefaultAsync(x => x.Id == this.Parameter.Id);
            if (editProduct == null)
            {
                return null;
            }
            editProduct.Name = this.Parameter.Name;

            await context.SaveChangesAsync();
            return editProduct;
        }
    }
}