using System;

// On my code I added the option of searching something that was written on the journal, it can be key words or dates.

Journal journal = new Journal();
bool running = true;

while (running)
{
    Console.WriteLine();
    Console.WriteLine("Journal Menu");
    Console.WriteLine("1. Write");
    Console.WriteLine("2. Display");
    Console.WriteLine("3. Save");
    Console.WriteLine("4. Load");
    Console.WriteLine("5. Search");
    Console.WriteLine("6. Quit");
    Console.Write("Choose an option: ");

    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            journal.AddEntry();
            break;

        case "2":
            journal.DisplayEntries();
            break;

        case "3":
            Console.Write("Filename: ");
            journal.SaveToFile(Console.ReadLine());
            break;

        case "4":
            Console.Write("Filename: ");
            journal.LoadFromFile(Console.ReadLine());
            break;

        case "5":
            Console.Write("Search: ");
            journal.SearchEntries(Console.ReadLine());
            break;

        case "6":
            running = false;
            break;

        default:
            Console.WriteLine("Invalid option.");
            break;
    }
}