using System;

namespace Gallows
{
    class Program
    {
        static void Main(string[] args)
        {
            char enteredLetter;
            bool isCorrectInput;
            GallowsGame game = new GallowsGame();
            Console.WriteLine(game.GetStartString());
            while (!game.IsAttemptsEnded() && !game.IsWordGuessed())
            {
                Console.WriteLine($"You have {game.NumberOfAtempts - game.NumberOfErrors} attempts.");
                do
                {
                    Console.Write("Enter letter: ");
                    string enteredString = Console.ReadLine();
                    enteredLetter = enteredString.ToLower().ToCharArray()[0];
                    isCorrectInput = enteredString.Length == 1 && (enteredLetter >= 'а') && (enteredLetter <= 'я');
                    if (!isCorrectInput)
                        Console.WriteLine("Use cyrillic letter!");
                }
                while (!isCorrectInput);
                Console.WriteLine(game.MakeMove(enteredLetter));
            }
            Console.WriteLine(game.IsWordGuessed() ? "\nYou won!" : $"\nYou lose! Word was {game.WordForGame}. Number of errors = {game.NumberOfErrors}");
        }
    }
}
