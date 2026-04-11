using System;

namespace poepart1.Program.classes
{
    internal class Chatbox
    {
        // ✔ Store name in class variable
        private string userName;

        // ✔ Renamed method
        public void GetName()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("==================================");
            Console.WriteLine("        CHATBOX SYSTEM");
            Console.WriteLine("==================================");

            Console.ResetColor();

            Console.Write("\nEnter your name: ");
            userName = Console.ReadLine();

            // ✔ Improved error message
            while (string.IsNullOrWhiteSpace(userName))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" Name cannot be empty. Please try again.");
                Console.ResetColor();

                Console.Write("Enter your name: ");
                userName = Console.ReadLine();
            }

            // ✔ Welcome message
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nWelcome, {userName}!");
            Console.WriteLine("Type 'exit' to quit the chat.\n");
            Console.ResetColor();

            // ✔ Chat loop being called 
            StartChat();
        }

        private void StartChat()
        {// method that explains what exactly chat is doing 
            string message;

            do
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"{userName}: ");
                Console.ResetColor();

                message = Console.ReadLine();

                // ✔ Connect to response system
                string response = GenerateResponse(message);

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"Bot: {response}");
                Console.ResetColor();

            } while (message.ToLower() != "exit");

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\nChat ended. Goodbye ");
            Console.ResetColor();
        }

        private string GenerateResponse(string input)
        {
            input = input.ToLower();

            if (input.Contains("hello") || input.Contains("hi")||input.Contains("hey"))
            {
                return "Hey,there how can i help";
            }
            else if (input.Contains("how are you")||input.Contains("how you feeling "   ))
            {
                return "I'm exicited  that i get to talk to you ";
            }
            else if (input.Contains("help")) 
            {
                return "what is it you need help with";
            
            }
            else if (input.Contains("name")||input.Contains("do you know my name"))
            {
                return $"Your name is {userName}, right?";
            }
            else if (input == "exit")
            {
                return "Goodbye!";
            }
            else
            {
                return "I don't understand that yet ";
            }
        }
    }
}