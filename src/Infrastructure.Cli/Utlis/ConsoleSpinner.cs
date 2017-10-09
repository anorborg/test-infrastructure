using System;
using System.Diagnostics;
using System.Security;

namespace Infrastructure.Cli.Utils
{
    internal class ConsoleSpinner
    {
        private int counter = 0;

        public void Turn()
        {
            counter++;        
            switch (counter % 4)
            {
                case 0: Console.Write("/"); break;
                case 1: Console.Write("-"); break;
                case 2: Console.Write("\\"); break;
                case 3: Console.Write("-"); break;
            }
            Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
        }
    }
}