using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your first name? ");
        String first = Console.ReadLine();
        
        Console.Write("What is your last name? ");
        String second = Console.ReadLine();

        Console.Write($"Your name is {second}, {first} {second}");
    }
}