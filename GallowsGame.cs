using System;
using System.IO;
using System.Linq;

namespace Gallows
{
    class GallowsGame
    {
        public int NumberOfAtempts { get; }
        public int NumberOfErrors { get; private set; }
        public string WordForGame { get; private set; }

        private readonly char[] wordForGame;
        private readonly char[] currentString;
        private readonly string fileName;

        public GallowsGame(int numberOfAtempts = 6, string fileName = "WordsStockRus.txt")
        {
            NumberOfAtempts = numberOfAtempts;
            NumberOfErrors = 0;
            this.fileName = fileName;
            GenerateWordForGame();
            wordForGame = WordForGame.ToCharArray();
            currentString = GetStartString();            
        }

        public string MakeMove(char letter)
        {
            if (wordForGame.Contains(letter))
            {
                for (int i = 0; i < currentString.Length; i++)
                    if (wordForGame[i] == letter)
                        currentString[i] = letter;
            }
            else
                NumberOfErrors++;

            return new string(currentString);
        }

        public bool IsAttemptsEnded()
        {
            return (NumberOfErrors >= NumberOfAtempts);
        }

        public bool IsWordGuessed()
        {
            string currentWord = new string(currentString);
            return currentWord.Equals(WordForGame);
        }

        public char[] GetStartString()
        {
            int lenght = wordForGame.Length;
            char[] startString = new char[lenght];
            for (int i = 0; i < lenght; i++)
                startString[i] = '-';

            return startString;
        }

        private void GenerateWordForGame()
        {
            string[] words = File.ReadAllLines(fileName);
            int indexOfWord = new Random().Next(words.Length - 1);
            WordForGame = words[indexOfWord];
        }
    }
}
