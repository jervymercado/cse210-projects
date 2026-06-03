using System;
using System.Threading;

class BreathingActivity : Activity
{
    public BreathingActivity()
        : base("Breathing Activity",
        "This activity helps you relax by guiding you through slow breathing.")
    {
    }

    protected override void DoActivity()
    {
        int time = GetDuration();
        DateTime end = DateTime.Now.AddSeconds(time);

        while (DateTime.Now < end)
        {
            Console.Write("\nBreathe in...");
            Countdown(4);

            Console.Write("\nBreathe out...");
            Countdown(4);
        }
    }
}