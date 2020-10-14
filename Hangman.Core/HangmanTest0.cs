using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman.Core
{
    public class HangmanTest0
    {
        public string Word { get; set; }
        public HangmanTest0(string aword)
        {
            Word = aword;
        }
        public HangmanTest0()
        {
            Word = "Unset";
        }
        public string GetWord()
        {
            return Word;
        }

        public int Add(int x, int y)
        {
            return x + y;
        }

        /*GuessResult Guess(string aguess)
        {

        }*/

    }
}
