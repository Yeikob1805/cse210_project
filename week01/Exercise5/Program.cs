using System;

class Program
{
    static void Main(string[] args)
    {
        WelcomeMessage();

        string userName = UserName();
        int userNumber = UserNumber();

        int squaredNumber = SquareNumber(userNumber);

        Display(userName, squaredNumber);
    }

    static void WelcomeMessage()
    {
        Console.WriteLine("Welcome to the program!");
    }

    static string UserName()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();

        return name;
    }

    static int UserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        int number = int.Parse(Console.ReadLine());

        return number;
    }

    static int SquareNumber(int number)
    {
        int square = number * number;
        return square;
    }

    static void Display(string name, int square)
    {
        Console.WriteLine($"{name}, the square of your number is {square}");
    }
}