using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    class YouWin
    {
        static void Main()
        {
            Console.WriteLine();
            Console.WriteLine();
            string youWin = new string(' ', Console.WindowWidth / 2 - 59 / 2) + "*   *" + "  " + " ** " + "  " + "*   *" + "   " + "*     *" + "  " + "**" + "  " + "*   *" + "\n" +
                           new string(' ', Console.WindowWidth / 2 - 59 / 2) + " * * " + "  " + "*  *" + "  " + "*   *" + "   " + "*     *" + "  " + "  " + "  " + "**  *" + "\n" +
                           new string(' ', Console.WindowWidth / 2 - 59 / 2) + "  *  " + "  " + "*  *" + "  " + "*   *" + "   " + "*     *" + "  " + "**" + "  " + "* * *" + "\n" +
                           new string(' ', Console.WindowWidth / 2 - 59 / 2) + "  *  " + "  " + "*  *" + "  " + "*   *" + "   " + " * * * " + "  " + "**" + "  " + "*  **" + "\n" +
                           new string(' ', Console.WindowWidth / 2 - 59 / 2) + "  *  " + "  " + " ** " + "  " + " ***  " + "  " + "  * *  " + "  " + "**" + "  " + "*   *" + "\n";




                           Console.WriteLine(youWin);
                           }
    }
