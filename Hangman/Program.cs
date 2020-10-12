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
            Console.WriteLine("Guess a country.");
            string wordToGuess = Countries.GetRandom();// "Applepie";
            HashSet<string> wordHash = new HashSet<string>(); //Appie

            for (int i = 0; i < wordToGuess.Length; i++)
            {
                wordHash.Add(wordToGuess.Substring(i, 1).ToLower());
            }

            string correctlyGuessed = "";
            string incorrectlyGuessed = "";

            int numberOfTries = 10;

            Console.WriteLine("wordToGuess: " + wordToGuess);

            while (numberOfTries != 0)
            {
                String Hinttext = "";
                if (CurrentWord(wordToGuess, correctlyGuessed, Hinttext))
                    break;

                string input = Console.ReadLine();
                if (input.Length == 1)
                {
                    if (correctlyGuessed.Contains(input))
                        Hinttext = "Already guessed...";
                    else if (!wordHash.Contains(input))
                    {
                        Hinttext = "Not correct..";
                        incorrectlyGuessed += input;
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
                Console.WriteLine($"Number of guesses left: {numberOfTries}");
            }
            if (CurrentWord(wordToGuess, correctlyGuessed, ""))
                Console.WriteLine("Contratulations!");
            else
                Console.WriteLine("Sorry, you should have found:" + wordToGuess);
        }

        static bool CurrentWord(string TargetWord, string Guesses, string HintText)//, HashSet<string> myHash)
        {
            bool retval = true;
            Console.SetWindowSize(40, 40);
            Console.SetBufferSize(80, 80);
            Console.Clear();
            Console.SetCursorPosition(1, 1);
            Console.WriteLine(TargetWord);
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
            Console.Write("Please guess a letter:");

            return retval;
        }
    }
}




















//Exampleword = Applepie
//Examplewordset = Exampleword into set of letters

//listOfCorrectlyGuessedLetters = []
//listOfIncorrectlyGuessedLetters = []

//numberOfTries = 10

//while numberOfTries != 0 {

//if listOfCorrectlyGuessedLetters == examplewordset
// print "You WON!"
// print currentWord
// break;

//Print currentWord
//For every letter in wordToGuess,
//if letter is present in listOfCorrectlyGuessedLetters - print letter
//else print "-"

//print listOfIncorrectlyGuessedLetters

//print $"Guesses left {numberOfTries}"

// //first time should give us "_ _ _ _ _ _ _ _ "

//ask for a single letter

//if letter is present in Examplewordset
//add letter to listOfCorrectlyGuessedLetters

//else
//  numberOfTries--
// letter is added to listOfIncorrectlyGuessedLetters
//}

// if number of tries == 0 {
//print "you lost :( "
