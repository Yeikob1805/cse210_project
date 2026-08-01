using System;

// To shw the creativity expectation I added something on the Reflection Activity so the questions are always shown in a random order 
// and are not repeated during the same session. I also adjusted the time automatically. 
// If the user chooses 90 seconds or less, the program selects only the number of questions needed and divides the time between them. 
// If the user chooses more than 90 seconds, it uses all the questions and distributes the time evenly so 
// the activity lasts as long as the user requested.

bool running = true;

while (running)
{
    Console.Clear();
    Console.WriteLine("Menu Options:");
    Console.WriteLine("  1. Start breathing activity");
    Console.WriteLine("  2. Start reflecting activity");
    Console.WriteLine("  3. Start listing activity");
    Console.WriteLine("  4. Quit");
    Console.Write("Select a choice from the menu: ");

    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            new BreathingActivity().Run();
            break;

        case "2":
            new ReflectingActivity().Run();
            break;

        case "3":
            new ListingActivity().Run();
            break;

        case "4":
            running = false;
            break;

        default:
            Console.WriteLine("Invalid option.");
            Thread.Sleep(1500);
            break;
    }
}