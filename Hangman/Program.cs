﻿/*
Todo
- Ordet på en rad. Grafisk, färger etc - started
- Ett sätt att vinna - klart
- Inte kunna skriva längre ord eller konstiga tecken - started
- Stora/små bokstäver ska funkar - klar
- Refactoring: sätta in i metoder - started

 */
using System;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Linq;

namespace Hangman
{
    class Program
    {

        static void Main(string[] args)
        {

            //string wordToGuess = Countries.GetRandom();
            string wordToGuess = "Applepie";
            wordToGuess = wordToGuess.ToUpper();

            //Set console size
            Console.SetWindowSize(80, 24);
            Console.SetBufferSize(80, 80);

            HashSet<string> wordHash = new HashSet<string>(); // Create an empty Set list.

            for (int i = 0; i < wordToGuess.Length; i++)
            {
                wordHash.Add(wordToGuess.Substring(i, 1)); // Add every unique letter of wordToGuess to the Set list.
            }

            string correctlyGuessed = "";
            string incorrectlyGuessed = "";


            int numberOfTries = 10;
            string errorMessage = "";
            while (numberOfTries != 0)
            {
                if (CheckForWin(wordToGuess, correctlyGuessed) == true)
                {
                    Console.WriteLine($"\nYou Won! The correct word is {wordToGuess}.");
                    break;
                }

                string userGuess = "";
                do
                {
                    PrintCorrectLettersInWord(wordToGuess, correctlyGuessed, errorMessage, incorrectlyGuessed);
                    // Console.WriteLine(incorrectlyGuessed);
                    Console.WriteLine($"\nNumber of guesses left: {numberOfTries}");
                    userGuess = GetUserLetterGuess(); // todo: namngivning 
                    if (userGuess == "")
                        errorMessage = "Please enter a letter (a-z)";
                    else
                        errorMessage = "";

                } while (userGuess == "");
          
                if (wordHash.Contains(userGuess))
                {
                    correctlyGuessed += userGuess;
                }
                else
                {
                    numberOfTries = numberOfTries - 1;
                    incorrectlyGuessed += userGuess;
                }
            }


            static bool ValidateUserChar(string ch)
            {
                return Char.IsLetter(ch.First());
            }

            if (numberOfTries == 0)
            {
                Console.WriteLine($"You lost, the right word was {wordToGuess}");
            }


            static void PrintCorrectLettersInWord(string wordToGuess, string correctlyGuessed, string ErrorMessage, string incorrectlyGuessedstr)
            {
                Console.Clear();
                Console.SetCursorPosition(1, 1);
               
                Console.SetCursorPosition(3, 3);
                Console.WriteLine(ErrorMessage);
                Console.SetCursorPosition(5, 5);
                Console.WriteLine("Guess a country ");
                foreach (char letter in wordToGuess)
                {
                    if (correctlyGuessed.Contains(letter.ToString()))
                        Console.Write(letter);
                    else
                    {
                        Console.Write("-");
                    }
                }
                Console.SetCursorPosition(5, 10);
                Console.WriteLine($"Bad guesses:{incorrectlyGuessedstr}");

            }

            static bool CheckForWin(string wordToGuess, string correctlyGuessed)
            {
                foreach (char letter in wordToGuess)
                {   //Om varje bokstav i gissningsordet finns i listan correctlyGuessed, skicka tillaka "true", annars "false".
                    if (correctlyGuessed.Contains(letter.ToString()) == false)
                    {
                        return false;
                    }
                }
                return true;
            }

            static string GetUserLetterGuess()
            {
                Console.Write("Please guess a letter: ");
                char getCharFromUserInput = (char)Console.Read();
                if (!ValidateUserChar(getCharFromUserInput.ToString()))
                {
                    Console.WriteLine("\nEnter guess between a-z");
    
                    return "";
                }
                string convertCharToString = getCharFromUserInput.ToString().ToUpper();
                Console.ReadLine();
                return convertCharToString;
            }
        }

        private static bool ValidateUserChar(char getCharFromUserInput)
        {
            throw new NotImplementedException();
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
