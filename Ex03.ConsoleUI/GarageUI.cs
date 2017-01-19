using System;
using System.Collections.Generic;
using System.Text;
using Ex03.GarageLogic;
using System.ComponentModel;

namespace Ex03.ConsoleUI
{
    public class GarageUI
    {
        private GarageLogic.GarageController m_MyGarage;

        public GarageUI()
        {
            m_MyGarage = new GarageLogic.GarageController();
        }

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

        public void RunMenu()
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

        private void PrintMenu()
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

        private void PrintFrame(string i_header = "Menu")
        {
            Console.Write("{0}{0}", Environment.NewLine);
            Console.WriteLine("**********************************************************************");
            Console.WriteLine();
            Console.WriteLine("\t\t{0}\t", i_header);
            Console.WriteLine("\t-----------------------------------------");
            Console.Write("{0}", Environment.NewLine);
        }

        public void PrintDictionary(Dictionary<string, VehicleData> i_GarageDictionary)
        {
            PrintFrame("Vehicle Data List");
            foreach (KeyValuePair<string, VehicleData> dataMember in i_GarageDictionary)
            {
                Console.WriteLine("Key = {0}, Value = {1}", dataMember.Key, dataMember.Value);
            }
        }
        private eMenu GetUserChoice()
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

        private void AddNewVehicleToFix()
        {
            Console.Clear();
            
            PrintFrame("Add a new vehicle to fix");
            string vehicleID = GetvehicleID();
            //check if already in -> status = in repair (in gragecontroller)
            Console.Write("\tPlease enter owner name: ");
            string ownerName = Console.ReadLine();
            Console.Write("\tPlease enter phone number: ");
            string phoneNumber = Console.ReadLine();
            GarageController.eVehicleType i_VehicleType = PrintVehicleType(); "\tPlease enter vehicle type:{0}{1}1. car{0}{1}2. motorcycle{0}{1}3. truck{0}{1}>", Environment.NewLine, "\t"
            Console.Write("\tPlease enter model name: ");
            string modelName = Console.ReadLine();
            if (i_VehicleType == GarageController.eVehicleType.Car)
            {
                
                GarageController.eVehicleType vehicleType = (GarageController.eVehicleType)Enum.Parse(typeof(GarageController.eVehicleType), Console.ReadLine());
                if (numOfDoors == GetEnumFromUser<Car.eNumOfDoors>(""))
                {
                    AddNewVehicleElectricCar();
                }
                AddNewVehicleCarUI(vehicleID, ownerName, phoneNumber, modelName);
            }
            else if (i_VehicleType == GarageController.eVehicleType.MotorCycle)
            {
                AddNewVehicleMotorCycleUI(vehicleID, ownerName, phoneNumber, modelName);
            }
            else if (i_VehicleType == GarageController.eVehicleType.Truck)
            {
                AddNewVehicleTruckUI(vehicleID, ownerName, phoneNumber, modelName);
            }

        }

        private void AddNewVehicleCarUI(string i_VehicleID, string i_OwnerName, string i_PhoneNumber, string i_modelName)
        {
            Car.eColor carColor = GetEnumFromUser<Car.eColor>(string.Format("\tPlease enter number of doors:{0}{1}1. blue{0}{1}2. white{0}{1}3. black{0}{1}4. silver{0}{1}>", Environment.NewLine, "\t"));
            Car.eNumOfDoors numOfDoors = GetEnumFromUser<Car.eNumOfDoors>(string.Format("\tPlease enter number of doors:{0}{1}1. blue{0}{1}2. white{0}{1}3. black{0}{1}4. silver{0}{1}>", Environment.NewLine, "\t"));
            m_MyGarage.AddNewVehicleCar(i_modelName, i_VehicleID, i_OwnerName, i_PhoneNumber);
        } 

        private void AddNewVehicleMotorCycleUI(string i_VehicleID, string i_OwnerName, string i_PhoneNumber, string i_modelName)
        {
            GarageController.eVehicleType vehicleType = GetEnumFromUser<GarageController.eVehicleType>(msg);
        }

        private void AddNewVehicleTruckUI(string i_VehicleID, string i_OwnerName, string i_PhoneNumber)
        {
            GarageController.eVehicleType vehicleType = GetEnumFromUser<GarageController.eVehicleType>(msg);
        }

        private GarageController.eVehicleType PrintVehicleType()
        {
            string msg = string.Format("\tPlease enter vehicle type:{0}{1}1. car{0}{1}2. motorcycle{0}{1}3. truck{0}{1}>", Environment.NewLine, "\t");
            //add input error
            GarageController.eVehicleType vehicleType = GetEnumFromUser<GarageController.eVehicleType>(msg);
            return vehicleType;
        }

        Console.Write("\tPlease enter engine type:{0}{1}1. electric{0}{1}2. fuel{0}{1}>", Environment.NewLine, "\t");
            GarageController.eEngineType engineType = (GarageController.eEngineType)Enum.Parse(typeof(GarageController.eEngineType), Console.ReadLine());

        private T GetEnumFromUser <T> (string msg)
        {
            T enumValue;
            Console.Write(msg);
            enumValue = (T)Enum.Parse(typeof(GarageController.eVehicleType), Console.ReadLine());
            //    Console.WriteLine("\tBad input, try again...");
            return enumValue;
        }


        private void ShowListOfVehicle()
        {
            Console.Clear();
            PrintFrame("Show list of vehicle");
            m_MyGarage.ShowListOfVehicle();
            // 2. show vehicle lists(iD), can filter by status
        }

        private void ChangeVehicleStatus()
        {
            Console.Clear();
            PrintFrame("Change vehicle status");
            string vehicleID = GetvehicleID();
            // 3. change status (id) -> new status
        }

        private void FillUpAirInTheTiersToTheMaximum()
        {
            Console.Clear();
            PrintFrame("Fill up air in the tiers to the maximum");
            string vehicleID = GetvehicleID();
            // 4. float air in wheel to max (id)
        }

        private void FuelUpAVehicle()
        {
            Console.Clear();
            PrintFrame("Fuel up a vehicle");
            string vehicleID = GetvehicleID();
            // 5. fual (non electric) (id, fual type, qty)
        }

        private void ChargeUpAnElectricVehicle()
        {
            Console.Clear();
            PrintFrame("Charge up an electric vehicle");
            string vehicleID = GetvehicleID();
            // 6. charge (non fual) (id, min to charge)
        }

        private void ShowVehicleFullDetails()
        {
            Console.Clear();
            PrintFrame("Show vehicle full details");
            string vehicleID = GetvehicleID();
            // 7. show full details (id) -> id, model name, owners, status, wheel air, wheel maker, fual or electric + details, ect...
        }

        private string GetvehicleID()
        {
            string vehicleID;

            Console.Write("\tPlease Enter vehicle license plate: ");
            vehicleID = Console.ReadLine();
            return vehicleID;
        }
    }
}