using System;

class ReflectionActivity : Activity
{
    private string[] prompts =
    {
        "Think of a time you stood up for someone.",
        "Think of a time you did something difficult.",
        "Think of a time you helped someone in need.",
        "Think of a time you did something selfless."
    };

    private string[] questions =
    {
        "Why was this meaningful?",
        "What did you learn from it?",
        "How did you feel?",
        "What made it special?",
        "How can you use this experience in the future?"
    };

    public ReflectionActivity()
        : base("Reflection Activity",
        "This activity helps you reflect on moments of strength and resilience.")
    {
    }

    protected override void DoActivity()
    {
        Random rand = new Random();

        Console.WriteLine("\nPrompt:");
        Console.WriteLine(prompts[rand.Next(prompts.Length)]);
        Console.WriteLine("\nThink about it...");
        Spinner(3);

        int time = GetDuration();
        DateTime end = DateTime.Now.AddSeconds(time);

        while (DateTime.Now < end)
        {
            Console.WriteLine("\n" + questions[rand.Next(questions.Length)]);
            Spinner(3);
        }
    }
}