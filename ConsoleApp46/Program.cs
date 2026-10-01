using System.Security.Cryptography;
using System.Text;

namespace ConsoleApp46
{
    internal class Program
    {

        static void Main(string[] args)
        {
            List<string> options = new List<string>() { "Encrypt", "Decrypt", "Exit" };
            int select = 0;
            bool isRun = true;

            while (isRun)
            {
                Console.Clear();

                for (int i = 0; i < options.Count; i++)
                {
                    if (select == i)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine($">>  {options[i]}");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine($"    {options[i]}");
                    }
                }

                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.UpArrow)
                {
                    select--;

                    if (select < 0)
                    {
                        select = options.Count - 1;
                    }
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    select++;

                    if (select >= options.Count)
                    {
                        select = 0;
                    }
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    if (select == 2)
                    {
                        isRun = false;
                        break;
                    }
                    else if (select == 0)
                    {
                        //Encrypt();
                    }
                    else if (select == 1)
                    {
                        //Decrypt();
                    }
                }
            }
        }


        public static string EncryptString(string key, string plainText)
        {
            byte[] iv = new byte[16];
            byte[] array;

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                        {
                            streamWriter.Write(plainText);
                        }

                        array = memoryStream.ToArray();
                    }
                }
            }
            return Convert.ToBase64String(array);
        }


        public static string DecryptString(string key, string cipherText)
        {
            byte[] iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(cipherText);

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}
