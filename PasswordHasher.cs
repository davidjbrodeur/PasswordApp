using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PasswordApp
{
    public sealed class PasswordHasher
    {
        private const int SaltSize = 16; //128 bit
        private const int KeySize = 32; //256 bit
        private const int Iterations = 10000;
        private string hashPassword; //THIS IS ONLY FOR APPLICATION DEMO PURPOSES

        public string HashPassword { get => hashPassword; }

        public PasswordHasher()
        {

        }

        public void Hash(string password)
        {
            using (var algorithm = new Rfc2898DeriveBytes(
                password,
                SaltSize,
                Iterations,
                HashAlgorithmName.SHA512))
            {
                var key = Convert.ToBase64String(algorithm.GetBytes(KeySize));
                var salt = Convert.ToBase64String(algorithm.Salt);

                this.hashPassword = $"{Iterations}.{salt}.{key}";
            }
            Console.WriteLine(HashPassword);
        }

        public bool Check(string password)
        {
            var parts = this.HashPassword.Split('.');

            if (parts.Length != 3)
            {
                throw new FormatException("Unexpected hash format." +
                    "Should be formatted as `{Iterations}.{salt}.{hash}`");
            }

            var salt = Convert.FromBase64String(parts[1]);
            var key = Convert.FromBase64String(parts[2]);

            using (var algorithm = new Rfc2898DeriveBytes(
                password,
                salt,
                Iterations,
                HashAlgorithmName.SHA512))
            {
                var keyToCheck = algorithm.GetBytes(KeySize);
                bool verified = keyToCheck.SequenceEqual(key);
                return verified;
            }
        }

    }
}
