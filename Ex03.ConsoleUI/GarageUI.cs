﻿using System;
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
                    try
                    {
                        AddNewVehicleToFix();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (menuChoice == eMenu.ShowListOfVehicle)
                {
                    try
                    {
                        ShowListOfVehicle();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (menuChoice == eMenu.ChangeVehicleStatus)
                {
                    try
                    {
                        ChangeVehicleStatus();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (menuChoice == eMenu.FillUpAirInTheTiersToTheMaximum)
                {
                    try
                    {
                        FillUpAirInTheTiersToTheMaximum();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (menuChoice == eMenu.FuelUpAVehicle)
                {
                    try
                    {
                        FuelUpAVehicle();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (menuChoice == eMenu.ChargeUpAnElectricVehicle)
                {
                    try
                    {
                        ChargeUpAnElectricVehicle();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (menuChoice == eMenu.ShowVehicleFullDetails)
                {
                    try
                    {
                        ShowVehicleFullDetails();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                Console.Write("\n\tReturning to main menu, press any key ...");
                Console.ReadLine();
            }
            while (true);
        }
         
        public void PrintVehicleDataDictionary(Dictionary<string, VehicleData> i_Dictionary)
        {
            if (i_Dictionary.Count == 0)
            {
                throw new Exception("\tThere are no vehicles in the garage!");
            }
            else
            {
                PrintFrame("Vehicle Data List");
                foreach (KeyValuePair<string, VehicleData> dataMember in i_Dictionary)
                {
                    if (dataMember.Value == null)
                    {
                        Console.WriteLine("No datta");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("{4}License plate = {0}, Status = {3}, Owner name = {1}, Phone number = {2}", dataMember.Key, dataMember.Value.OwnerName, dataMember.Value.PhoneNumber, dataMember.Value.VehicleStatus, "\t");
                    }
                }
            }
        }

        public void PrintvehiclePropertiesDictionary(Dictionary<int, string> i_Dictionary)
        {
            foreach (KeyValuePair<int, string> dataMember in i_Dictionary)
            {
                if (dataMember.Value == null)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("{0}{1} =  {2}", "\t", dataMember.Key, dataMember.Value);
                }
            }
        }

        public void PrintFullVehiclel(string i_key)
        {
            VehicleData currentVehiclel;
            if (m_MyGarage.GarageDictionary.TryGetValue(i_key, out currentVehiclel))
            {
                Console.WriteLine(currentVehiclel.NewVehicle.ToString());
            }
            else
            {
                Console.WriteLine("\tVehicle license plate not found...");
            }
        }

        public void AddWheels()
        {
            List<WheelCollection> wheelsList = new List<WheelCollection>(m_MyGarage.m_CurrentVehicleData.NewVehicle.NumOfWheels - 1); ////get max wheels from class typeOfVehicleFromUser.MaxWheels
            for (int i = 0; i < m_MyGarage.m_CurrentVehicleData.NewVehicle.NumOfWheels; i++)
            {
                try
                {
                    WheelCollection vehicleWheel = new WheelCollection();
                    Console.WriteLine("\tWheel nummber {0}: ", i + 1);
                    string tireFirma = GetInputFromUser<string>("\tPlease enter wheel firma > ");
                    float currentAirPreasure = GetInputFromUser<float>("\tPlease enter wheel current air preasure  > ");
                    vehicleWheel.CurrentAirPreasure = currentAirPreasure;
                    vehicleWheel.WheelFirma = tireFirma;
                    wheelsList.Add(vehicleWheel);
                }
                catch (Exception ex)
                {
                    m_MyGarage.m_GarageDictionary.Remove(m_MyGarage.m_CurrentVehicleData.NewVehicle.LicenseNumber);
                    throw new FormatException("\t" + ex.Message);
                }
            }

            m_MyGarage.MakeWheels(wheelsList);
        }

        public void AddVehicleProperties()
        {
            Dictionary<int, string> vehicleProperties = m_MyGarage.GetVehicleProperties();
            bool isValide;
            int index = 1;
            foreach (var item in vehicleProperties)
            {
                isValide = false;
                do
                {
                    try
                    {
                        string input = GetInputFromUser<string>("\t" + item.Key + " - " + item.Value + "\t> ");
                        m_MyGarage.m_CurrentVehicleData.NewVehicle.SetVehicleProperty(index, input);
                        isValide = true;
                        index++;
                    }
                    catch (Exception ex)
                    {
                        m_MyGarage.m_GarageDictionary.Remove(m_MyGarage.m_CurrentVehicleData.NewVehicle.LicenseNumber);
                        throw new FormatException("\t" + ex.Message);
                    }
                }
                while (!isValide);
            }
        }

        public void AddEngineProperties()
        {
            Dictionary<int, string> engineProperties = m_MyGarage.GetEngineProperties();
            bool isValide;
            int index = 1;
            foreach (var item in engineProperties)
            {
                isValide = false;
                do
                {
                    try
                    {
                        string input = GetInputFromUser<string>("\t" + item.Key + " - " + item.Value + "\t> ");
                        m_MyGarage.m_CurrentVehicleData.NewVehicle.Engine.SetEngineProperty(index, input);
                        isValide = true;
                        index++;
                    }
                    catch (Exception ex)
                    {
                        m_MyGarage.m_GarageDictionary.Remove(m_MyGarage.m_CurrentVehicleData.NewVehicle.LicenseNumber);
                        throw new FormatException("\t" + ex.Message);
                    }
                }
                while (!isValide);
            }
        }

        public void GetTypesOfVehicles()
        {
            int index = 1;
            foreach (GarageController.eVehicleType val in Enum.GetValues(typeof(GarageController.eVehicleType)))
            {
                Console.WriteLine("\t{0} - {1}", index, val);
                index++;
            }
        }

        private eMenu GetUserChoice()
        {
            eMenu menuChoice = eMenu.NoMenuChoice;
            try
            {
                menuChoice = GetEnumFromUser<eMenu>(string.Empty);
            }
            catch (Exception)
            {
                menuChoice = eMenu.NoMenuChoice;
            }

            return menuChoice;
        }
        
        private void AddNewVehicleToFix()
        {
            PrintFrame("Add a new vehicle to garage");
            string vehicleID = GetInputFromUser<string>("\tPlease Enter vehicle license plate > ");
            if (m_MyGarage.m_GarageDictionary.ContainsKey(vehicleID))
            {
                Console.WriteLine("\tLicense plate allready in! vehicle status will change to \"In Repair\"");
                m_MyGarage.ChangeVehicleStatus(vehicleID, GarageController.eVehicleStatus.InRepair);
            }
            else
            {
                string ownerName = GetInputFromUser<string>("\tPlease enter owner name > ");
                string phoneNumber = GetInputFromUser<string>("\tPlease enter phone number > ");
                try
                {
                    GarageController.eVehicleType typeOfVehicleFromUser = getVehicleTypeFromUser();
                    m_MyGarage.AddCarToGarage(ownerName, phoneNumber, vehicleID, typeOfVehicleFromUser);
                    AddVehicleProperties();
                    AddEngineProperties();
                    AddWheels();
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("\t" + ex.Message);
                }
            }
        }

        private void ShowListOfVehicle()
        {
            PrintFrame("Show list of vehicle");
            try
            {
                PrintVehicleDataDictionary(m_MyGarage.m_GarageDictionary);
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("\t" + ex.Message);
            }
        }

        private void ChangeVehicleStatus()
        {
            PrintFrame("Change vehicle status");
            string vehicleID = GetvehicleID();
            Console.WriteLine("\tChoose vehicle new status");

            try
            {
                GarageController.eVehicleStatus newStatus = GetEnumFromUser<GarageController.eVehicleStatus>(GetListOfStatuses());
                m_MyGarage.ChangeVehicleStatus(vehicleID, newStatus);
                Console.WriteLine("\tStatus change complete!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("\t" + ex.Message);
            }
        }

        private void FillUpAirInTheTiersToTheMaximum()
        {
            PrintFrame("Fill up air in the tiers to the maximum");
            string vehicleID = GetvehicleID();
            try
            {
                m_MyGarage.FillUpWheelsToTheMaximun(vehicleID);
                Console.WriteLine("\tAll wheels are filled up to the maximum");
            }
            catch (Exception ex)
            {
                Console.WriteLine("\t" + ex.Message);
            }
        }

        private void FuelUpAVehicle()
        {
            PrintFrame("Fuel up a vehicle");
            string vehicleID = GetvehicleID();
            if (m_MyGarage.IsFuelEngine(vehicleID))
            {
                int fuelTypeSelection = GetInputFromUser<int>(GetEngineFuelType() + "\t>");
                float fuelToAdd = GetInputFromUser<float>("\tEnter amount of fuel to add : ");
                try
                {
                    m_MyGarage.FuelUpAVehicle(vehicleID, (eFuelType)fuelTypeSelection, fuelToAdd);
                    Console.WriteLine("\tCar Is Fulled up");
                }
                catch (ValueOutOfRangeException vore)
                {
                    Console.WriteLine("\t" + vore.Message + " Values Between " + vore.MinValue + " - " + vore.MaxValue);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\t" + ex.Message);
                }
            }
            else
            {
                throw new ArgumentException("\tThis vehicle is not Fuel vehicle!");
            }
        }

        private void ChargeUpAnElectricVehicle()
        {
            PrintFrame("Charge up an electric vehicle");
            string vehicleID = GetvehicleID();
            if (!m_MyGarage.IsFuelEngine(vehicleID))
            {
                float amountOfHoursToAdd = GetInputFromUser<float>("\tPlease enter amount of hours to charge : ");
                try
                {
                    m_MyGarage.ChargeAVehicle(vehicleID, amountOfHoursToAdd);
                    Console.WriteLine("Vehicle has been charged");
                }
                catch (ValueOutOfRangeException vore)
                {
                    Console.WriteLine("\t" + vore.Message + " Values Between " + vore.MinValue + " - " + vore.MaxValue);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\t" + ex.Message);
                }
            }
            else
            {
                throw new ArgumentException("\tThis vehicle is not Electric!");
            }
        }

        private void ShowVehicleFullDetails()
        {
            PrintFrame("Show vehicle full details");
            string vehicleID = GetvehicleID();
            PrintFullVehiclel(vehicleID);
        }

        private T GetEnumFromUser<T>(string msg)
        {
            T enumValue;
            Console.Write(msg);
            string userChoise = Console.ReadLine();
            if (Enum.IsDefined(typeof(T), (T)Enum.Parse(typeof(T), userChoise)))
            {
                enumValue = (T)Enum.Parse(typeof(T), userChoise);
            }
            else
            {
                throw new ArgumentException("\tGot unknown option! Try again.");
            }

            return enumValue;
        }

        private T GetInputFromUser<T>(string msg)
        {
            Console.Write(msg);
            string input = Console.ReadLine();
            if (input != string.Empty)
            {
                return (T)Convert.ChangeType(input, typeof(T));
            }
            else
            {
                throw new FormatException("\tValue cannot be blank!");
            }
        }

        private string GetvehicleID()
        {
            string vehicleID = GetInputFromUser<string>("\tPlease Enter vehicle license plate > ");
            if (!m_MyGarage.IsLicenseInGarage(vehicleID))
            {
                throw new FormatException("\tThere is not vehicle with this license number");
            }
            else
            {
                return vehicleID;
            }
        }

        private string GetEngineFuelType()
        {
            return m_MyGarage.GetEngineFuelType();
        }

        private GarageController.eVehicleType getVehicleTypeFromUser()
        {
            GetTypesOfVehicles();
            GarageController.eVehicleType choice = GetEnumFromUser<GarageController.eVehicleType>("\tplease choose type > ");
            return choice;
        }

        private string GetListOfStatuses()
        {
            StringBuilder stringBuilder = new StringBuilder();
            int index = 1;
            foreach (GarageController.eVehicleStatus currentType in Enum.GetValues(typeof(GarageController.eVehicleStatus)))
            {
                stringBuilder.AppendFormat("\t{0} - {1}{2}", index.ToString(), currentType.ToString(), Environment.NewLine);
                index++;
            }

            stringBuilder.AppendFormat("\t> ");
            return stringBuilder.ToString();
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
    }
}