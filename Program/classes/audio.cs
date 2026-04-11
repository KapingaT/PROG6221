using System;
using System.Collections.Generic;
using System.Media;
using System.Text;

namespace poepart1.Program.classes
{
    internal class Audio
    {
     
        public static bool IsValidInput(string input)
        {
            return !string.IsNullOrWhiteSpace(input);
        }

        public static void PlayGreeting()
        {
            try
            {
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"voicegreeting","C:\\Users\\HP\\source\\repos\\icetask1\\icetask1\\voicegreeting\\WhatsApp Audio 2026-04-07 at 19.30.19 voice chatbox.wav");
                SoundPlayer player = new SoundPlayer(path);
                player.Play();
            }
            catch
            {
                Console.WriteLine("(Audio isnt playing)");
            }
        }
    }
}

