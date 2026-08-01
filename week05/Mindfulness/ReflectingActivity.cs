public class ReflectingActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;
    private Random _random = Random.Shared;

    public ReflectingActivity()
        : base(
            "Reflecting",
            "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
        _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };
    }

    public void Run()
    {
        StartActivity();

        Console.WriteLine("\nConsider the following prompt:\n");
        Console.WriteLine($"--- {GetRandomPrompt()} ---");

        Console.WriteLine("\nWhen you have something in mind, press Enter to continue.");
        Console.ReadLine();

        Console.WriteLine("\nNow ponder on each of the following questions:");

        List<string> questions = GetShuffledQuestions();

        int duration = GetDuration();
        int questionCount;
        double secondsPerQuestion;

        if (duration <= _questions.Count * 10)
        {
            questionCount = Math.Max(1, (int)Math.Ceiling(duration / 10.0));
            secondsPerQuestion = (double)duration / questionCount;
        }
        else
        {
            questionCount = _questions.Count;
            secondsPerQuestion = (double)duration / questionCount;
        }

        for (int i = 0; i < questionCount; i++)
        {
            Console.Write($"\n> {questions[i]} ");
            ShowSpinner((int)Math.Round(secondsPerQuestion));
        }

        EndActivity();
    }

    private string GetRandomPrompt()
    {
        return _prompts[_random.Next(_prompts.Count)];
    }

    private List<string> GetShuffledQuestions()
    {
        List<string> shuffled = new List<string>(_questions);

        for (int i = shuffled.Count - 1; i > 0; i--)
        {
            int j = _random.Next(i + 1);
            (shuffled[i], shuffled[j]) = (shuffled[j], shuffled[i]);
        }

        return shuffled;
    }
}