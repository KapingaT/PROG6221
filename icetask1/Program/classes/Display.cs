using System;
using System.Collections.Generic;
using System.Text;

namespace poepart1.Program.classes
{
    internal class Display
    {
        public static void DisplayHeader()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("========================================");
            Console.WriteLine("       CYBERSECURITY AWARENESS BOT      ");
            Console.WriteLine("========================================");

            Console.WriteLine(@"
            .-''''-.
           /  .-.   \
          |  |   |  |
          |  |   |  |   
          |  |   |  |
          |  '---'  |
           \       /
            '-----'
        ");

            Console.ResetColor();
        }


    }
}
