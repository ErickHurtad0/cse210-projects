using System;
using System.Collections.Generic;

public class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience?",
        "What did you learn about yourself?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectingActivity()
        : base(
            "Reflection Activity",
            "This activity will help you reflect on times in your life when you have shown strength and resilience."
          )
    { }

    public override void Run()
    {
        DisplayStartingMessage();

        Shuffle(_prompts);
        Shuffle(_questions);

        Console.WriteLine("\nPrompt:");
        Console.WriteLine($"--- {_prompts[0]} ---");
        Console.WriteLine("\nWhen you are ready, ponder each of the following questions:");
        ShowSpinner(5);

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        int index = 0;

        while (DateTime.Now < endTime)
        {
            Console.WriteLine();
            Console.WriteLine(_questions[index % _questions.Count]);
            index++;

            Console.Write("> ");
            ShowCountDown(10);
        }

        DisplayEndingMessage();
    }


    private void Shuffle(List<string> list)
    {
        Random rand = new Random();
        for (int i = list.Count - 1; i > 0; i--)
        {
            int j = rand.Next(i + 1);
            (list[i], list[j]) = (list[j], list[i]);
        }
    }
}
