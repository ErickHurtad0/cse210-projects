using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Video video1 = new Video("Learning C#", "CodeMaster", 600);
        Video video2 = new Video("Basketball Tricks", "HoopKing", 420);
        Video video3 = new Video("Guitar Basics", "StringPro", 900);

        video1.AddComment(new Comment("Ana", "This helped a lot!"));
        video1.AddComment(new Comment("Luis", "Very clear explanation."));
        video1.AddComment(new Comment("Mia", "Loved it!"));

        video2.AddComment(new Comment("Carlos", "Awesome moves!"));
        video2.AddComment(new Comment("Jorge", "Trying this today."));
        video2.AddComment(new Comment("Sofia", "So cool!"));

        video3.AddComment(new Comment("Daniel", "Great for beginners."));
        video3.AddComment(new Comment("Laura", "Nice pacing."));
        video3.AddComment(new Comment("Emma", "More videos please!"));

        List<Video> videos = new List<Video>
        {
            video1, video2, video3
        };

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.Length} seconds");
            Console.WriteLine($"Number of comments: {video.GetNumberOfComments()}");

            Console.WriteLine("Comments:");
            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"- {comment.Name}: {comment.Text}");
            }

            Console.WriteLine();
        }
    }
}

