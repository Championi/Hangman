using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Linq;
using System.Xml.Schema;

namespace Hangman.Core
{
    public class WordGameCore
    {
        private string wordToGuess;
        private HashSet<string> wordHash = new HashSet<string>(); // Create an empty Set list.
        private string correctlyGuessed = "";
        private string incorrectlyGuessed = "";
        private int numberOfTries = 10;
        private string errorMessage = "";

        public WordGameCore(string aWord)
        {
            wordToGuess = aWord.ToUpper();
            for (int i = 0; i < wordToGuess.Length; i++)
            {
                wordHash.Add(wordToGuess.Substring(i, 1)); // Add every unique letter of wordToGuess to the Set list.
            }
        }
        
        public bool CheckForWin(string wordToGuess, string correctlyGuessed)
        {
            foreach (char letter in wordToGuess)
            {   //Om varje bokstav i gissningsordet finns i listan correctlyGuessed, skicka tillaka "true", annars "false".
                if (correctlyGuessed.Contains(letter.ToString()) == false)
                {
                    return false;
                }
            }
            return true;
        }

        static bool ValidateUserChar(string ch)
        {
            return Char.IsLetter(ch.First());
        }

        public string CreateCurrentGuessAsString()
        {
            string ReturnCurrentGuessAsString = "";
            foreach (char letter in wordToGuess)
            {
                if (correctlyGuessed.Contains(letter.ToString()))
                    ReturnCurrentGuessAsString += letter;
                else
                {
                    ReturnCurrentGuessAsString += "-";
                }
            }
            return ReturnCurrentGuessAsString;
        }
       

    }
}


/*
Todo
- Ordet på en rad. Grafisk, färger etc - started
- Ett sätt att vinna - klart
- Inte kunna skriva längre ord eller konstiga tecken - started
- Stora/små bokstäver ska funkar - klar
- Refactoring: sätta in i metoder - started

 
 



namespace Hangman
{
    class Program
    {

        static void Main(string[] args)
        {


            while (numberOfTries != 0)
            {
                if (CheckForWin(wordToGuess, correctlyGuessed) == true)
                {
                    Console.WriteLine($"\nYou Won! The correct word is {wordToGuess}.");
                    break;
                }

                string userGuess = "";
                do
                {
                    PrintCorrectLettersInWord(wordToGuess, correctlyGuessed, errorMessage, incorrectlyGuessed);
                    // Console.WriteLine(incorrectlyGuessed);
                    Console.WriteLine($"\nNumber of guesses left: {numberOfTries}");
                    userGuess = GetUserLetterGuess(); // todo: namngivning 
                    if (userGuess == "")
                        errorMessage = "Please enter a letter (a-z)";
                    else
                        errorMessage = "";

                } while (userGuess == "");



                if (wordHash.Contains(userGuess))
                {
                    correctlyGuessed += userGuess;
                }
                else
                {
                    numberOfTries = numberOfTries - 1;
                    incorrectlyGuessed += userGuess;
                }
            }


          

            if (numberOfTries == 0)
            {
                Console.WriteLine($"You lost, the right word was {wordToGuess}");
            }


           

            

            static string GetUserLetterGuess()
            {
                Console.Write("Please guess a letter: ");
                char getCharFromUserInput = (char)Console.Read();
                if (!ValidateUserChar(getCharFromUserInput.ToString()))
                {
                    Console.WriteLine("\nEnter guess between a-z");

                    return "";
                }
                string convertCharToString = getCharFromUserInput.ToString().ToUpper();
                Console.ReadLine();
                return convertCharToString;
            }
        }

        private static bool ValidateUserChar(char getCharFromUserInput)
        {
            throw new NotImplementedException();
        }
    }
}




















//Exampleword = Applepie
//Examplewordset = Exampleword into set of letters

//listOfCorrectlyGuessedLetters = []
//listOfIncorrectlyGuessedLetters = []

//numberOfTries = 10

//while numberOfTries != 0 {

//if listOfCorrectlyGuessedLetters == examplewordset
// print "You WON!"
// print currentWord
// break;

//Print currentWord
//For every letter in wordToGuess,
//if letter is present in listOfCorrectlyGuessedLetters - print letter
//else print "-"

//print listOfIncorrectlyGuessedLetters

//print $"Guesses left {numberOfTries}"

// //first time should give us "_ _ _ _ _ _ _ _ "

//ask for a single letter

//if letter is present in Examplewordset
//add letter to listOfCorrectlyGuessedLetters

//else
//  numberOfTries--
// letter is added to listOfIncorrectlyGuessedLetters
//}

// if number of tries == 0 {
//print "you lost :( "
*/