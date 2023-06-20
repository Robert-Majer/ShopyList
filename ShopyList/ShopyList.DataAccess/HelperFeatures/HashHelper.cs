using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ShopyList.DataAccess.HelperFeatures
{
    public static class HashHelper
    {
        public static byte[] GenerateSalt()
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            };

            return salt;
        }

        public static string HashPassword(string password, byte[] salt)
        {
            string hashedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA1,
            iterationCount: 10000,
            numBytesRequested: 256 / 8));

            return hashedPassword;
        }

        public static bool VerifyPassword(string enteredPassword, string storedHash, byte[] salt)
        {
            string hashedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: enteredPassword,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA1,
            iterationCount: 10000,
            numBytesRequested: 256 / 8));

            return StructuralComparisons.StructuralEqualityComparer.Equals(hashedPassword, storedHash);
        }

    }
}
