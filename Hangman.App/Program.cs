using System;
using System.Threading.Tasks.Sources;

namespace Hangman.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var h = new  Core.Hangman("Mamma", 3);

            Console.WriteLine("Your guess: ");
            string guess = Console.ReadLine();
            /*
             * */
            h.Guess(guess);
        }
    }
}
