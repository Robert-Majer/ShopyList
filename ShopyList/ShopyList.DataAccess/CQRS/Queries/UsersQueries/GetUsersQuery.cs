using Microsoft.EntityFrameworkCore;
using ShopyList.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopyList.DataAccess.CQRS.Queries.UsersQueries
{
    public class GetUsersQuery : QueryBase<List<User>>
    {
        public override async Task<List<User>> Execute(ShopyListStorageContext context)
        {
            var users = await context.Users.ToListAsync();
            return users;
        }
    }
}
