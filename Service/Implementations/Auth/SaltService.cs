using ServiceContract.Abstractions.Auth;
using System;
using System.Security.Cryptography;

namespace Service.Implementations.Auth
{
    public class SaltService : ISaltService
    {
        public string Generate()
        {
            var saltBytes = new byte[8];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(saltBytes);
            }

            return Convert.ToBase64String(saltBytes);
        }

        public string Hash(string password, string salt)
        {
            var saltBytes = Convert.FromBase64String(salt);
            var deriveBytes = new Rfc2898DeriveBytes(
                password.Trim(),
                saltBytes,
                1000);

            var hash = Convert.ToBase64String(deriveBytes.GetBytes(16));

            return hash;
        }
    }
}
