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
                    Console.Write("        Bad input, press any key to try again...");
                    Console.ReadLine();
                }
                else if (menuchoice == 0)
                {
                    Console.Write("        Goodbye, press any key...");
                    Console.ReadLine();
                    Environment.Exit(0);
                }
                else if (menuchoice == 1)
                {
                    //run somthing 1
                }
                else if (menuchoice == 2)
                {
                    //run somthing 2
                }
                else if (menuchoice == 3)
                {
                    //run somthing 3
                }
                else if (menuchoice == 4)
                {
                    //run somthing 4
                }
                else if (menuchoice == 5)
                {
                    //run somthing 5
                }
                else if (menuchoice == 6)
                {
                    //run somthing 6
                }
                else if (menuchoice == 7)
                {
                    //run somthing 7
                }
            }
            while (true);
        }

        private static void PrintMenu()
        {
            Console.Write("{0}{0}**********************************************************************{0}{0}{0}", Environment.NewLine);
            Console.WriteLine("        1. Add a new vehicle to fix");
            Console.WriteLine("        2. Show list of vehicle");
            Console.WriteLine("        3. Change vehicle status");
            Console.WriteLine("        4. Fill up air in the tiers to the maximum");
            Console.WriteLine("        5. Fual up a vehicle");
            Console.WriteLine("        6. Charge up an electric vehicle");
            Console.WriteLine("        7. Show vehicle full details");
            Console.WriteLine("        0. Exit");
            Console.Write("{0}{0}{0}{0}{0}", Environment.NewLine);
            Console.WriteLine("**********************************************************************");
            Console.SetCursorPosition(0, 14);
            Console.Write("        Please Choose > ");
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
    }
}

// 1. add new vehicle (check if already in -> status = in repair)
// 2. show vehicle lists(iD), can filter by status
// 3. change status (id) -> new status
// 4. float air in wheel to max (id)
// 5. fual (non electric) (id, fual type, qty)
// 6. charge (non fual) (id, min to charge)
// 7. show full details (id) -> id, model name, owners, status, wheel air, wheel maker, fual or electric + details, ect...
