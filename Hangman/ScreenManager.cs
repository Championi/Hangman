using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Schema;

namespace Hangman
{
    class ScreenManager
    {


        public static void ReadCharacter(string target, string current)
        {
            Console.SetWindowSize(40, 40);

            // setting buffer size of console 
            Console.SetBufferSize(80, 80);
            Console.Clear();
            Console.WriteLine("_______");
            // using the method 
            Console.SetCursorPosition(10, 10);
            Console.WriteLine("Hello GFG!");
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);

            Console.SetCursorPosition(20, 20);
            Console.WriteLine("Hello GFG!");
            Console.Write("Press any key to continue . . . ");

            Console.ReadKey(true);

        }
    }
}
