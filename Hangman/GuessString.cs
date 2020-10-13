using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hangman
{
    public class GuessString
    {
        private string _stringToGuess;
        private HashSet<string> _wordHash = new HashSet<string>();
        private string _userInput = "";
        private int _badGuesses = 0;

        public GuessString(string target)
        {
            _stringToGuess = target;
            for (int i = 0; i < _stringToGuess.Length; i++)
                _wordHash.Add(_stringToGuess.Substring(i, 1).ToLower());
        }

        public string CheckNewGuess(string letter) /// return issue comment on a character
        {
            string issue = "";
            if (letter.Length == 1)
            {
                if (!Char.IsLetter(letter.First()))
                    issue = "Not a valid letter..";
                else if (_userInput.Contains(letter))
                    issue = "Already guessed...";
                else if (!_wordHash.Contains(letter))
                {
                    issue = "Not correct..";
                    _badGuesses++;
                }
                else
                    _userInput += letter;
            }
            else
                issue = "Input length not correct...";
            return issue;
        }

        public int BadGuessCout()
        {
            return _badGuesses;
        }

        public Boolean CheckGuess() /// Check if user has made a comple guess
        {
            return GenerateInputString() == _stringToGuess;
        }

        public string GenerateInputString()
        {
            string retval = "";
            foreach (char letter in _stringToGuess)
            {
                if (_userInput.ToLower().Contains(letter.ToString().ToLower()))
                    retval += letter;
                else
                    retval += "-";
            }
            return retval;
        }
    }
}
