using System;
using System.Collections.Generic;
using System.Text;

namespace poepart1.Program.classes
{
    internal class Conversation
    {
     // this is the behind the scenes where were based on the what the user asks the bot she knows how to resond 
        public static string GetResponse(string input, string userName) //gets the users name that we stored 
        {
            input = input.ToLower();
            // convertts  into small letters 

            switch (input) // the chatbot goes through all of these different choices to see wheter you question lines up to one of the following
                // and will give you an answer based on
            {//here are all the possible questions that the ways the peopl
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

