using Microsoft.EntityFrameworkCore;
using ShopyList.DataAccess.Entities;

namespace ShopyList.DataAccess.CQRS.Queries
{
    public class GetProductQuery : QueryBase<Product>
    {
        public int Id { get; set; }

        public override async Task<Product> Execute(ShopyListStorageContext context)
        {
            var product = await context.Products.FirstOrDefaultAsync(x => x.Id == this.Id);
            return product;
        }
    }
}