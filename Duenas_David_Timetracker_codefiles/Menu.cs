using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace timetracker
{

    class Menu
    {

        public static void ShowMenu()
        {


            Console.Clear();


            Console.WriteLine("***Main Menu***\n\n");
            Console.WriteLine("Welcome " + Login.user_firstname + "\n\n");
            Console.WriteLine("1. Enter Activity");
            Console.WriteLine("2. View Tracked Data");
            Console.WriteLine("3. Run Calculations\n\n");
            Console.WriteLine("4. Exit");

            Console.Write("Enter a selection: (1 - 4): ");
        }

        public static void ActivityMenu()
        {
            Console.WriteLine("1. Pick a category activity");
            Console.WriteLine("2. Main Menu");
        }

        public static void DescriptionMenu()
        {
            Console.WriteLine("1. Pick an Activity Description: ");
            Console.WriteLine("2. Go Back");
        }
        public static void DatePickMenu()
        {
            Console.WriteLine("What Date Did You Perform The Activity?");
            Console.WriteLine("2. Go Back");
        }

        public static void TrackedDataLog()
        {
            Console.WriteLine("1. Select By Date");
            Console.WriteLine("2. Select By Category");
            Console.WriteLine("3. Select By Description");
        }

        public static void RunCalcMenu()
        {
            Console.WriteLine("");
        }

        public static void LogMenu()
        {
            Console.WriteLine("1. Back");
            Console.WriteLine("2. Main Menu");


        }
    }
}
