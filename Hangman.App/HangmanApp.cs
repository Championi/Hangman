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
            while (hangman.numberOfTries != 0)
            {
                if (hangman.CheckForWin() == true)
                {
                    Console.WriteLine($"\nYou Won! The correct word is {hangman.GetWordToGuess()}.");
                    break;
                }
                string userGuess = "";
                do
                {
                    PrintCorrectLettersInWord(hangman.GetWordToGuess(), hangman.correctlyGuessed, hangman.errorMessage, hangman.incorrectlyGuessed, hangman);
                    // Console.WriteLine(incorrectlyGuessed);
                    Console.WriteLine($"\nNumber of guesses left: {hangman.numberOfTries}");
                    userGuess = GetUserLetterGuess(); // todo: namngivning 
                    if (userGuess == "")
                        hangman.errorMessage = "Please enter a letter (a-z)";
                    else
                        hangman.errorMessage = "";

                } while (userGuess == "");

                if (hangman.wordHash.Contains(userGuess))
                {
                    hangman.correctlyGuessed += userGuess;
                }
                else
                {
                    hangman.numberOfTries = hangman.numberOfTries - 1;
                    hangman.incorrectlyGuessed += userGuess;
                }
            } // While

            if (hangman.numberOfTries == 0)
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

        public static void PrintCorrectLettersInWord(string wordToGuess, string correctlyGuessed, string ErrorMessage, string incorrectlyGuessedstr,
            Hangman.Core.WordGameCore ahangman)
        {
            Console.Clear();
            Console.SetCursorPosition(1, 1);

            Console.SetCursorPosition(3, 3);
            Console.WriteLine(ErrorMessage);
            Console.SetCursorPosition(5, 5);
            Console.WriteLine("Guess a country ");
            Console.WriteLine(ahangman.CreateCurrentGuessAsString());
            Console.SetCursorPosition(5, 10);
            Console.WriteLine($"Bad guesses:{incorrectlyGuessedstr}");
        }

    }
}
