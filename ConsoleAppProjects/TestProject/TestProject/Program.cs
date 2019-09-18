using System;

// Namespace of file
namespace TestProject
{
    // Main Class
    class Program
    {
        // Entry Point Method
        static void Main(string[] args)
        {
            Console.WriteLine("What is your name?");
            string userInput = Console.ReadLine();
            string name = userInput;
            DateTime today = DateTime.Today;
            Console.WriteLine("Hello World! It's nice to meet you, {0}\nToday is {1}", userInput ,today.ToString());
        }
    }
}
