/*
Todo
- Ordet på en rad. Grafisk, färger etc
- Ett sätt att vinna
- Inte kunna skriva längre ord eller konstiga tecken
- Stora/små bokstäver ska funkar
- Refactoring: sätta in i metoder

 
 
 */
using System;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Hangman
{
    class Program
    {
        // todo: metod är cirka 1-7 rader lång cirka (en penna lång)

        static void Main(string[] args)
        {
           
            //string wordToGuess = Countries.GetRandom();
            string wordToGuess = "Applepie";
            wordToGuess = wordToGuess.ToUpper();

            //Set console size
            //Console.SetWindowSize(80, 24);
            //Console.SetBufferSize(80, 80);

            HashSet<string> wordHash = new HashSet<string>(); //Appie

            for (int i = 0; i < wordToGuess.Length; i++)
            {
                wordHash.Add(wordToGuess.Substring(i, 1)); //aplei
            }


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
                PrintCorrectLettersInWord(wordToGuess, correctlyGuessed);

                //#prints a list of the letters the user guessed incorrectly.
                //Console.WriteLine(incorrectlyGuessed); #Does not print out what we want yet

                Console.WriteLine($"\nNumber of guesses left: {numberOfTries}");

                string userGuess = getUserInput();



                if (wordHash.Contains(userGuess))
                {
                    correctlyGuessed.Add(userGuess);
                    Console.WriteLine(userGuess);
                }
                else
                {
                    numberOfTries = numberOfTries - 1;
                    incorrectlyGuessed.Add(userGuess);
                    Console.WriteLine(userGuess);
                }
            }


                
                if (numberOfTries == 0)
                {
                    Console.WriteLine($"You lost, the right word was {wordToGuess}");
                }



            //static void PrintCurrentWord(string word, List<string> correctlyGuessed);

            //static void GenerateDisplayString(string word, List<string> correctlyGuessed)
            //static void CurrentWord(string word, List<string> correctlyGuessed)

            static void PrintCorrectLettersInWord(string wordToGuess, List<string> correctlyGuessed)
            {
                //Console.Clear();
                //Console.SetCursorPosition(1, 1);
                //Console.WriteLine("Guess a country ");
                //Console.SetCursorPosition(5, 5);

              

                foreach (char letter in wordToGuess)
                {
                    if (correctlyGuessed.Contains(letter.ToString()))
                        Console.Write(letter);
                    else
                    {
                        Console.Write("-");
                    }
                }
            }
            static string getUserInput()
            {
                Console.Write("Please guess a letter: "); //gör metod utav detta
                char getCharFromUserInput = (char)Console.Read();
                string convertCharToString = getCharFromUserInput.ToString().ToUpper();
                Console.ReadLine();
                return convertCharToString;
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
