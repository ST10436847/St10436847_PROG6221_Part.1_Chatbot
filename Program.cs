using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Threading;
using NAudio.Wave;

namespace St10436847_PROG6221_Part._1_Chatbot
{
    class Program
    {
        static void Main()
        {
            Console.Title = "Cybersecurity Awareness Bot"; // Set console title

            // Voice greeting
            PlayGreeting();
            
            // Display ASCII 
            DisplayAsciiLogo();

            // Welcome message
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nWelcome to the Cybersecurity Awareness Bot!\n");
            Console.ResetColor();

            // Ask for user name
            Console.Write("Enter your name: ");
            string name = Console.ReadLine()?.Trim();

            if (string.IsNullOrEmpty(name))
            {
                name = "User";
            }

            Console.WriteLine($"\nHello, {name}! How can I assist you today?\n");

            // Chatbot loop
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\nYou: ");
                Console.ResetColor();
                string userInput = Console.ReadLine()?.Trim().ToLower();

                if (string.IsNullOrEmpty(userInput))
                {
                    Console.WriteLine("Please enter a valid question.");
                    continue;
                }

                if (userInput == "exit" || userInput == "quit")
                {
                    Console.WriteLine("Goodbye! Stay safe online.");
                    break;
                }

                // Response system
                RespondToUser(userInput);
            }
        }

        static void PlayGreeting()
        {
            try
            {
                string filePath = "greeting.wav"; // Ensure this file is in the project directory
                if (System.IO.File.Exists(filePath))
                {
                    SoundPlayer player = new SoundPlayer(filePath);
                    player.PlaySync();
                }
                else
                {
                    Console.WriteLine("Voice greeting file not found. Skipping audio...");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error playing greeting: " + ex.Message);
            }
        }

        static void DisplayAsciiLogo()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(@"
         ██████╗██╗   ██╗██████╗ ███████╗██████╗ 
        ██╔════╝██║   ██║██╔══██╗██╔════╝██╔══██╗
        ██║     ██║   ██║██████╔╝█████╗  ██████╔╝
        ██║     ██║   ██║██╔══██╗██╔══╝  ██╔═══╝ 
        ╚██████╗╚██████╔╝██████╔╝███████╗██║     
         ╚═════╝ ╚═════╝ ╚═════╝ ╚══════╝╚═╝
        ");
            Console.ResetColor();
        }

        static void RespondToUser(string input)
        {
            switch (input)
            {
                case "how are you?":
                    PrintWithTypingEffect("I'm just a bot, but I'm here to help!");
                    break;
                case "what's your purpose?":
                    PrintWithTypingEffect("I provide cybersecurity tips and answer your security-related questions.");
                    break;
                case "what can i ask you about?":
                    PrintWithTypingEffect("You can ask about password safety, phishing, and safe browsing.");
                    break;
                case "password safety":
                    PrintWithTypingEffect("Use a mix of letters, numbers, and symbols. Avoid using common words.");
                    break;
                case "phishing":
                    PrintWithTypingEffect("Be cautious of emails or messages asking for personal details. Always verify sources.");
                    break;
                case "safe browsing":
                    PrintWithTypingEffect("Use HTTPS sites, avoid clicking suspicious links, and keep your software updated.");
                    break;
                default:
                    PrintWithTypingEffect("I didn't quite understand that. Could you rephrase?");
                    break;
            }
        }

        static void PrintWithTypingEffect(string message)
        {
            foreach (char c in message)
            {
                Console.Write(c);
                Thread.Sleep(50); // Simulate typing effect
            }
            Console.WriteLine();
        }


    }
}
