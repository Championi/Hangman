using System;
using System.Collections.Generic;
using System.Text;

namespace Hangman
{
    public class GuessString
    {
        private string StringToGuess { get; set; }
        private HashSet<string> wordHash = new HashSet<string>();
        private string UserInput = "";
        public int BadGuesses = 0;
   
        public GuessString(string target)
        {
            StringToGuess = target;
            for (int i = 0; i < StringToGuess.Length; i++)
                wordHash.Add(StringToGuess.Substring(i, 1).ToLower());
        }

        public string CheckNewGuess(string letter)
        {
            string issue = "";
            if (letter.Length == 1)
            {
                if (UserInput.Contains(letter))
                    UserInput = "Already guessed...";
                else if (!wordHash.Contains(letter))
                {
                    issue = "Not correct..";
                    BadGuesses++;
                }
                else
                    UserInput += letter;
            }
            else
            {
                issue = "Input length not correct...";
            }
            return issue;
        }
        
        public Boolean CheckGuess()
        {
            return GenerateInputString() == StringToGuess; 
        }

        public string GenerateInputString()
        {
            string retval = "";
            foreach (char letter in StringToGuess)
            {
                if (UserInput.ToLower().Contains(letter.ToString().ToLower()))
                    retval += letter;
                else
                    retval += "-";
            }
            return retval;
        }
    }
}
