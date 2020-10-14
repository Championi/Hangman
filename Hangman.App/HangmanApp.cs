using System;
using System.Threading.Tasks.Sources;

namespace Hangman.App
{
    class HangmanApp
    {

        static void Main(string[] args)
        {
            Hangman.Core.WordGameCore hangman = new Hangman.Core.WordGameCore("Applepie");

            Console.WriteLine("Test: " + hangman.CreateCurrentGuessAsString());

            //    Console.SetCursorPosition(5, 10);
            while (hangman.GetNumberOfTriesLeft() != 0)
            {
                if (hangman.CheckForWin() == true)
                {
                    PrintCorrectLettersInWord(hangman);
                    Console.WriteLine($"\nYou Won! The correct word is {hangman.GetWordToGuess()}.");
                    break;
                }
                string userGuess = "";
                do
                {
                    PrintCorrectLettersInWord(hangman);
                    // Console.WriteLine(incorrectlyGuessed);
                    Console.WriteLine($"\nNumber of guesses left: {hangman.GetNumberOfTriesLeft()}");
                    userGuess = GetUserLetterGuess(); // todo: namngivning 
                    if (userGuess == "")
                        hangman.errorMessage = "Please enter a letter (a-z)";
                    else
                        hangman.errorMessage = "";

                } while (userGuess == "");

                if (hangman.LetterInGuessWord(userGuess) == false)
                {
                    hangman.SetNumberOfTriesLeft(hangman.GetNumberOfTriesLeft()-1);
                    hangman.AddIncorrectlyGuessed(userGuess);
                }
            } // While

            if (hangman.GetNumberOfTriesLeft() == 0)
            {
                Console.WriteLine($"You lost, the right word was {hangman.GetWordToGuess()}");
            }
        } // main


        static string GetUserLetterGuess()
        {
            Console.Write("Please guess a letter: ");
            char getCharFromUserInput = (char)Console.Read();


            if (!ValidateUserChar(getCharFromUserInput))
            {
                Console.WriteLine("\nEnter guess between a-z");

                return "";
            }
            string convertCharToString = getCharFromUserInput.ToString().ToUpper();
            Console.ReadLine();
            return convertCharToString;
        }

        public static bool ValidateUserChar(char getCharFromUserInput)
        {
            return Char.IsLetter(getCharFromUserInput);
        }

        public static void PrintCorrectLettersInWord(Hangman.Core.WordGameCore aHangman)
        {
            Console.Clear();
            Console.SetCursorPosition(1, 1);
            Console.SetCursorPosition(3, 3);
            Console.WriteLine(aHangman.errorMessage);
            Console.SetCursorPosition(5, 5);
            Console.WriteLine("Guess a country ");
            Console.WriteLine(aHangman.CreateCurrentGuessAsString());
            Console.SetCursorPosition(5, 10);
            Console.WriteLine($"Bad guesses:{aHangman.GetincorrectlyGuessed()}");
        }
    }
}
