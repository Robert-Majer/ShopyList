using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ShopyList.DataAccess
{
    public class ShopyListStorageContextFactory : IDesignTimeDbContextFactory<ShopyListStorageContext>
    {
        public ShopyListStorageContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ShopyListStorageContext>();
            optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=ShopyList;Integrated Security=True");
            return new ShopyListStorageContext(optionsBuilder.Options);
        }
    }
}