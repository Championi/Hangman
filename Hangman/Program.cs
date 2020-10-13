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

            while (guessStr.CheckGuess() == false && guessStr.BadGuesses < numberOfTries)
            {
                ShowDialog(guessStr.GenerateInputString(), numberOfTries - guessStr.BadGuesses, wordToGuess);
                string input = Console.ReadLine();
                string issueComment = guessStr.CheckNewGuess(input);
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

        static void ShowDialog(string InputStr, int GuessesLeft, string TargetWord)
        {
            Console.SetWindowSize(80, 24);
            Console.SetBufferSize(80, 80);
            Console.Clear();
            Console.SetCursorPosition(1, 1);
            Console.WriteLine("Guess a country " + TargetWord); // For debug purpouse
            Console.SetCursorPosition(10, 10);
            Console.Write(InputStr);
            Console.SetCursorPosition(2, 14);
            Console.Write($"({GuessesLeft}) Please guess a letter:");
        }
    }
}
