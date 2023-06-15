using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using ShopyList.DataAccess.Entities;
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

            byte[] salt = new byte[128 / 8];
            using( var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            };
            newUser.Salt = salt;

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: newUser.Password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA1,
            iterationCount: 10000,
            numBytesRequested: 256 / 8));

            newUser.Password = hashed;

            await context.Users.AddAsync(newUser);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
