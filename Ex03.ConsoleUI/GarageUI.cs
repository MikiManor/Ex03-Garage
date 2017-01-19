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
            Console.Clear();
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
                Console.WriteLine("License plate = {0}, Owner name = {1}, Phone number = {2}", dataMember.Key, dataMember.Value.OwnerName, dataMember.Value.PhoneNumber);
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
            PrintFrame("Add a new vehicle to fix");
            string vehicleID = GetvehicleID(); //check if already in -> status = in repair (in gragecontroller)
            string manufacturer = GetInputFromUser<string>("\tPlease enter car manufacturer: ");
            string ownerName = GetInputFromUser<string>("\tPlease enter owner name: ");
            string phoneNumber = GetInputFromUser<string>("\tPlease enter phone number: ");
            GarageController.eVehicleType vehicleType = PrintVehicleType();
            GarageController.eEngineType enginType = PrintEngineType();
            //get wheels
            if (vehicleType == GarageController.eVehicleType.Car)
            {
                Car.eNumOfDoors numOfDoors = PrintNumOfDoors();
                Car.eColor carColor = PrinCarColor();
                if (enginType == GarageController.eEngineType.Electic)
                {
                    float batteryLeft = GetBatteryTimeLeft();
                    m_MyGarage.AddNewVehicleElectricCar(vehicleID, manufacturer, ownerName, phoneNumber, numOfDoors, carColor, batteryLeft, wheels);
                }
                else if (enginType == GarageController.eEngineType.Fuel)
                {

                }
            }
            else if (vehicleType == GarageController.eVehicleType.MotorCycle)
            {
                MotorCycle.eLicenseType licenseType = PrintlicenseType();
                int engineVolume = GetInputFromUser<int>("\tPlease enter engine volume: ");
                if (enginType == GarageController.eEngineType.Electic)
                {
                    float batteryLeft = GetBatteryTimeLeft();
                    m_MyGarage.AddNewVehicleElectricCar(vehicleID, manufacturer, ownerName, phoneNumber, numOfDoors, carColor, batteryLeft, wheels);
                }
                else if (enginType == GarageController.eEngineType.Fuel)
                {

                }
            }
            else if (vehicleType == GarageController.eVehicleType.Truck)
            {

            }
        }

        private Car.eColor PrinCarColor()
        {
            string msg = string.Format("\tPlease enter vehicle color:{0}{1}1. blue{0}{1}2. white{0}{1}3. black{0}{1}4. silver{0}{1}>", Environment.NewLine, "\t");
            //add input error
            Car.eColor carColor = GetEnumFromUser<Car.eColor>(msg);
            return carColor;
        }

        private Car.eNumOfDoors PrintNumOfDoors()
        {
            string msg = string.Format("\tPlease enter number of doors:{0}{1}2. two{0}{1}3. three{0}{1}4. four{0}{1}5. five{0}{1}>", Environment.NewLine, "\t");
            //add input error
            Car.eNumOfDoors numOfDoors = GetEnumFromUser<Car.eNumOfDoors>(msg);
            return numOfDoors;
        }

        private GarageController.eVehicleType PrintVehicleType()
        {
            string msg = string.Format("\tPlease enter vehicle type:{0}{1}1. car{0}{1}2. motorcycle{0}{1}3. truck{0}{1}>", Environment.NewLine, "\t");
            //add input error
            GarageController.eVehicleType vehicleType = GetEnumFromUser<GarageController.eVehicleType>(msg);
            return vehicleType;
        }

        private GarageController.eEngineType PrintEngineType()
        {
            string msg = string.Format("\tPlease enter engine type:{0}{1}1. Electic{0}{1}2. Fuel{0}{1}>", Environment.NewLine, "\t");
            //add input error
            GarageController.eEngineType engineType = GetEnumFromUser<GarageController.eEngineType>(msg);
            return engineType;
        }

        private MotorCycle.eLicenseType PrintlicenseType()
        {
            string msg = string.Format("\tPlease enter license type:{0}{1}1. A{0}{1}2. A1{0}{1}3. A2{0}{1}4. B{0}{1}>", Environment.NewLine, "\t");
            //add input error
            MotorCycle.eLicenseType licenseType = GetEnumFromUser<MotorCycle.eLicenseType>(msg);
            return licenseType;
        }
        

        private void ShowListOfVehicle()
        {
            PrintFrame("Show list of vehicle");
            PrintDictionary(m_MyGarage.m_GarageDictionary);
            // 2. show vehicle lists(iD), can filter by status
        }

        private void ChangeVehicleStatus()
        {
            PrintFrame("Change vehicle status");
            string vehicleID = GetvehicleID();
            // 3. change status (id) -> new status
        }

        private void FillUpAirInTheTiersToTheMaximum()
        {
            PrintFrame("Fill up air in the tiers to the maximum");
            string vehicleID = GetvehicleID();
            // 4. float air in wheel to max (id)
        }

        private void FuelUpAVehicle()
        {
            PrintFrame("Fuel up a vehicle");
            string vehicleID = GetvehicleID();
            // 5. fual (non electric) (id, fual type, qty)
        }

        private void ChargeUpAnElectricVehicle()
        {
            PrintFrame("Charge up an electric vehicle");
            string vehicleID = GetvehicleID();
            // 6. charge (non fual) (id, min to charge)
        }

        private void ShowVehicleFullDetails()
        {
            PrintFrame("Show vehicle full details");
            string vehicleID = GetvehicleID();
            // 7. show full details (id) -> id, model name, owners, status, wheel air, wheel maker, fual or electric + details, ect...
        }

        private T GetEnumFromUser<T>(string msg)
        {
            T enumValue;
            Console.Write(msg);
            enumValue = (T)Enum.Parse(typeof(T), Console.ReadLine());
            //    Console.WriteLine("\tBad input, try again...");//add input error
            return enumValue;
        }

        private T GetInputFromUser <T> (string msg)
        {
            Console.Write(msg);
            string input = Console.ReadLine();
            return (T) Convert.ChangeType(input, typeof(T)); //try bad input
        }

        private string GetvehicleID()
        {
            return GetInputFromUser<string>("\tPlease Enter vehicle license plate: ");
        }

        private float GetBatteryTimeLeft()
        {
            return GetInputFromUser<float>("\tPlease enter battery time that is Left: ");
        }

    }
}