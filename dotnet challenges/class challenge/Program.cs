// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using System;
using System.Threading;

class program {
    static void Main()
    {
        while (true)
        {
            Console.Write("Enter future time (HH:MM) or 'exit': ");
            string input = Console.ReadLine();
            if (input.ToLower() == "exit"){
                Console.WriteLine($"Exiting program...Goodbye!...");
                break;
            }

            if (!DateTime.TryParseExact(input, "HH:mm", null, System.Globalization.DateTimeStyles.None, out DateTime targetTime))
            {
                Console.WriteLine("Invalid format. Use HH:MM.");
                continue;
            }

            DateTime now = DateTime.Now; 
            if (targetTime < now)
            {
                Console.WriteLine("Time has already passed.");
                continue;
            }

            Countdown(targetTime - now);
        }
    }

    static void Countdown(TimeSpan remainingTime)
    {
        while (remainingTime.TotalSeconds > 0)
        {
            Console.Write($"Time left: {remainingTime.Minutes:D2}:{remainingTime.Seconds:D2}\r");
            Thread.Sleep(1000);
            remainingTime = remainingTime.Subtract(TimeSpan.FromSeconds(1));
        }
        Console.WriteLine("\nTime's up!");
    }
}
