using System;
// Exceeding the requirements: The code can storage more than 1 scripture and every time it runs you get a random scripture

List<Scripture> scriptures = new List<Scripture>
{
    new Scripture(
        new Reference("John",3,16),
        "For God so loved the world that he gave his only begotten Son that whosoever believeth in him should not perish but have everlasting life."
    ),

    new Scripture(
        new Reference("Proverbs",3,5,6),
        "Trust in the Lord with all thine heart and lean not unto thine own understanding. In all thy ways acknowledge him and he shall direct thy paths."
    ),

    new Scripture(
        new Reference("Mosiah",2,17),
        "When ye are in the service of your fellow beings ye are only in the service of your God."
    )
};

Random random = new Random();
Scripture scripture = scriptures[random.Next(scriptures.Count)];

while (!scripture.IsCompletelyHidden())
{
    Console.Clear();
    Console.WriteLine(scripture.GetDisplayText());
    Console.WriteLine();
    Console.Write("Press Enter to continue or type 'quit': ");

    string input = Console.ReadLine();

    if (input.ToLower() == "quit")
        break;

    scripture.HideRandomWords(3);
}

Console.Clear();
Console.WriteLine(scripture.GetDisplayText());
Console.WriteLine();
Console.WriteLine("Goodbye!");