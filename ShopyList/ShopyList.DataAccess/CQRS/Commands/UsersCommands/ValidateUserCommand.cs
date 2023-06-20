using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;
using ShopyList.DataAccess.Entities;
using ShopyList.DataAccess.HelperFeatures;
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
                                                      .FirstOrDefaultAsync();

            if (validateUser == null)
            {
                return null;
            }

            if (HashHelper.VerifyPassword(this.Parameter.Password, validateUser.Password, validateUser.Salt))
            {
                return validateUser;
            }
            else
            {
                return null;
            }
        }
    }
}
