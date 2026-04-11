using poepart1.Program.classes;
using System;

class Program
{
    static void Main(string[] args)
    {
        // 1. Display header
        // ✔ Show display first
        Display.DisplayHeader();

        // ✔ Play voice first
        Audio.PlayGreeting();

        // ✔ Start chatbot
        Chatbox chat = new Chatbox();
        chat.GetName();

        Console.ReadLine();


        
    }
}