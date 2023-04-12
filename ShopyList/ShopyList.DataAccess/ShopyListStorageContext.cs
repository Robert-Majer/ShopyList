using Microsoft.EntityFrameworkCore;
using ShopyList.DataAccess.Entities;

namespace ShopyList.DataAccess
{
    public class ShopyListStorageContext : DbContext
    {
        public ShopyListStorageContext(DbContextOptions<ShopyListStorageContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<ShoppingList> ShoppingLists { get; set; }

        public DbSet<Shop> Shops { get; set; }
    }
}