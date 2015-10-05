using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hangman
{
    class Program
    {
        //Global Variables
        static string[] animals = new[] { "tiger", "penguin", "germany", "egypt", "wolf", "hugh jackman", "chuck norris", "elon musk", "hulk", "tony stark" };
        static string[] animalsHint = new[]
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

            Random rnd = new Random();
            index = rnd.Next(0, 9);
            foreach (var ch in animals[index])
            {
                mask.Add('_');
            }
            int counter = mask.Count;
            DrawBoard();

            //input
            char input = char.Parse(Console.ReadLine().ToLower());

            //main logic
            while (lives > 0 && win == false)
            {
                // char is not in the string
                while (!animals[index].Contains(input))
                {
                    if (notguessedChars.Contains(input))
                    {
                        Console.Clear();
                        DrawBoard();
                        Console.WriteLine(initialDrawing(lives));
                        Console.WriteLine("You alredy tried this letter!");
                        input = char.Parse(Console.ReadLine().ToLower());
                    }
                    else
                    {
                        notguessedChars.Add(input);
                        lives--;
                        Console.Clear();
                        DrawBoard();
                        Console.WriteLine(initialDrawing(lives));
                        input = char.Parse(Console.ReadLine().ToLower());
                    }
                }

                while (animals[index].Contains(input)) // the char is actually in the string
                {
                    Console.Clear();

                    //check if there is more than one letter
                    for (int i = 0; i<animals[index].Length; i++)
                    {
                        if (animals[index][i] == input)
                        {
                            mask[i] = input;
                            counter--;
                        }
                    }
                    if (counter == 0)
                    {
                        win = true;
                        break;
                    }
                    DrawBoard();
                    Console.WriteLine(drawingTheHangmanString);
                    input = char.Parse(Console.ReadLine().ToLower());

                }


          
               



            }
            if (win)
            {
                Console.WriteLine("You win");
            }
            else
            {

                initialDrawing(lives);

            }

            // Console.WriteLine("you win");

        }

        public static void DrawBoard()
        {
            Console.WriteLine(animalsHint[index]); // prints the hint
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

        public static string initialDrawing(int lives )
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
            
        }
    }

