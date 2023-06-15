using Microsoft.EntityFrameworkCore;
using ShopyList.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopyList.DataAccess.CQRS.Queries.UsersQueries
{
    public class GetUserQuery : QueryBase<User>
    {
        public string Username { get; set; }
        public override async Task<User> Execute(ShopyListStorageContext context)
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.Username == this.Username);
            return user;
        }
    }
}
