﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace Hangman
{
    class Program
    {

        //Global Variables
        static string[] wordToGuess = new[] { "tiger", "penguin", "germany", "egypt", "wolf", "hugh jackman", "chuck norris", "elon musk", "hulk", "tony stark" };
        static string[] guessHint = new[]
        {
            "IT'S THE EYE OF THE...", "Flightless bird","Country in Europe","In Africa/Asia", "lives in packs", "Wolverine", "When he was born he drove his mom home from the hospital",
            "SpaceX 'n' Tesla.. real life IRON MAN", "... SMASH!", "Iron Man"
        };


        static List<char> notguessedChars = new List<char>();
        private static bool win = false;
        static int index = 0;
        static int lives = 5;
        static List<char> mask = new List<char>();
        public static string drawingTheHangmanString = new string('-', 10) + Environment.NewLine;


        static void Main()
        {

            // Hangman Title
            // From here
            Console.WriteLine();
            
            using (var reader = new StreamReader("../../HangmanTitle.txt"))
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (line.Length / 2)) + "}", line);

                    line = reader.ReadLine();
                }
            }

            Console.WriteLine();

            // End of title

            Random rnd = new Random();
            index = rnd.Next(0, 9);
            foreach (var ch in wordToGuess[index])
            {
                mask.Add('_');
            }
            int counter = mask.Count;
            DrawBoard();

            //input
            string input = (Console.ReadLine().ToLower()); //taka a string input
            char letter = correctInput(input); // cheks and brings the correct input

            //main logic
            while (lives > 0 && win == false)
            {
                // char is not in the string
                while (!wordToGuess[index].Contains(letter))
                {
                    if (notguessedChars.Contains(letter))
                    {
                        Console.Clear();
                        DrawBoard();
                        Console.WriteLine(drawingTheHangmanString);
                        Console.WriteLine("You alredy tried this letter!");
                        input = (Console.ReadLine().ToLower());
                        letter = correctInput(input);
                    }
                    else
                    {
                        notguessedChars.Add(letter);
                        lives--;
                        Console.Clear();
                        DrawBoard();
                        Console.WriteLine(initialDrawing(lives));
                        if (lives <= 0)
                        {
                            break;
                        }
                        input = (Console.ReadLine().ToLower());
                        letter = correctInput(input);
                    }
                }

                while (wordToGuess[index].Contains(letter)) // the char is actually in the string
                {
                    Console.Clear();

                    //TODO trqbva da se fixne,za6toto countera se decrementira ako se napi6e ve4e poznata bukva - DONE
                    if (mask.Contains(letter))
                    {
                        DrawBoard();
                        Console.WriteLine(drawingTheHangmanString);
                        Console.WriteLine("You alredy guessed that letter!");
                        input = (Console.ReadLine().ToLower());
                        letter = correctInput(input);

                        break;
                    }

                    //check if there is more than one letter
                    for (int i = 0; i < wordToGuess[index].Length; i++)
                    {
                        if (wordToGuess[index][i] == letter)
                        {
                            mask[i] = letter;
                            counter--;
                        }

                    }

                    if (counter == 0)
                    {
                        //TODO the hangman doesn't show up in case of winning
                        win = true;
                        DrawBoard();
                        break;
                    }
                    DrawBoard();
                    Console.WriteLine(drawingTheHangmanString);
                    input = (Console.ReadLine().ToLower());
                    letter = correctInput(input);


                }

            }

            // WIN And LOse titles
            // From here

            string youwin = String.Empty;
            using (var reader = new StreamReader(@"../../YouWin.txt"))
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    youwin += "\n" + new string(' ', Console.WindowWidth / 2 - 30 / 2) + line;
                    line = reader.ReadLine();
                }
            }

            //Lose

            string youlose = String.Empty;
            using (var reader = new StreamReader(@"../../YouLose.txt"))
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    youlose += "\n" + new string(' ', Console.WindowWidth / 2 - 30 / 2) + line;
                    line = reader.ReadLine();
                }
            }
            
            
            if (win)



            { 
                Console.WriteLine(youwin);
            }
            
                // End of YouWin
                
                
                
            else
            {
                //TODO in case of losing (picture)
                initialDrawing(lives); // risuva 4ove4eto
                Console.WriteLine(youlose);

            }

            // End of YouLose

        }

        public static void DrawBoard()
        {
            Console.WriteLine(guessHint[index]); // prints the hint
            foreach (var VARIABLE in mask)
            {
                Console.Write(VARIABLE + " ");
            } // prints the mask
            Console.WriteLine("\n\n");
            Console.WriteLine("Lives: " + lives); // prints the lives

            Console.Write("Unguessed letters: "); // prints the unguessed letters
            foreach (var VARIABLE in notguessedChars)
            {
                Console.Write(" " + VARIABLE);
            } // prints the mask
            Console.WriteLine();





        }

        public static string initialDrawing(int lives)
        {




            while (lives >= 0)
            {


                if (lives == 5)
                {
                    drawingTheHangmanString += "|        |" + Environment.NewLine; break;

                }
                if (lives == 4)
                {
                    drawingTheHangmanString += "|        O" + Environment.NewLine; break;
                }
                if (lives == 3)
                {
                    drawingTheHangmanString += "|       \\|/" + Environment.NewLine; break;
                }
                if (lives == 2)
                {
                    drawingTheHangmanString += "|        |" + Environment.NewLine; break;
                }
                if (lives == 1)
                {
                    drawingTheHangmanString += "|       / \\" + Environment.NewLine; break;
                }
                //Console.WriteLine("|");
                if (lives == 0)
                {

                    drawingTheHangmanString += new string('-', 7) + new string(' ', 5) + new string('-', 7) + Environment.NewLine;

                    drawingTheHangmanString += "|\\/\\/\\/\\/\\/\\/\\/\\/\\|" + Environment.NewLine;
                    drawingTheHangmanString += new string('-', 7) + new string(' ', 5) + new string('-', 7);
                    break;

                }

            }

            return drawingTheHangmanString;
        }
        public static char correctInput(string input)
        {
            //string input more than 1 letter
            if (input.Length > 1)
            {
                while (input.Length > 1)
                {
                    // new input
                    Console.WriteLine("Incorrect Input.Try again");
                    input = Console.ReadLine().ToLower();

                }
                while (!char.IsLetter(char.Parse(input)))
                {
                    // new input
                    Console.WriteLine("Incorrect Input.Try again");
                    input = Console.ReadLine().ToLower();
                    while (input.Length > 1) // cheks the input
                    {
                        //new inputt
                        Console.WriteLine("Incorrect Input.Try again");
                        input = Console.ReadLine().ToLower();
                    }
                }
            }
            //string input is not a letter
            else
            {
                while (!char.IsLetter(char.Parse(input)))
                {
                    //new inputt
                    Console.WriteLine("Incorrect Input.Try again");
                    input = Console.ReadLine().ToLower();
                    while (input.Length > 1) //cheks the input
                    {
                        //new inputt
                        Console.WriteLine("Incorrect Input.Try again");
                        input = Console.ReadLine().ToLower();
                    }
                }
            }
            char letter = char.Parse(input); // The correct input
            return letter;
        }

    }
}
