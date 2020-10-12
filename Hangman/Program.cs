using System;
using System.Threading;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World2!");
            fbs();
        }
        static void fbs()
        {
            Console.WriteLine(Countries.GetRandom());
        }
    }
}
