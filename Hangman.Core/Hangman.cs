using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman.Core
{
    public class Hangman
    {
        public int Word { get; set; }
        Hangman(string aword)
        {
            Word = aword;
        }
        GuessResult Guess(string aguess)
        {

        }

    }
}
