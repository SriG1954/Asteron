using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AppCoreV1.Helper
{
    public class AESSecurity
    {
        static string key = "21AABD1D5284AF9140A4D1584CA2BAA6";

        public static string Encrypt(string plainText)
        {
            using var aes = Aes.Create();
            aes.Key = Encoding.UTF8.GetBytes(key);
            aes.GenerateIV();

            using var encryptor = aes.CreateEncryptor();
            using var memoryStream = new MemoryStream();
            using var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);

            var plainBytes = Encoding.UTF8.GetBytes(plainText);
            cryptoStream.Write(plainBytes, 0, plainBytes.Length);
            cryptoStream.FlushFinalBlock();

            var encryptedBytes = memoryStream.ToArray();
            return Convert.ToBase64String(aes.IV.Concat(encryptedBytes).ToArray());
        }

        public static string Decrypt(string encryptedText)
        {
            var encryptedBytes = Convert.FromBase64String(encryptedText);
            using var aes = Aes.Create();
            aes.Key = Encoding.UTF8.GetBytes(key);
            aes.IV = encryptedBytes.Take(16).ToArray(); // Extract IV from the first 16 bytes

            using var decryptor = aes.CreateDecryptor();
            using var memoryStream = new MemoryStream(encryptedBytes, 16, encryptedBytes.Length - 16);
            using var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);

            using var reader = new StreamReader(cryptoStream);
            return reader.ReadToEnd();
        }
    }
}
