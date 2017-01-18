using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.ConsoleUI
{
    public class Menu
    {
        public static void RunMenu()
        {
            int menuchoice;
            do
            {
                Console.Clear();
                PrintMenu();
                menuchoice = GetUserChoice();
                if (menuchoice < 0 || menuchoice > 7)
                {
                    Console.Write("\tBad input, press any key to try again...");
                    Console.ReadLine();
                }
                else if (menuchoice == 0)
                {
                    Console.Write("\tGoodbye, press any key...");
                    Console.ReadLine();
                    Environment.Exit(0);
                }
                else if (menuchoice == 1)
                {
                    Menu1();
                }
                else if (menuchoice == 2)
                {
                    Menu2();
                }
                else if (menuchoice == 3)
                {
                    Menu3();
                }
                else if (menuchoice == 4)
                {
                    Menu4();
                }
                else if (menuchoice == 5)
                {
                    Menu5();
                }
                else if (menuchoice == 6)
                {
                    Menu6();
                }
                else if (menuchoice == 7)
                {
                    Menu7();
                }
                Console.Write("\tReturning to main menu, press any key ...");
                Console.ReadLine();
            }
            while (true);
        }

        private static void PrintMenu()
        {
            PrintFrame();
            Console.WriteLine("\t1. Add a new vehicle to fix");
            Console.WriteLine("\t2. Show list of vehicle");
            Console.WriteLine("\t3. Change vehicle status");
            Console.WriteLine("\t4. Fill up air in the tiers to the maximum");
            Console.WriteLine("\t5. Fuel up a vehicle");
            Console.WriteLine("\t6. Charge up an electric vehicle");
            Console.WriteLine("\t7. Show vehicle full details");
            Console.WriteLine("\t0. Exit");
            Console.WriteLine();
            Console.Write("\tPlease Choose > ");
        }

        private static void PrintFrame(string i_header = "Menu")
        {
            Console.Write("{0}{0}", Environment.NewLine);
            Console.WriteLine("**********************************************************************");
            Console.WriteLine();
            Console.WriteLine("\t\t{0}\t", i_header);
            Console.WriteLine("\t-----------------------------------------");
            Console.Write("{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}{0}", Environment.NewLine);
            Console.WriteLine("**********************************************************************");
            Console.SetCursorPosition(0, 6);
        }

        private static int GetUserChoice()
        {
            int menuchoice;
            try
            {
                menuchoice = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                menuchoice = -1;
            }

            return menuchoice;
        }

        private static void Menu1()
        {
            int vehicleID;

            Console.Clear();
            PrintFrame("Add a new vehicle to fix");
            Console.Write("\tPlease Enter vehicle ID: ");
            do
            {
                vehicleID = GetUserChoice();
                if (vehicleID == -1)
                {
                    Console.Write("\tBad input, press any key to try again...");
                    Console.ReadLine();
                }
                else
                {
                    // 1. add new vehicle (check if already in -> status = in repair)

                }
            }
            while (vehicleID == -1);
        }

        private static void Menu2()
        {
            Console.Clear();
            PrintFrame("Show list of vehicle");
            // 2. show vehicle lists(iD), can filter by status
        }
        private static void Menu3()
        {
            int vehicleID;

            Console.Clear();
            PrintFrame("Change vehicle status");
            Console.Write("\tPlease Enter vehicle ID: ");
            do
            {
                vehicleID = GetUserChoice();
                if (vehicleID == -1)
                {
                    Console.Write("\tBad input, press any key to try again...");
                    Console.ReadLine();
                }
                else
                {
                    // 3. change status (id) -> new status
                }
            }
            while (vehicleID == -1);
        }

        private static void Menu4()
        {
            int vehicleID;

            Console.Clear();
            PrintFrame("Fill up air in the tiers to the maximum");
            Console.Write("\tPlease Enter vehicle ID: ");
            do
            {
                vehicleID = GetUserChoice();
                if (vehicleID == -1)
                {
                    Console.Write("\tBad input, press any key to try again...");
                    Console.ReadLine();
                }
                else
                {
                    // 4. float air in wheel to max (id)
                }
            }
            while (vehicleID == -1);
        }

        private static void Menu5()
        {
            int vehicleID;

            Console.Clear();
            PrintFrame("Fuel up a vehicle");
            Console.Write("\tPlease Enter vehicle ID: ");
            do
            {
                vehicleID = GetUserChoice();
                if (vehicleID == -1)
                {
                    Console.Write("\tBad input, press any key to try again...");
                    Console.ReadLine();
                }
                else
                {
                    // 5. fual (non electric) (id, fual type, qty)
                }
            }
            while (vehicleID == -1);
        }

        private static void Menu6()
        {
            int vehicleID;

            Console.Clear();
            PrintFrame("Charge up an electric vehicle");
            Console.Write("\tPlease Enter vehicle ID: ");
            do
            {
                vehicleID = GetUserChoice();
                if (vehicleID == -1)
                {
                    Console.Write("\tBad input, press any key to try again...");
                    Console.ReadLine();
                }
                else
                {
                    // 6. charge (non fual) (id, min to charge)
                }
            }
            while (vehicleID == -1);
        }

        private static void Menu7()
        {
            int vehicleID;

            Console.Clear();
            PrintFrame("Show vehicle full details");
            Console.Write("\tPlease Enter vehicle ID: ");
            do
            {
                vehicleID = GetUserChoice();
                if (vehicleID == -1)
                {
                    Console.Write("\tBad input, press any key to try again...");
                    Console.ReadLine();
                }
                else
                {
                    // 7. show full details (id) -> id, model name, owners, status, wheel air, wheel maker, fual or electric + details, ect...
                }
            }
            while (vehicleID == -1);
        }
    }
}








