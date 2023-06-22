using System.Security.Cryptography;
using System.Text;

namespace AtosPersonalFinance_API.Services
{
    public class HashPassword
    {
        public static string Encript(string password)
        {
            using var Sha256 = SHA256.Create();
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] hashBytes = Sha256.ComputeHash(passwordBytes);
            string hash = BitConverter.ToString(hashBytes).Replace("-", string.Empty);
            return hash;
        }

        public static bool Verify(string password, string hashedPassword)
        {
            string hashedInput = Encript(password);
            return string.Equals(hashedInput, hashedPassword, StringComparison.Ordinal);
        }
    }
}
