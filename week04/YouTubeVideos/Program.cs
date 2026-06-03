using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video
        {
            Title = "C# Basics",
            Author = "Code Academy",
            Length = 600
        };

        video1.Comments.Add(new Comment { Name = "John", Text = "Great video!" });
        video1.Comments.Add(new Comment { Name = "Sarah", Text = "Very helpful." });
        video1.Comments.Add(new Comment { Name = "Mike", Text = "Thanks for sharing." });

        Video video2 = new Video
        {
            Title = "Learn Lists",
            Author = "Programming Hub",
            Length = 450
        };

        video2.Comments.Add(new Comment { Name = "Anna", Text = "Easy to understand." });
        video2.Comments.Add(new Comment { Name = "Chris", Text = "Nice explanation." });
        video2.Comments.Add(new Comment { Name = "David", Text = "Good examples." });

        Video video3 = new Video
        {
            Title = "Object-Oriented Programming",
            Author = "Tech Tutorials",
            Length = 900
        };

        video3.Comments.Add(new Comment { Name = "Emma", Text = "Excellent lesson." });
        video3.Comments.Add(new Comment { Name = "James", Text = "Very informative." });
        video3.Comments.Add(new Comment { Name = "Olivia", Text = "Helped me a lot." });

        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.Length} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");

            Console.WriteLine("Comments:");
            foreach (Comment comment in video.Comments)
            {
                Console.WriteLine($"- {comment.Name}: {comment.Text}");
            }

            Console.WriteLine();
        }
    }
}