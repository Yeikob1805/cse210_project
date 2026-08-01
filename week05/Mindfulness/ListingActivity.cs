public class ListingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _usedPrompts;
    private Random _random = new Random();

    public ListingActivity()
        : base(
            "Listing",
            "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        _usedPrompts = new List<string>();
    }

    public void Run()
    {
        StartActivity();

        Console.WriteLine("\nList as many responses as you can to the following prompt:\n");
        Console.WriteLine($"--- {GetRandomPrompt()} ---");

        Console.Write("\nYou may begin in: ");
        ShowCountdown(5);

        Console.WriteLine("\n");

        List<string> answers = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            answers.Add(Console.ReadLine());
        }

        Console.WriteLine($"\nYou listed {answers.Count} items.");

        EndActivity();
    }

    private string GetRandomPrompt()
    {
        if (_usedPrompts.Count == _prompts.Count) _usedPrompts.Clear();

        string prompt;

        do
        {
            prompt = _prompts[_random.Next(_prompts.Count)];
        }
        while (_usedPrompts.Contains(prompt));

        _usedPrompts.Add(prompt);
        return prompt;
    }
}