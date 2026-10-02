using Encrypt_Decrypt.EncryptionDecryptionUsingSymmetricKey;

namespace Encrypt_Decrypt
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
                    Console.Clear();
                    if (select == 2)
                    {
                        isRun = false;
                        break;
                    }
                    else if (select == 0)
                    {
                        Console.BackgroundColor= ConsoleColor.DarkGreen;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("ENCRYPT OPERATION");
                        Console.ResetColor();
                        Console.WriteLine();
                        FileOperations.EncryptFileOperation();
                    }
                    else if (select == 1)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("DECRYPT OPERATION");
                        Console.ResetColor();
                        Console.WriteLine();
                        FileOperations.DecryptFileOperation();
                 
                    }
                }
            }
        }
    }
}