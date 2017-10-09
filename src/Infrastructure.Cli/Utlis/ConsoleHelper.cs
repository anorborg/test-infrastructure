using System;
using System.Diagnostics;
using System.Security;
using System.Threading;

namespace Infrastructure.Cli.Utils
{
    public static class ConsoleHelper
    {
        public static void SpinUntil(int spinMilliseconds)
        {
            SpinUntil(() => true, spinMilliseconds);
        }

        public static void SpinUntil(Func<bool> checkForComplete, int minSpinMilliseconds = 0)
        {
            var s = new Stopwatch();

            s.Start();
            
            var spinner = new ConsoleSpinner();

            while(!checkForComplete() || s.ElapsedMilliseconds < minSpinMilliseconds)
            {
                for(int i = 0; i < 4; i++)
                {
                    Thread.Sleep(100);
                    spinner.Turn();
                }
            }
        }

        public static SecureString ReadSecureLine()
        {
            ConsoleKeyInfo key;
            var secureString = new SecureString();

            while (true)
            {
                key = Console.ReadKey(true);

                if (key.KeyChar == -1) break;
                if (key.Key == ConsoleKey.Enter) 
                {
                    secureString.MakeReadOnly();
                    return secureString;
                }

                if (key.Key == ConsoleKey.Backspace && secureString.Length > 0)
                {
                    secureString.RemoveAt(secureString.Length - 1);
                    Console.Write("\b \b");
                }
                else
                {
                    secureString.AppendChar(key.KeyChar);
                    Console.Write("*");
                }
            }
            if (key.KeyChar >= 0 && secureString.Length > 0) return secureString;
            return null;
        }
    }
}
