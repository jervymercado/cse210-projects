using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    public List<Entry> entries = new List<Entry>();

    public List<string> prompts = new List<string>
    {
        "What was the best part of your day?",
        "What did you learn today?",
        "Who did you talk to today?",
        "What was something good that happened today?",
        "What was something difficult today?"
    };

    public void AddEntry()
    {
        Random rand = new Random();
        string prompt = prompts[rand.Next(prompts.Count)];

        Console.WriteLine(prompt);
        Console.Write("> ");
        string response = Console.ReadLine();

        string date = DateTime.Now.ToShortDateString();

        Entry entry = new Entry(date, prompt, response);
        entries.Add(entry);
    }

    public void DisplayAll()
    {
        foreach (Entry e in entries)
        {
            Console.WriteLine(e.Display());
        }
    }

    public void Save(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (Entry e in entries)
            {
                writer.WriteLine(e.ToFileString());
            }
        }
    }

    public void Load(string filename)
    {
        entries.Clear();

        string[] lines = File.ReadAllLines(filename);

        foreach (string line in lines)
        {
            entries.Add(Entry.FromFileString(line));
        }
    }
}