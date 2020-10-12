using System;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            string wordToGuess = Countries.GetRandom();
            HashSet<string> wordHash = new HashSet<string>();
            string correctlyGuessed = "";
            int numberOfTries = 10;

            for (int i = 0; i < wordToGuess.Length; i++)
                wordHash.Add(wordToGuess.Substring(i, 1).ToLower());
   
   
            while (numberOfTries != 0)
            {
                String Hinttext = "";
                if (CurrentWord(wordToGuess, correctlyGuessed, Hinttext, numberOfTries))
                    break;

                string input = Console.ReadLine();
                if (input.Length == 1)
                {
                    if (correctlyGuessed.Contains(input))
                        Hinttext = "Already guessed...";
                    else if (!wordHash.Contains(input))
                    {
                        Hinttext = "Not correct..";
                        numberOfTries--;
                        if (numberOfTries == 0)
                            break;
                    }
                    else
                        correctlyGuessed += input;
                }
                else
                {
                    Hinttext = "Input not correct...";
                }
                if (Hinttext != "")
                {
                    Console.SetCursorPosition(2, 16);
                    Console.WriteLine(Hinttext);
                    Thread.Sleep(500);
                }
                
            }
            if (CurrentWord(wordToGuess, correctlyGuessed, "", 0))
            {
                Console.Clear();
                Console.WriteLine("Contratulations!");
            }
            else
                Console.WriteLine("Sorry, you should have found:" + wordToGuess);
        }

        static bool CurrentWord(string TargetWord, string Guesses, string HintText, int GuessesLeft)
        {
            bool retval = true;
            Console.SetWindowSize(80, 24);
            Console.SetBufferSize(80, 80);
            Console.Clear();
            Console.SetCursorPosition(1, 1);
            Console.WriteLine("Guess a country " + TargetWord); // For debug purpouse
            Console.SetCursorPosition(10, 10);
            foreach (char letter in TargetWord)
            {
                if (Guesses.ToLower().Contains(letter.ToString().ToLower()))
                    Console.Write(letter);
                else
                {
                    Console.Write("-");
                    retval = false;
                }
            }
            Console.SetCursorPosition(2, 14);
            Console.Write($"({GuessesLeft}) Please guess a letter:");

            return retval;
        }
    }
}
