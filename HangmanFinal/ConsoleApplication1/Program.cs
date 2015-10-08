using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading;

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
                Thread.Sleep(2000);
                Console.Clear();
            }

            Console.WriteLine();

            // End of title











            string responce = String.Empty;

            do
            {
                Console.WriteLine("Do you want to play?\nPlease enter for yes- 'Y' or for no- 'N'");
                responce = Console.ReadLine().ToUpper();

                if (responce == "N")
                {
                    Console.WriteLine("Good bye!");
                    break;
                }
                Console.Clear();

                int lives = 5;
                drawingTheHangmanString = new string('-', 10) + Environment.NewLine;

                Random rnd = new Random();
                index = rnd.Next(0, 9);

                foreach (var ch in animals[index])
                {
                    mask.Add('_');
                }

                int counter = mask.Count;
                DrawBoard(lives);

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
                            DrawBoard(lives);
                            Console.WriteLine(drawingTheHangmanString);
                            Console.WriteLine("You've alredy tried this letter!");
                            input = char.Parse(Console.ReadLine().ToLower());
                        }
                        else
                        {
                            notguessedChars.Add(input);
                            lives--;
                            Console.Clear();
                            DrawBoard(lives);
                            Console.WriteLine(initialDrawing(lives));

                            if (lives <= 0)
                            {
                                break;
                            }
                            input = char.Parse(Console.ReadLine().ToLower());
                        }
                    }

                    while (animals[index].Contains(input)) // the char is actually in the string
                    {
                        Console.Clear();


                        if (mask.Contains(input))
                        {
                            DrawBoard(lives);
                            Console.WriteLine(drawingTheHangmanString);
                            Console.WriteLine("You've alredy guessed that letter!");
                            input = char.Parse(Console.ReadLine().ToLower());

                            break;
                        }

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
                            //TODO the hangman doesn't show up in case of winning
                            win = true;
                            DrawBoard(lives);
                            break;
                        }
                        DrawBoard(lives);
                        Console.WriteLine(drawingTheHangmanString);

                        input = char.Parse(Console.ReadLine().ToLower());


                    }

                }

                // WIN And LOSE titles
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
                    notguessedChars.Clear();
                    mask.Clear();
                    index = 0;
                }
                //LOSE
                else
                {
                    //TODO in case of losing (picture)
                    initialDrawing(lives);
                    Console.WriteLine(youlose);
                    notguessedChars.Clear();
                    mask.Clear();
                    index = 0;

                }

                // Console.WriteLine("you win");

                win = false;
            } while (responce != "N");

        }
        public static void DrawBoard(int lives)

        {
            using (var reader = new StreamReader("../../HangmanTitle.txt"))
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (line.Length / 2)) + "}", line);

                    line = reader.ReadLine();
                }
            }

            Console.WriteLine(animalsHint[index]); // prints the hint

            foreach (var VARIABLE in mask)
            {
                Console.Write(VARIABLE + " ");
            }

            // prints the mask
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

    }
}