using System;
using System.Collections.Generic;
using System.Text;

namespace poepart1.Program.classes
{
    internal class Conversation
    {
     
        public static string GetResponse(string input, string userName)
        {
            input = input.ToLower();
            //

            switch (input)
            {
                case "hello":
                case "hi":
                case "hey":
                    return "Hello " + userName + "! How can I assist you today?";

                case "how are you":
               case "how you feeling":
                    return "I happy that you are here learning how to be  stay safe online!";

                case "what is phishing":
                    return "Phishing is when attackers trick you into giving personal information through fake emails or websites.";

                case "password safety":
                    return "Use strong passwords with letters, numbers, and special characters . Never share your password. eg One23!";

                case "safe browsing":
                    return "Always check website URLs and avoid clicking suspicious links .";

                case "bye":
                    return "Goodbye " + userName + "! Stay safe online.";

                default:
                    return "I didn’t understand that. Try asking about cybersecurity topics like phishing or passwords.";
            }
        }
    }


}

