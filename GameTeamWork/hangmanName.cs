using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    class hangmanTitle
    {
        static void Main()
        {

            Console.WriteLine();
            Console.WriteLine();
            string hangmanName = new string (' ', Console.WindowWidth / 2 - 59 / 2) + new string('-', 59) + "\n" +
                new string(' ', Console.WindowWidth / 2 - 59 / 2) + new string('*', 2) + "  **" + "  " + " **** " + "  **   **" + "  " + " **** " + "  **     ** " + " " + " **** " + "  " + new string('*', 2) + "   " + new string('*', 2) + "\n" +
                new string(' ', Console.WindowWidth / 2 - 59 / 2) + new string('*', 2) + "  " + new string('*', 2) + "  " + new string('*', 2) + "  " + new string('*', 2) + "  " + new string('*', 3) + "  " + new string('*', 2) + "  " + new string('*', 3) + "     " + "***" + "   " + "***" + "  " + new string('*', 2) + "  " + new string('*', 2) + "  " + new string('*', 3) + "  " + new string('*', 2) + "\n" +
               new string(' ', Console.WindowWidth / 2 - 59 / 2) + new string('*', 6) + "  " + new string('*', 6) + "  " + "** *" + " " + "**" + "  " + "** ***" + "  " + "** *" + " " + "* **" + "  " + new string('*', 6) + "  " + "** *" + " " + "**" + "\n" +
               new string(' ', Console.WindowWidth / 2 - 59 / 2) + new string('*', 2) + "  " + new string('*', 2) + "  " + new string('*', 2) + "  " + new string('*', 2) + "  " + "**  *" + "**" + "  " + "*** **" + "  " + "**  *" + "  **" + "  " + new string('*', 2) + "  " + new string('*', 2) + "  " + "**  *" + "**" + "\n" +
                new string(' ', Console.WindowWidth / 2 - 59 / 2) + new string('*', 2) + "  " + new string('*', 2) + "  " + new string('*', 2) + "  " + new string('*', 2) + "  " + "**   " + "**" + "  " + " **** " + "  " + "**" + "     " + "**" + "  " + new string('*', 2) + "  " + new string('*', 2) + "  " + "**  " + " **" + "\n" +
               new string(' ', Console.WindowWidth / 2 - 59 / 2) + new string('-', 59);



            
            
            
            Console.WriteLine(hangmanName);
        }
    }
