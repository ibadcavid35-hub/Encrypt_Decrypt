using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encrypt_Decrypt.EncryptionDecryptionUsingSymmetricKey
{
    public static class Manage
    {
        public static bool Operations()
        {
            bool isPaused = false;

            for (int l = 0; l <= 100; l = l + 3)
            {
                while (Console.KeyAvailable || isPaused)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                    if (keyInfo.Key == ConsoleKey.Escape)
                    {
                        Console.WriteLine();

                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("ABORTED");
                        Console.ResetColor();

                        return false;
                    }
                    else if (keyInfo.Key == ConsoleKey.Spacebar)
                    {
                        isPaused = !isPaused;

                        if (isPaused)
                        {
                            Console.WriteLine();

                            Console.Write($"\u001b[32mLOADING: \u001b[0m {l} %");

                            Console.BackgroundColor = ConsoleColor.DarkRed;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine(" SUSPEND");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.Write($"\u001b[32mLOADING: \u001b[0m {l} %");

                            Console.BackgroundColor = ConsoleColor.DarkYellow;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine(" RESUMED");
                            Console.ResetColor();
                        }
                    }
                }

                Console.Write($"\r\u001b[32mLOADING: \u001b[0m{l} %");

                Thread.Sleep(400);
            }

            Console.WriteLine();

            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("LOADING COMPLETED");
            Console.ResetColor();

            return true;
        }
    }
}