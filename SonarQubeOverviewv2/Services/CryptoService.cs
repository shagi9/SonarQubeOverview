using System.Security.Cryptography;
using System.Text;

namespace SonarQubeOverviewv2.Services
{
    public class CryptoService
    {
        // 🔴 Vulnerability: weak cipher (DES)
        public byte[] EncryptLegacy(string text)
        {
            using var des = DES.Create();
            using var encryptor = des.CreateEncryptor();
            var bytes = Encoding.UTF8.GetBytes(text);
            return encryptor.TransformFinalBlock(bytes, 0, bytes.Length);
        }

        // 🔴 Vulnerability: insecure cipher mode (ECB)
        public byte[] EncryptEcb(string text)
        {
            using var aes = Aes.Create();
            aes.Mode = CipherMode.ECB;
            using var encryptor = aes.CreateEncryptor();
            var bytes = Encoding.UTF8.GetBytes(text);
            return encryptor.TransformFinalBlock(bytes, 0, bytes.Length);
        }

        // 🔴 Vulnerability: key too short (RSA 1024)
        public RSA CreateKey()
        {
            return RSA.Create(1024);
        }

        // 🟠 Security Hotspot: weak hashing (SHA1)
        public string Hash(string input)
        {
            return Convert.ToHexString(SHA1.HashData(Encoding.UTF8.GetBytes(input)));
        }

        // 🟠 Security Hotspot: non-cryptographic random for a one-time password
        public int NewOneTimePassword()
        {
            return new Random().Next(100000, 999999);
        }
    }
}
