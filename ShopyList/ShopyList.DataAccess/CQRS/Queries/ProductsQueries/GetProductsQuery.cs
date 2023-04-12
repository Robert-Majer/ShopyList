using Microsoft.EntityFrameworkCore;
using ShopyList.DataAccess.Entities;

namespace ShopyList.DataAccess.CQRS.Queries.ProductsQueries
{
    public class GetProductsQuery : QueryBase<List<Product>>
    {
        public override async Task<List<Product>> Execute(ShopyListStorageContext context)
        {
            var products = await context.Products.ToListAsync();
            return products;
        }
    }
}