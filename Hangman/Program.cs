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
            GuessString guessStr = new GuessString(wordToGuess);
            int numberOfTries = 10;
            
            while (guessStr.CheckGuess() == false && guessStr.BadGuessCout() < numberOfTries)
            {
                ShowDialog(guessStr.GenerateDisplayString(), numberOfTries - guessStr.BadGuessCout(), wordToGuess);
                string issueComment = guessStr.CheckNewGuess(Console.ReadLine().ToLower());
                if (issueComment != "")
                {
                    Console.SetCursorPosition(2, 16);
                    Console.WriteLine(issueComment);
                    Thread.Sleep(500);
                }
            }

            if (guessStr.CheckGuess() == true)
            {
                Console.Clear();
                Console.WriteLine("Contratulations!");
            }
            else
                Console.WriteLine("Sorry, you should have found:" + wordToGuess);
        }

        static void ShowDialog(string inputStr, int guessesLeft, string targetWordDebug)
        {
            Console.SetWindowSize(80, 24);
            Console.SetBufferSize(80, 80);
            Console.Clear();
            Console.SetCursorPosition(1, 1);
            Console.WriteLine("Guess a country " + targetWordDebug); // For debug purpouse
            Console.SetCursorPosition(10, 10);
            Console.Write(inputStr);
            Console.SetCursorPosition(2, 14);
            Console.Write($"({guessesLeft}) Please guess a letter:");
        }
    }
}
