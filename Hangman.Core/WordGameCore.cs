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
        private string wordToGuess;
        public  HashSet<string> wordHash = new HashSet<string>(); // Create an empty Set list.
        public string correctlyGuessed = "";
        public string incorrectlyGuessed = "";
        public int numberOfTries = 10;
        public string errorMessage = "";
       
        public string GetWordToGuess()
        {
            return wordToGuess;
        }
        
        public WordGameCore(string aWord)
        {
            wordToGuess = aWord.ToUpper();
            for (int i = 0; i < wordToGuess.Length; i++)
            {
                wordHash.Add(wordToGuess.Substring(i, 1)); // Add every unique letter of wordToGuess to the Set list.
            }
        }
        
        public bool CheckForWin()//string wordToGuess, string correctlyGuessed)
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

        public bool ValidateUserChar(string ch)
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
*/
 
 