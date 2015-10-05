using System;
using System.Collections.Generic;
using System.Linq;

namespace Hangman
{
    class Program
    {
        static string[] animals = new string[] { "tiger", "penguin", "germany", "egypt", "wolf", "hugh jackman", "chuck norris", "elon musk", "hulk", "tony stark" };
        static string[] animalsHint = new string[]
        {
            "IT'S THE EYE OF THE...", "Flightless bird","Country in Europe","In Africa/Asia", "lives in packs", "Wolverine", "When he was born he drove his mom home from the hospital",
            "SpaceX 'n' Tesla.. real life IRON MAN", "... SMASH!", "Iron Man"
        };


        static List<char> notguessedChars = new List<char>();
        private static bool win = false;
        static int index = 0;
        private static string result = string.Empty;
        static int lives = 6;
        static List<char> mask = new List<char>();

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
            while (lives >= 0 && win == false)
            {
                // char is not in the string
                while (!animals[index].Contains(input))
                {
                    if (notguessedChars.Contains(input))
                    {
                        Console.Clear();
                        DrawBoard();
                        Console.WriteLine("You alredy tryed this letter!");
                        input = char.Parse(Console.ReadLine().ToLower());
                    }
                    else
                    {
                        notguessedChars.Add(input);
                        lives--;
                        Console.Clear();
                        DrawBoard();
                        input = char.Parse(Console.ReadLine().ToLower());
                    }
                }

                while (animals[index].Contains(input)) // the char is actually in the string
                {
                    Console.Clear();

                    //check if there is more than one letter
                    for (int i = 0; i < animals[index].Length; i++)
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
                    input = char.Parse(Console.ReadLine().ToLower());

                }


                if (win)
                {
                    Console.WriteLine("You win");
                }
                else
                {
                    Console.WriteLine("You lose");
                }
                //result = string.Join(",", mask.ToArray());



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
    }
}
