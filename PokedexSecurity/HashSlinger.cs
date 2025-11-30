using System;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace PokedexSecurity
{
    public class PokemonCard
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string HashedPassword { get; set; }
        public int Level { get; set; }
        public string Description { get; set; }
    }
    public class HashSlinger
    {
        //Simple but so so so obsolete SHA512 hash for passwords
        public static string SlingHash(string input)
        {
            if (string.IsNullOrEmpty(input)) return string.Empty;

            var sha512 = SHA512.Create();
            
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hash = sha512.ComputeHash(inputBytes);
            return Convert.ToBase64String(hash);
        }

        public static bool VerifyHash(string input, string hash)
        {
            string isHashed = SlingHash(input);
            return string.Equals(isHashed, hash, StringComparison.Ordinal);
        }
    }
}
