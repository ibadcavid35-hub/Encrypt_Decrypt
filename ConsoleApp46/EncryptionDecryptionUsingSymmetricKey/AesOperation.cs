using System.Security.Cryptography;
using System.Text;

namespace Encrypt_Decrypt.EncryptionDecryptionUsingSymmetricKey
{
    public static class AesOperation
    {
        public static void EncryptFile(string inputFile, string outputFile, string key)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            byte[] iv = new byte[16];

            using (Aes aes = Aes.Create())
            {
                aes.Key = keyBytes;
                aes.IV = iv;

                using (FileStream input = new FileStream(inputFile, FileMode.Open))
                using (FileStream output = new FileStream(outputFile, FileMode.Create))
                using (CryptoStream cryptoStream = new CryptoStream(output, aes.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    byte[] buffer = new byte[1024];
                    int read;

                    while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        cryptoStream.Write(buffer, 0, read);
                    }
                }
            }
        }


        public static void DecryptFile(string inputFile, string outputFile, string key)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            byte[] iv = new byte[16];

            using (Aes aes = Aes.Create())
            {
                aes.Key = keyBytes;
                aes.IV = iv;

                using (FileStream input = new FileStream(inputFile, FileMode.Open))
                using (FileStream output = new FileStream(outputFile, FileMode.Create))
                using (CryptoStream cryptoStream = new CryptoStream(output, aes.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    byte[] buffer = new byte[1024];
                    int read;

                    while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        cryptoStream.Write(buffer, 0, read);
                    }
                }
            }
        }
    }
}
