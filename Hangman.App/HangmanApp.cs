using System;
using System.Threading.Tasks.Sources;

namespace Hangman.App
{
    // Comments from Team 1 //
    // 1. No error message if the user enters same letter again.
    // 2. No error message if the user enters more than one letter in a row.
    // 3. If user enters same letter again it will save in bad guesses.
    // 4. It will be more clear if the Construtor is on the top of the class (WordGameCore)
    // 5. We couldn't understand why you convert the char user input to string? wouldn't be better to keep it as char?
    // 6. Keep all the logic part (as ValidateUserChar) in the core class. This method exist in both core and app but it is not used in core.
    // 7. Good that you have already splitted into core and app part.



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
                    userGuess = GetUserLetterGuess(hangman); // todo: namngivning 
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


        static string GetUserLetterGuess(Hangman.Core.WordGameCore aHangman)
        {
            Console.Write("Please guess a letter: ");
            char getCharFromUserInput = (char)Console.Read();


            if (!aHangman.ValidateUserInput(getCharFromUserInput))
            {
                Console.WriteLine("\nEnter guess between a-z");

                return "";
            }
            string convertCharToString = getCharFromUserInput.ToString().ToUpper();
            Console.ReadLine();
            return convertCharToString;
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
