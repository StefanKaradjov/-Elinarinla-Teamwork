using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to Hangman!");
            string[] listwords = new string[10];
            listwords[0] = "language";
            listwords[1] = "football";
            listwords[2] = "computer";
            listwords[3] = "program";
            listwords[4] = "function";
            listwords[5] = "method";
            listwords[6] = "exercise";
            listwords[7] = "homework";
            listwords[8] = "selenium";
            listwords[9] = "matrix";
            Random randGen = new Random();
            var idx = randGen.Next(0, 9);
            string mysteryWord = listwords[idx];
            char[] guess = new char[mysteryWord.Length];
            Console.Write("Enter letter: ");

            for (int p = 0; p < mysteryWord.Length; p++)
                guess[p] = '-';

            while (true)
            {
                char playerGuess = char.Parse(Console.ReadLine());
                for (int j = 0; j < mysteryWord.Length; j++)
                {
                    if (playerGuess == mysteryWord[j])
                        guess[j] = playerGuess;
                }
                Console.WriteLine(guess); 
            }
        }
    }
}