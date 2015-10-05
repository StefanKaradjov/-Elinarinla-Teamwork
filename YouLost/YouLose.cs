using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    class YouLose
    {
        static void Main()
        {
            Console.WriteLine();
            Console.WriteLine();
            string youLose = new string(' ', Console.WindowWidth / 2 - 59 / 2) + "*   *" + "  " + " ** " + "  " + "*   *" + "   " + "*   " + "  " + " ** " + "  " + new string('*', 4) + "  " + new string('*', 4) + "\n" +
                          new string(' ', Console.WindowWidth / 2 - 59 / 2) + " * * " + "  " + "*  *" + "  " + "*   *" + "   " + "*   " + "  " + "*  *" + "  " + "*   " + "  " + "*   " + "\n" +
                          new string(' ', Console.WindowWidth / 2 - 59 / 2) + "  *  " + "  " + "*  *" + "  " + "*   *" + "   " + "*   " + "  " + "*  *" + "  " + new string('*', 4) + "  " + new string('*', 4) + "\n" +
                          new string(' ', Console.WindowWidth / 2 - 59 / 2) + "  *  " + "  " + "*  *" + "  " + "*   *" + "   " + "*   " + "  " + "*  *" + "  " + "   *" + "  " + "*   " + "\n" +
                          new string(' ', Console.WindowWidth / 2 - 59 / 2) + "  *  " + "  " + " ** " + "  " + " ***  " + "  " + new string('*', 4) + "  " + " ** " + "  " + new string('*', 4) + "  " + new string('*', 4) + "\n";



            Console.WriteLine(youLose);
        }
    }
