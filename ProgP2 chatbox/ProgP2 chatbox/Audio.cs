using System;
using System.Collections.Generic;
using System.Media;
using System.Text;

namespace poepart1.Program.classes
{
    internal class Audio
    {
        //checks if the user’s input is valid ( not empty or just spaces that something has been typed out ).
        public static bool IsValidInput(string input)
        {
            return !string.IsNullOrWhiteSpace(input);
        }

        public static void PlayGreeting()// the method used to create play the voice recording 
        {// inside we have the lace where we will find the voice recording that greets the users the direct path 
            try
            {
             
            }
            catch
            {
                Console.WriteLine("(Audio isnt playing)");
            }
        }
    }
}

