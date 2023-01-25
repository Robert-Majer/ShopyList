using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopyList.DataAccess
{
    public class ShopyListStorageContextFactory : IDesignTimeDbContextFactory<ShopyListStorageContext>
    {
        public ShopyListStorageContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ShopyListStorageContext>();
            optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=ShopyListStorage;Integrated Security=True");
            return new ShopyListStorageContext(optionsBuilder.Options);
        }
    }
}