using ShopyList.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopyList.DataAccess.CQRS.Commands.UsersCommands
{
    public class CreateUserCommand : CommandBase<User, User>
    {
        public override async Task<User> Execute(ShopyListStorageContext context)
        {
            await context.Users.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
