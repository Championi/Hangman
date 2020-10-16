using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Linq;
using System.Xml.Schema;

namespace Hangman.Core
{
    public class WordGameCore
    {
        public class GuessResult
        {

        }

        static void Main(string[] args)
        {
        }

        // OO: I usually name private field with underscore first, like "_wordToGuess" 
        private string wordToGuess;
        private HashSet<string> wordHash = new HashSet<string>(); // Create an empty Set list.
        private string correctlyGuessed = "";
        private string incorrectlyGuessed = "";
        private int numberOfTriesLeft = 10;
        public string errorMessage = "";

        public WordGameCore(string aWord) //Constructor
        {
            wordToGuess = aWord.ToUpper();
            for (int i = 0; i < wordToGuess.Length; i++)
            {
                wordHash.Add(wordToGuess.Substring(i, 1)); // Add every unique letter of wordToGuess to the Set list.
            }
        }

        //Getters & Setters

        // OO: Instead of these two methods you can write:
        // OO: public int NumberOfTriesLeft { get; set; }

        public int GetNumberOfTriesLeft()
        {
            return numberOfTriesLeft;
        }
        public void SetNumberOfTriesLeft(int val)
        {
            numberOfTriesLeft = val;
        }
        public string GetWordToGuess()
        {
            return wordToGuess;
        }
        public string GetincorrectlyGuessed()
        {
            return incorrectlyGuessed;
        }

        // OO: This methods seems to more than one thing. Create one more method or change the same
        public bool AddIncorrectlyGuessed(string aStr)
        {
            if (incorrectlyGuessed.Contains(aStr))
            {
                return false;
            }
            else
            {
                incorrectlyGuessed += aStr;
                return true;

            }
        }
        public void AddCorreclyGuessed(string aStr)
        {
            correctlyGuessed += aStr;
        }

        public bool LetterInGuessWord(string userGuess)
        {
            if (wordHash.Contains(userGuess))
            {
                AddCorreclyGuessed(userGuess);
                return true;
            }
            return false;
        }

        public bool CheckForWin()//string wordToGuess, string correctlyGuessed)
        {

            // OO: Can you write this method with LINQ? (hard)

            foreach (char letter in wordToGuess)
            {   //Om varje bokstav i gissningsordet finns i listan correctlyGuessed, skicka tillaka "true", annars "false".
                if (correctlyGuessed.Contains(letter.ToString()) == false)
                {
                    return false;
                }
            }
            return true;
        }

        public bool ValidateUserInput(char getCharFromUserInput)
        {
            return Char.IsLetter(getCharFromUserInput);
        }


        public string CreateCurrentGuessAsString()
        {
            // OO: Can you write this method with LINQ? (hard)
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
*/

