using System;
using System.Threading.Tasks.Sources;

namespace Hangman.App
{
    // Comments from Team 1 //
    //X 1. No error message if the user enters same letter again.
    //X 2. No error message if the user enters more than one letter in a row.
    //X 3. If user enters same letter again it will save in bad guesses.
    //X 4. It will be more clear if the Construtor is on the top of the class (WordGameCore)
    // 5. We couldn't understand why you convert the char user input to string? wouldn't be better to keep it as char?
    //X 6. Keep all the logic part (as ValidateUserChar) in the core class. This method exist in both core and app but it is not used in core.
    //X 7. Good that you have already splitted into core and app part.



    class HangmanApp
    {

        static void Main(string[] args)
        {
            Hangman.Core.WordGameCore hangman = new Hangman.Core.WordGameCore(Countries.GetRandom());

            //    Console.SetCursorPosition(5, 10);
            while (hangman.GetNumberOfTriesLeft() != 0)
            {
                if (hangman.CheckForWin() == true)
                {
                    PrintCorrectLettersInWord(hangman);
                    Console.SetCursorPosition(50, 3);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"You Won! The correct word is {hangman.GetWordToGuess()}.");
                    Console.SetCursorPosition(1, 27);
                    break;
                }
                string userGuess = "";
                do
                {
                    PrintCorrectLettersInWord(hangman);
                    // Console.Write(incorrectlyGuessed);
                    Console.SetCursorPosition(50, 11);
                    Console.Write($"Number of guesses left: {hangman.GetNumberOfTriesLeft()}");
                    userGuess = GetUserLetterGuess(hangman); // todo: namngivning 
                    if (userGuess == "")
                        hangman.errorMessage = "Please enter a letter (a-z)";
                    else
                        hangman.errorMessage = "";

                } while (userGuess == "");

                if (hangman.LetterInGuessWord(userGuess) == false)
                {
                    if (hangman.AddIncorrectlyGuessedReturnTrueIfSuccess(userGuess) == false)
                    {
                        hangman.errorMessage = "Letter already guessed.";
                    }
                    else
                    {
                        hangman.SetNumberOfTriesLeft(hangman.GetNumberOfTriesLeft() - 1);
                    }

                }
            } // While

            if (hangman.GetNumberOfTriesLeft() == 0)
            {
                Console.SetCursorPosition(50, 3);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"You lost, the right word was {hangman.GetWordToGuess()}");
                Console.SetCursorPosition(0, 14);
                PrintHangMan(hangman.GetNumberOfTriesLeft());
                Console.SetCursorPosition(1, 27);
            }
        } // main


        static string GetUserLetterGuess(Hangman.Core.WordGameCore aHangman)
        {
            Console.SetCursorPosition(50, 9);
            Console.Write("Please guess a letter: ");
            char getCharFromUserInput = (char)Console.Read();


            if (!aHangman.ValidateUserInput(getCharFromUserInput))
            {
                //Console.Write("Enter guess between a-z");
                aHangman.errorMessage = "Please enter a letter (a-z)";

                return "";
            }
            string convertCharToString = getCharFromUserInput.ToString().ToUpper();
            Console.ReadLine();
            return convertCharToString;
        }



        public static void PrintCorrectLettersInWord(Hangman.Core.WordGameCore aHangman)
        {
            Console.Clear();
            Console.SetCursorPosition(50, 1);
            Console.SetCursorPosition(50, 3);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(aHangman.errorMessage);
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(50, 5);
            Console.Write("Guess a country ");
            Console.SetCursorPosition(50, 7);
            Console.Write(aHangman.CreateCurrentGuessAsString());
            Console.SetCursorPosition(50, 12);
            Console.Write($"Bad guesses:{aHangman.GetincorrectlyGuessed()}");
            Console.SetCursorPosition(0, 14);
            PrintHangMan(aHangman.GetNumberOfTriesLeft());

        }

        private static void PrintHangMan(int v)
        {
            switch (v)
            {
                case 10:
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("        _________|  |_________");
                    Console.WriteLine("       |                      |");
                    break;
                case 9:
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("                 |  |");
                    Console.WriteLine("                 |  |");
                    Console.WriteLine("                 |  |");
                    Console.WriteLine("                 |  |");
                    Console.WriteLine("                 |  |");
                    Console.WriteLine("                 |  |");
                    Console.WriteLine("                 |  |");
                    Console.WriteLine("                 |  |");
                    Console.WriteLine("                 |  |");
                    Console.WriteLine("        _________|  |_________");
                    Console.WriteLine("       |                     |");
                    break;
                case 8:
                    Console.WriteLine("                 ________________________");
                    Console.WriteLine("                 |    ___________________|");
                    Console.WriteLine("                 |   /");
                    Console.WriteLine("                 |  |");
                    Console.WriteLine("                 |  |");
                    Console.WriteLine("                 |  |");
                    Console.WriteLine("                 |  |");
                    Console.WriteLine("                 |  |");
                    Console.WriteLine("                 |  |");
                    Console.WriteLine("                 |  |");
                    Console.WriteLine("                 |  |");
                    Console.WriteLine("        _________|  |_________");
                    Console.WriteLine("       |                     |");
                    break;
                case 7:
                    Console.WriteLine("                 ________________________");
                    Console.WriteLine("                 |    ___________________|");
                    Console.WriteLine("                 |   /                 |");
                    Console.WriteLine("                 |  |                  |");
                    Console.WriteLine("                 |  |");
                    Console.WriteLine("                 |  |");
                    Console.WriteLine("                 |  |");
                    Console.WriteLine("                 |  |");
                    Console.WriteLine("                 |  |");
                    Console.WriteLine("                 |  |");
                    Console.WriteLine("                 |  |");
                    Console.WriteLine("        _________|  |_________");
                    Console.WriteLine("       |                     |");
                    break;
                case 6:
                    Console.WriteLine("                 ________________________");
                    Console.WriteLine("                 |    ___________________|");
                    Console.WriteLine("                 |   /                 |");
                    Console.WriteLine("                 |  |                  |");
                    Console.WriteLine("                 |  |                ('_')");
                    Console.WriteLine("                 |  |");
                    Console.WriteLine("                 |  |");
                    Console.WriteLine("                 |  |");
                    Console.WriteLine("                 |  |");
                    Console.WriteLine("                 |  |");
                    Console.WriteLine("                 |  |");
                    Console.WriteLine("        _________|  |_________");
                    Console.WriteLine("       |                     |");
                    break;
                case 5:
                    Console.WriteLine("                 ________________________");
                    Console.WriteLine("                 |    ___________________|");
                    Console.WriteLine("                 |   /                 |");
                    Console.WriteLine("                 |  |                  |");
                    Console.WriteLine("                 |  |                ('_')");
                    Console.WriteLine("                 |  |                  |");
                    Console.WriteLine("                 |  |                  |");
                    Console.WriteLine("                 |  |                  |");
                    Console.WriteLine("                 |  |");
                    Console.WriteLine("                 |  |");
                    Console.WriteLine("                 |  |");
                    Console.WriteLine("        _________|  |_________");
                    Console.WriteLine("       |                     |");
                    break;
                case 4:
                    Console.WriteLine("                 ________________________");
                    Console.WriteLine("                 |    ___________________|");
                    Console.WriteLine("                 |   /                 |");
                    Console.WriteLine("                 |  |                  |");
                    Console.WriteLine("                 |  |                ('_')");
                    Console.WriteLine("                 |  |                  |_");
                    Console.WriteLine("                 |  |                  | \\");
                    Console.WriteLine("                 |  |                  | ");
                    Console.WriteLine("                 |  |");
                    Console.WriteLine("                 |  |");
                    Console.WriteLine("                 |  |");
                    Console.WriteLine("        _________|  |_________");
                    Console.WriteLine("       |                     |");
                    break;
                case 3:
                    Console.WriteLine("                 ________________________");
                    Console.WriteLine("                 |    ___________________|");
                    Console.WriteLine("                 |   /                 |");
                    Console.WriteLine("                 |  |                  |");
                    Console.WriteLine("                 |  |                ('_')");
                    Console.WriteLine("                 |  |                 _|_");
                    Console.WriteLine("                 |  |                / | \\");
                    Console.WriteLine("                 |  |                  | ");
                    Console.WriteLine("                 |  |");
                    Console.WriteLine("                 |  |");
                    Console.WriteLine("                 |  |");
                    Console.WriteLine("        _________|  |_________");
                    Console.WriteLine("       |                     |");
                    break;
                case 2:
                    Console.WriteLine("                 ________________________");
                    Console.WriteLine("                 |    ___________________|");
                    Console.WriteLine("                 |   /                 |");
                    Console.WriteLine("                 |  |                  |");
                    Console.WriteLine("                 |  |                ('_')");
                    Console.WriteLine("                 |  |                 _|_");
                    Console.WriteLine("                 |  |                / | \\");
                    Console.WriteLine("                 |  |                  | ");
                    Console.WriteLine("                 |  |                   \\");
                    Console.WriteLine("                 |  |                    \\");
                    Console.WriteLine("                 |  |");
                    Console.WriteLine("        _________|  |_________");
                    Console.WriteLine("       |                     |");
                    break;
                case 1:
                    Console.WriteLine("                 ________________________");
                    Console.WriteLine("                 |    ___________________|");
                    Console.WriteLine("                 |   /                 |");
                    Console.WriteLine("                 |  |                  |");
                    Console.WriteLine("                 |  |                ('_')");
                    Console.WriteLine("                 |  |                 _|_");
                    Console.WriteLine("                 |  |                / | \\");
                    Console.WriteLine("                 |  |                  | ");
                    Console.WriteLine("                 |  |                 / \\");
                    Console.WriteLine("                 |  |                /   \\");
                    Console.WriteLine("                 |  |");
                    Console.WriteLine("        _________|  |_________");
                    Console.WriteLine("       |                     |");
                    break;
                case 0:
                    Console.WriteLine("                 ________________________");
                    Console.WriteLine("                 |    ___________________|");
                    Console.WriteLine("                 |   /                 |");
                    Console.WriteLine("                 |  |                  |");
                    Console.WriteLine("                 |  |                (*~*)");
                    Console.WriteLine("                 |  |                 _|_");
                    Console.WriteLine("                 |  |                / | \\");
                    Console.WriteLine("                 |  |                  | ");
                    Console.WriteLine("                 |  |                 / \\");
                    Console.WriteLine("                 |  |                /   \\");
                    Console.WriteLine("                 |  |");
                    Console.WriteLine("        _________|  |_________");
                    Console.WriteLine("       |                     |");
                    break;

            }
        }
    }
}

/*
                 ________________________
                 |    ___________________|
                 |   /               |
                 |  |                |
                 |  |              ('_')
                 |  |               _|_
                 |  |              / | \
                 |  |                |
                 |  |               / \
                 |  |              /   \
                 |  |
                 |  |
        _________|  |_________
        |                    |          14 rader


1   Ramen
2   Stommen lodrätt
3   Stommen vågrätt
4   repet
5   huvudet
6   hals & kropp
7   arm höger
8   arm vänster
9   ben höger
10  ben vänster


*/
