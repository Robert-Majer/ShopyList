using Microsoft.AspNetCore.Cryptography.KeyDerivation;
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
                                                      .FirstOrDefaultAsync();

            if (validateUser == null)
            {
                return null;
            }

            string hashedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                        password: this.Parameter.Password,
                        salt: validateUser.Salt,
                        prf: KeyDerivationPrf.HMACSHA1,
                        iterationCount: 10000,
                        numBytesRequested: 256 / 8));


            if (validateUser.Password == hashedPassword)
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
