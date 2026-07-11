using System.IO;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();
    private PromptGenerator _promptGenerator = new PromptGenerator();

    public void AddEntry()
    {
        string prompt = _promptGenerator.GetRandomPrompt();

        Console.WriteLine();
        Console.WriteLine(prompt);
        Console.Write("> ");

        string response = Console.ReadLine();
        string date = DateTime.Now.ToShortDateString();

        _entries.Add(new Entry(date, prompt, response));
        Console.WriteLine("Entry added.");
    }

    public void DisplayEntries()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("The journal is empty.");
            return;
        }

        Console.WriteLine();

        foreach (Entry entry in _entries)
            entry.Display();
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter output = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
                output.WriteLine(entry.ToFileString());
        }

        Console.WriteLine("Journal saved.");
    }

    public void LoadFromFile(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        _entries.Clear();

        foreach (string line in File.ReadAllLines(filename))
        {
            string[] parts = line.Split(' | ');

            if (parts.Length == 3)
                _entries.Add(new Entry(parts[0], parts[1], parts[2]));
        }

        Console.WriteLine("Journal loaded.");
    }

    public void SearchEntries(string text)
    {
        bool found = false;

        foreach (Entry entry in _entries)
        {
            if (entry.Date.Contains(text, StringComparison.OrdinalIgnoreCase) ||
                entry.Prompt.Contains(text, StringComparison.OrdinalIgnoreCase) ||
                entry.Response.Contains(text, StringComparison.OrdinalIgnoreCase))
            {
                entry.Display();
                found = true;
            }
        }

        if (!found)
            Console.WriteLine("No matching entries found.");
    }
}