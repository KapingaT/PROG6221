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
                case "what is malware":
                    return "Malware is harmful software designed to damage or steal information from your computer.";

                case "what is a virus":
                    return "A virus is a type of malware that spreads from one computer to another and can damage files.";

                case "what is ransomware":
                    return "Ransomware is a type of attack where your files are locked and you must pay money to get them back.";

                case "what is spyware":
                    return "Spyware is software that secretly collects your personal information without your permission.";

                case "what is a firewall":
                    return "A firewall protects your computer by blocking unwanted or harmful traffic from the internet.";

                case "what is two factor authentication":
                    return "Two-factor authentication adds extra security by requiring a second step, like a code sent to your phone.";

                case "why is cybersecurity important":
                    return "Cybersecurity is important because it protects your personal information and keeps your data safe from hackers.";

                case "how do i stay safe online":
                    return "Avoid suspicious links, use strong passwords, and never share personal information online.";

                case "what is identity theft":
                    return "Identity theft is when someone steals your personal information and uses it without your permission.";

                case "how do i know if an email is fake":
                    return "Check for spelling mistakes, strange links, and unknown senders. Do not click on suspicious emails.";

                case "what is social engineering":
                    return "Social engineering is when attackers trick people into giving away confidential information.";

                case "what is a secure website":
                    return "A secure website starts with https and has a padlock icon in the address bar.";

                case "what should i do if i get hacked":
                    return "Change your passwords immediately and report the issue to the relevant service provider.";

                case "can i use the same password":
                    return "No, using the same password is risky. Use different passwords for each account.";

                case "what is a data breach":
                    return "A data breach happens when sensitive information is accessed or stolen by unauthorized people.";

                case "how often should i change my password":
                    return "You should change your password regularly, especially if you suspect any suspicious activity.";

                case "what is antivirus":
                    return "Antivirus software helps detect and remove harmful programs from your computer.";

                case "is public wifi safe":
                    return "Public WiFi is not always safe. Avoid accessing sensitive information when using it.";

                case "what are strong passwords":
                    return "Strong passwords include a mix of uppercase, lowercase, numbers, and symbols.";

                case "what is encryption":
                    return "Encryption protects your data by turning it into unreadable code that only authorized users can access.";
                case "bye":
                    return "Goodbye " + userName + "! Stay safe online.";

                default:
                    return "I didn’t understand that. Try asking about cybersecurity topics like phishing or passwords or hacked";
            }
        }
    }


}

