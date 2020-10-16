using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Linq;
using System.Xml.Schema;


/*
Todo
- Ordet på en rad. Grafisk, färger etc - started
- Ett sätt att vinna - klart
- Inte kunna skriva längre ord eller konstiga tecken - started
- Stora/små bokstäver ska funkar - klar
- Refactoring: sätta in i metoder - started
*/

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

        private string _wordToGuess;
        private HashSet<string> _wordHash = new HashSet<string>(); // Create an empty Set list.
        private string _correctlyGuessed = "";
        private string _incorrectlyGuessed = "";
        private int _numberOfTriesLeft = 10;
        public string errorMessage = "";

        public WordGameCore(string aWord) //Constructor
        {
            _wordToGuess = aWord.ToUpper();
            for (int i = 0; i < _wordToGuess.Length; i++)
            {
                _wordHash.Add(_wordToGuess.Substring(i, 1)); // Add every unique letter of wordToGuess to the Set list.
            }
        }

        //Getters & Setters


        public int GetNumberOfTriesLeft()
        {
            return _numberOfTriesLeft;
        }
        public void SetNumberOfTriesLeft(int val)
        {
            _numberOfTriesLeft = val;
        }
        public string GetWordToGuess()
        {
            return _wordToGuess;
        }
        public string GetincorrectlyGuessed()
        {
            return _incorrectlyGuessed;
        }

        public bool AddIncorrectlyGuessedReturnTrueIfSuccess(string aStr)
        {
            if (_incorrectlyGuessed.Contains(aStr))
            {
                return false;
            }
            else
            {
                _incorrectlyGuessed += aStr;
                return true;

            }
        }
        public void AddCorreclyGuessed(string aStr)
        {
            _correctlyGuessed += aStr;
        }

        public bool LetterInGuessWord(string userGuess)
        {
            if (_wordHash.Contains(userGuess))
            {
                AddCorreclyGuessed(userGuess);
                return true;
            }
            return false;
        }

        public bool CheckForWin()//string wordToGuess, string correctlyGuessed)
        {

            // OO: Can you write this method with LINQ? (hard)

            foreach (char letter in _wordToGuess)
            {   //Om varje bokstav i gissningsordet finns i listan correctlyGuessed, skicka tillaka "true", annars "false".
                if (_correctlyGuessed.Contains(letter.ToString()) == false)
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
            foreach (char letter in _wordToGuess)
            {
                if (_correctlyGuessed.Contains(letter.ToString()))
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




