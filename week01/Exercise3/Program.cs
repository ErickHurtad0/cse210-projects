using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int number = randomGenerator.Next(1, 100);

        Console.WriteLine("~ Welcome to Guess the Word! ~");

        int attempt = 1;

        for (int i = 0; i < 20; i++)
        {
            Console.Write("What is your Guess? ");
            string response = Console.ReadLine();
            int guess = int.Parse(response);

            if (guess > number)
            {
                Console.WriteLine("Lower");
            }
            else if (guess < number)
            {
                Console.WriteLine("Higher");
            }
            else
            {
                Console.WriteLine("Congrats, that is correct!");
                Console.WriteLine($"It took you {attempt} attempts!");
                break;
            }

            attempt ++;
        }
    }
}