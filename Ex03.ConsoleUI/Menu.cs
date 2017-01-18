using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.ConsoleUI
{
    public class Menu
    {
        private enum eMenu
        {
            MenuExit,
            AddNewVehicleToFix,
            ShowListOfVehicle,
            ChangeVehicleStatus,
            FillUpAirInTheTiersToTheMaximum,
            FuelUpAVehicle,
            ChargeUpAnElectricVehicle,
            ShowVehicleFullDetails,
            NoMenuChoice
        }

        public static void RunMenu()
        {
            eMenu menuChoice;
            do
            {
                Console.Clear();
                PrintMenu();
                menuChoice = GetUserChoice();
                if (!Enum.IsDefined(typeof(eMenu), menuChoice) || menuChoice == eMenu.NoMenuChoice)
                {
                    Console.WriteLine("\tBad input, try again...");
                }
                else if (menuChoice == eMenu.MenuExit)
                {
                    Console.Write("\tGoodbye, press any key...");
                    Console.ReadLine();
                    Environment.Exit(0);
                }
                else if (menuChoice == eMenu.AddNewVehicleToFix)
                {
                    AddNewVehicleToFix();
                }
                else if (menuChoice == eMenu.ShowListOfVehicle)
                {
                    ShowListOfVehicle();
                }
                else if (menuChoice == eMenu.ChangeVehicleStatus)
                {
                    ChangeVehicleStatus();
                }
                else if (menuChoice == eMenu.FillUpAirInTheTiersToTheMaximum)
                {
                    FillUpAirInTheTiersToTheMaximum();
                }
                else if (menuChoice == eMenu.FuelUpAVehicle)
                {
                    FuelUpAVehicle();
                }
                else if (menuChoice == eMenu.ChargeUpAnElectricVehicle)
                {
                    ChargeUpAnElectricVehicle();
                }
                else if (menuChoice == eMenu.ShowVehicleFullDetails)
                {
                    ShowVehicleFullDetails();
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

        private static eMenu GetUserChoice()
        {
            eMenu menuChoice = eMenu.NoMenuChoice;
            try
            {
                menuChoice = (eMenu)Enum.Parse(typeof(eMenu), Console.ReadLine());
            }
            catch (Exception)
            {
                menuChoice = eMenu.NoMenuChoice;
            }

            return menuChoice;
        }

        private static void AddNewVehicleToFix()
        {
            Console.Clear();
            PrintFrame("Add a new vehicle to fix");
            string vehicleID = GetvehicleID();
            // 1. add new vehicle (check if already in -> status = in repair)
        }

        private static void ShowListOfVehicle()
        {
            Console.Clear();
            PrintFrame("Show list of vehicle");
            // 2. show vehicle lists(iD), can filter by status
        }

        private static void ChangeVehicleStatus()
        {
            Console.Clear();
            PrintFrame("Change vehicle status");
            string vehicleID = GetvehicleID();
            // 3. change status (id) -> new status
        }

        private static void FillUpAirInTheTiersToTheMaximum()
        {
            Console.Clear();
            PrintFrame("Fill up air in the tiers to the maximum");
            string vehicleID = GetvehicleID();
            // 4. float air in wheel to max (id)
        }

        private static void FuelUpAVehicle()
        {
            Console.Clear();
            PrintFrame("Fuel up a vehicle");
            string vehicleID = GetvehicleID();
            // 5. fual (non electric) (id, fual type, qty)
        }

        private static void ChargeUpAnElectricVehicle()
        {
            Console.Clear();
            PrintFrame("Charge up an electric vehicle");
            string vehicleID = GetvehicleID();
            // 6. charge (non fual) (id, min to charge)
        }

        private static void ShowVehicleFullDetails()
        {
            Console.Clear();
            PrintFrame("Show vehicle full details");
            string vehicleID = GetvehicleID();
            // 7. show full details (id) -> id, model name, owners, status, wheel air, wheel maker, fual or electric + details, ect...
        }

        private static string GetvehicleID()
        {
            string vehicleID;

            Console.Write("\tPlease Enter vehicle license plate: ");
            vehicleID = Console.ReadLine();
            //if vehicleID bad try again
            return vehicleID;
        }
    }
}