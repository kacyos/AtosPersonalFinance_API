using System.Security.Cryptography;
using System.Text;

namespace AtosPersonalFinance_API.Services
{
    /// <summary>
    /// Classe que fornece métodos para encriptar senhas e verificar correspondência de senhas encriptadas.
    /// </summary>
    public class HashPassword
    {
        /// <summary>
        /// Encripta uma senha usando o algoritmo de hash SHA256.
        /// </summary>
        /// <param name="password">senha a ser encriptada.</param>
        /// <returns>A senha encriptada como uma string hexadecimal.</returns>
        public static string Encript(string password)
        {
            using var sha256 = SHA256.Create();
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] hashBytes = sha256.ComputeHash(passwordBytes);
            string hash = BitConverter.ToString(hashBytes).Replace("-", string.Empty);

            return hash;
        }

        /// <summary>
        /// Verifica se uma senha fornecida corresponde a uma senha encriptada.
        /// </summary>
        /// <param name="password">Senha a ser verificada.</param>
        /// <param name="hashedPassword">Senha encriptada a ser comparada.</param>
        /// <returns>True se as senhas corresponderem, False caso contrário.</returns>
        public static bool Verify(string password, string hashedPassword)
        {
            string hashedInput = Encript(password);

            bool passwordsMatch = string.Equals(
                hashedInput,
                hashedPassword,
                StringComparison.Ordinal
            );

            return passwordsMatch;
        }
    }
}
