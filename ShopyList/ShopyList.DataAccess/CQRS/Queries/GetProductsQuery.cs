using Microsoft.EntityFrameworkCore;
using ShopyList.DataAccess.Entities;

namespace ShopyList.DataAccess.CQRS.Queries
{
    public class GetProductsQuery : QueryBase<List<Product>>
    {
        public string Name { get; set; }

        public override Task<List<Product>> Execute(ShopyListStorageContext context)
        {
            if (this.Name != null)
            {
                return context.Products.Where(x => x.Name == this.Name).ToListAsync();
            }
            else
            {
                return context.Products.ToListAsync();
            }
        }
    }
}