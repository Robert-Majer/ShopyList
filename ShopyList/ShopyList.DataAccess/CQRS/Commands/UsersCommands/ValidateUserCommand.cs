using Microsoft.EntityFrameworkCore;
using ShopyList.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ShopyList.DataAccess.CQRS.Commands.UsersCommands
{
    public class ValidateUserCommand : CommandBase<User, User>
    {
        public override async Task<User> Execute(ShopyListStorageContext context)
        {
            var validateUser = await context.Users.Where(x => x.Username == this.Parameter.Username)
                                                  .Where(x => x.Password == this.Parameter.Password)
                                                  .FirstOrDefaultAsync();

            if (validateUser == null)
            {
                return null;
            }

            return validateUser;
        }
    }
}
