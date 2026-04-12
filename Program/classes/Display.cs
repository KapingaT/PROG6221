using System;
using System.Collections.Generic;
using System.Text;

namespace poepart1.Program.classes
{
    internal class Display
    {
        public static void DisplayHeader()
            // this is the design of the chatbot we going to see it 
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("========================================");
            Console.WriteLine("       CYBERSECURITY AWARENESS BOT      ");
            Console.WriteLine("========================================");
            //this is the image i have created using the acsii art
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
