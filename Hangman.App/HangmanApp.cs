using System;
using System.Threading.Tasks.Sources;

namespace Hangman.App
{
    class HangmanApp
    {
       
        static void Main(string[] args)
        {

  
        Hangman.Core.WordGameCore wgc = new Hangman.Core.WordGameCore("Applepie");

        Console.WriteLine("Test: " + wgc.CreateCurrentGuessAsString());

    //    Console.SetCursorPosition(5, 10);

            
        }
        
        static void PrintCorrectLettersInWord(string wordToGuess, string correctlyGuessed, string ErrorMessage, string incorrectlyGuessedstr)
        {
            Console.Clear();
            Console.SetCursorPosition(1, 1);

            Console.SetCursorPosition(3, 3);
            Console.WriteLine(ErrorMessage);
            Console.SetCursorPosition(5, 5);
            Console.WriteLine("Guess a country ");
          //  Console.WriteLine(wgc.CreateCurrentGuessAsString());
                Console.SetCursorPosition(5, 10);
            Console.WriteLine($"Bad guesses:{incorrectlyGuessedstr}");
        }
    }
}
