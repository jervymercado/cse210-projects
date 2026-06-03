using System;

class ListingActivity : Activity
{
    private string[] prompts =
    {
        "List people you appreciate.",
        "List your personal strengths.",
        "List people you helped recently.",
        "List your personal heroes."
    };

    public ListingActivity()
        : base("Listing Activity",
        "This activity helps you list positive things in your life.")
    {
    }

    protected override void DoActivity()
    {
        Random rand = new Random();

        Console.WriteLine("\nPrompt:");
        Console.WriteLine(prompts[rand.Next(prompts.Length)]);

        Console.WriteLine("\nYou may begin listing...");
        Countdown(5);

        int count = 0;
        int time = GetDuration();
        DateTime end = DateTime.Now.AddSeconds(time);

        while (DateTime.Now < end)
        {
            Console.Write("> ");
            if (!string.IsNullOrWhiteSpace(Console.ReadLine()))
                count++;
        }

        Console.WriteLine($"\nYou listed {count} items.");
    }
}