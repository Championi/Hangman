﻿using System;
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
            Console.WriteLine("Hello World2!");
            string wordToGuess = Countries.GetRandom();// "Applepie";
            HashSet<string> wordHash = new HashSet<string>(); //Appie

            for (int i = 0; i < wordToGuess.Length; i++)
            {
                wordHash.Add(wordToGuess.Substring(i, 1));
            }

            //            string wordToGuessSet = .ToLower();


            List<string> correctlyGuessed = new List<string>();
            List<string> incorrectlyGuessed = new List<string>();


            int numberOfTries = 10;

            while (numberOfTries != 0)
            {
                /*   if (correctlyGuessed == correctlyGuessedSet)
                   {
                       Console.WriteLine("You Won!");
                       CurrentWord(wordToGuess);
                       break;
                   }*/


                //#prints the word with "-" except for the letters the user guessed correctly.
                CurrentWord(wordToGuess, wordHash);

                //#prints a list of the letters the user guessed incorrectly.
                Console.WriteLine(incorrectlyGuessed);

                Console.WriteLine($"Number of guesses left: {numberOfTries}");

                Console.WriteLine("Please guess a letter.");
                var answer = Console.Read();

                //if (answer present in wordToGuessSet) {
                //add answer to correctlyGuessed;
                //}

                //else {
                //numberOfTries--;
                //add answer to incorrectlyGuessed;
                //}


                // }
                //if (numberOfTries == 0) {
                //Console.WriteLine($"You lost, the right word was {wordToGuess}");


            }
            static void CurrentWord(string word, HashSet<string> myHash)
            {
                foreach (char letter in word)
                {
                    if (myHash.Contains(letter.ToString()))
                        Console.WriteLine(letter);
                    else
                    {
                        Console.WriteLine("-");
                    }
                }
            }
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
