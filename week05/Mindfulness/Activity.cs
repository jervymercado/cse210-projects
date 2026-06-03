using System;
using System.Threading;

class Activity
{
    private string _name;
    private string _description;
    private int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void Run()
    {
        StartMessage();
        DoActivity();
        EndMessage();
    }

    protected virtual void DoActivity()
    {

    }

    private void StartMessage()
    {
        Console.Clear();
        Console.WriteLine($"--- {_name} ---");
        Console.WriteLine(_description);
        Console.Write("\nEnter duration in seconds: ");
        _duration = int.Parse(Console.ReadLine());

        Console.WriteLine("\nGet ready...");
        Spinner(3);
    }

    private void EndMessage()
    {
        Console.WriteLine("\nWell done!");
        Spinner(2);
        Console.WriteLine($"You completed {_name} for {_duration} seconds.");
        Spinner(3);
    }

    protected int GetDuration()
    {
        return _duration;
    }

    protected void Countdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    protected void Spinner(int seconds)
    {
        string[] spin = { "|", "/", "-", "\\" };
        DateTime end = DateTime.Now.AddSeconds(seconds);

        int i = 0;
        while (DateTime.Now < end)
        {
            Console.Write(spin[i % spin.Length]);
            Thread.Sleep(200);
            Console.Write("\b");
            i++;
        }
    }
}