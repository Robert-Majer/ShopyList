using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using ShopyList.DataAccess.Entities;
using ShopyList.DataAccess.HelperFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ShopyList.DataAccess.CQRS.Commands.UsersCommands
{
    public class CreateUserCommand : CommandBase<User, User>
    {
        public override async Task<User> Execute(ShopyListStorageContext context)
        {
            var newUser = this.Parameter;

            newUser.Salt = HashHelper.GenerateSalt();
            newUser.Password = HashHelper.HashPassword(newUser.Password,newUser.Salt);

            await context.Users.AddAsync(newUser);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
