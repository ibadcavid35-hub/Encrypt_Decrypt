using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encrypt_Decrypt.EncryptionDecryptionUsingSymmetricKey
{
    public static class FileOperations
    {
        public static void EncryptFileOperation()
        {
            try
            {
                Console.Write("Enter the full path of the file to be encrypted: ");
                string inputFilePath = Console.ReadLine();

                if (!File.Exists(inputFilePath))
                {
                    throw new FileNotFoundException("FILE NOT FOUND");
                }

                Console.Write("Enter the output path for the encrypted file: ");
                string outputFile = Console.ReadLine();
                string outputFilePath = $@"C:\Users\ibadc\OneDrive\Desktop\{outputFile}.txt";

                Console.Write("Enter the encryption key:(16 characters) ");
                string encryptionKey = Console.ReadLine();

                while (encryptionKey.Length != 16)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The encryption key must be 16 characters long!");
                    Console.ResetColor();
                    Console.Write("Enter the encryption key:(16 characters) ");
                    encryptionKey = Console.ReadLine();
                }

                if (Manage.Operations())
                {
                    AesOperation.EncryptFile(inputFilePath, outputFilePath,encryptionKey);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("File encrypted successfully!");
                    Console.ResetColor();
                    Console.ReadKey();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\u001b[31mERROR OCCURED: \u001b[0m{ex.Message}");
                Console.ReadKey();
            }
        }

        public static void DecryptFileOperation()
        {
            try
            {
                Console.Write("Enter the full path of the file to be decrypted: ");
                string inputFilePath = Console.ReadLine();

                if (!File.Exists(inputFilePath))
                {
                    throw new FileNotFoundException("FILE NOT FOUND");
                }

                Console.Write("Enter the output path for the decrypted file: ");
                string outputFile = Console.ReadLine();
                string outputFilePath = $@"C:\Users\ibadc\OneDrive\Desktop\{outputFile}.txt";

                Console.Write("Enter the decryption Key:(16 characters) ");
                string decryptionKey = Console.ReadLine();

                while (decryptionKey.Length != 16)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The decryption key must be 16 characters long!");
                    Console.ResetColor();
                    Console.Write("Enter the decryption key:(16 characters) ");
                    decryptionKey = Console.ReadLine();
                }

                if (Manage.Operations())
                {
                    AesOperation.DecryptFile(inputFilePath, outputFilePath,decryptionKey);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("File decrypted successfully!");
                    Console.ResetColor();
                    Console.ReadKey();
                }
            }
            catch (FileNotFoundException fne)
            {
                Console.WriteLine($"\u001b[31mERROR OCCURED:\u001b[0m {fne.Message}");
                Console.ReadKey();
            }
        }
    }
}
