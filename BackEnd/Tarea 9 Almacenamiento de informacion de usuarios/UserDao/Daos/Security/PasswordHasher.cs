using Konscious.Security.Cryptography;
using System;
using System.Security.Cryptography;
using System.Text;

namespace UserDaoLib.Daos.Security
{
    public static class PasswordHasher
    {
        private static readonly string Pepper = Environment.GetEnvironmentVariable("PEPPER") ?? "SuperSecretPepper";

        public static string HashPassword(string password)
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] combined = Combine(passwordBytes, Encoding.UTF8.GetBytes(Pepper));

            using (var argon2 = new Argon2id(combined))
            {
                argon2.MemorySize = 64 * 1024;
                argon2.Iterations = 3; 
                argon2.DegreeOfParallelism = 1;

                byte[] salt = GenerateSalt(16);
                argon2.Salt = salt;

                byte[] hash = argon2.GetBytes(32);

                return $"v1:{Convert.ToBase64String(salt)}:{Convert.ToBase64String(hash)}";
            }
        }

        public static bool VerifyPassword(string password, string storedHash)
        {
            var parts = storedHash.Split(':');
            if (parts.Length != 3 || parts[0] != "v1") return false; 

            byte[] salt = Convert.FromBase64String(parts[1]);
            byte[] storedHashBytes = Convert.FromBase64String(parts[2]);

            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] combined = Combine(passwordBytes, Encoding.UTF8.GetBytes(Pepper));

            using (var argon2 = new Argon2id(combined))
            {
                argon2.MemorySize = 64 * 1024;
                argon2.Iterations = 3;
                argon2.DegreeOfParallelism = 1;
                argon2.Salt = salt;

                byte[] newHash = argon2.GetBytes(32);

                return CryptographicOperations.FixedTimeEquals(newHash, storedHashBytes);
            }
        }

        private static byte[] GenerateSalt(int length)
        {
            using (var rng = RandomNumberGenerator.Create())
            {
                byte[] salt = new byte[length];
                rng.GetBytes(salt);
                return salt;
            }
        }
        private static byte[] Combine(byte[] first, byte[] second)
        {
            byte[] combined = new byte[first.Length + second.Length];
            Buffer.BlockCopy(first, 0, combined, 0, first.Length);
            Buffer.BlockCopy(second, 0, combined, first.Length, second.Length);
            return combined;
        }
    }
}
