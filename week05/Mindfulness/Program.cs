using System;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");
            Console.Write("Select an option: ");

            string choice = Console.ReadLine();

            Activity activity = null;

            if (choice == "1")
                activity = new BreathingActivity();
            else if (choice == "2")
                activity = new ReflectionActivity();
            else if (choice == "3")
                activity = new ListingActivity();
            else if (choice == "4")
                break;

            if (activity != null)
                activity.Run();
        }
    }
}