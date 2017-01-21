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

        public void PrintVehicleDataDictionary(Dictionary<string, VehicleData> i_Dictionary)
        {
            PrintFrame("Vehicle Data List");
            foreach (KeyValuePair<string, VehicleData> dataMember in i_Dictionary)
            {
                if (dataMember.Value == null)
                {
                    Console.WriteLine("No datta"); //need this?
                    break;
                }
                else
                {
                    Console.WriteLine("License plate = {0}, Owner name = {1}, Phone number = {2}", dataMember.Key, dataMember.Value.OwnerName, dataMember.Value.PhoneNumber);
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
                Console.WriteLine("{1}License plate = {2}{0}{1}Owner name = {3}{0}{1}Phone number = {4}{0}{1}Number Of Wheels = {5}", Environment.NewLine, "\t", i_key, currentVehiclel.OwnerName, currentVehiclel.PhoneNumber, currentVehiclel.NewVehicle.NumOfWheels);
                Console.WriteLine("{1}Vehicle Firma = {2}{0}{1}Vehicle Engine = {3}{0}{1}Energy Left = {4}", Environment.NewLine, "\t", currentVehiclel.NewVehicle.Firma, currentVehiclel.NewVehicle.Engine, currentVehiclel.NewVehicle.EnergyPrecentLeft);
                Dictionary<int, string>  vehicleProperties = currentVehiclel.NewVehicle.GetVheicleProperties();
                PrintvehiclePropertiesDictionary(vehicleProperties);
            }

            else
            {
                Console.WriteLine("Vehicle license plate not found...");
            }
        }
        
        private eMenu GetUserChoice()
        {
            eMenu menuChoice = eMenu.NoMenuChoice;
            try
            {
                menuChoice = GetEnumFromUser<eMenu>("");
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
            string vehicleID = GetvehicleID(); //check if already in -> status = in repair (in gragecontroller)
            string manufacturer = GetInputFromUser<string>("\tPlease enter car manufacturer > ");
            string ownerName = GetInputFromUser<string>("\tPlease enter owner name > ");
            string phoneNumber = GetInputFromUser<string>("\tPlease enter phone number > ");
            GarageController.eVehicleType typeOfVehicleFromUser = getVehicleTypeFromUser();
            try
            {
                m_MyGarage.AddCarToGarage(ownerName, phoneNumber, vehicleID, typeOfVehicleFromUser);
                AddProperties();
                AddWheels();
                
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void ShowListOfVehicle()
        {
            PrintFrame("Show list of vehicle");
            PrintVehicleDataDictionary(m_MyGarage.m_GarageDictionary);
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
            PrintFullVehiclel(vehicleID);
            Console.WriteLine();
            Console.Write("\tpress any key...");
            Console.ReadLine();
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
            return GetInputFromUser<string>("\tPlease Enter vehicle license plate > ");
        }

        private GarageController.eVehicleType getVehicleTypeFromUser()
        {
            GetTypesOfVehicles();
            GarageController.eVehicleType choice = GetEnumFromUser<GarageController.eVehicleType>("\tplease choose type > ");
            return choice;
        }

        public void GetTypesOfVehicles()
        {
            int index = 1;
            foreach (GarageController.eVehicleType val in Enum.GetValues(typeof(GarageController.eVehicleType)))
            {
                Console.WriteLine("\t{0} - {1}",index,val);
                index++;
            }
        }

        public void AddWheels()
        {
            List<WheelCollection> wheelsList = new List<WheelCollection>(m_MyGarage.m_CurrentVehicleData.NewVehicle.NumOfWheels - 1);//get max wheels from class typeOfVehicleFromUser.MaxWheels
            
            for (int i = 0; i < m_MyGarage.m_CurrentVehicleData.NewVehicle.NumOfWheels ; i++)
            {
                WheelCollection vehicleWheel = new WheelCollection();
                string tireFirma = GetInputFromUser<string>("Please enter wheel firma > ");
                Console.WriteLine("\tWheel nummber {0}: ", i+1);
                float currentAirPreasure = GetInputFromUser<float>("Please enter wheel current air preasure  > ");
                vehicleWheel.CurrentAirPreasure = currentAirPreasure;
                vehicleWheel.WheelFirma = tireFirma;
                wheelsList.Add(vehicleWheel);
            }
            m_MyGarage.MakeWheels(wheelsList);
        }

        public void AddProperties()
        {
            Dictionary<int, string> properties = m_MyGarage.GetProperties();
            bool isValide;
            int index = 1;
            foreach (var item in properties)
            {
                
                isValide = false;
                do
                {
                    try
                    {
                        if (m_MyGarage != null) //what??
                        {
                            
                            string input = GetInputFromUser<string>(item.Key + " - " + item.Value + " > ");//??
                            m_MyGarage.m_CurrentVehicleData.NewVehicle.setVehicleProperty(index, input); //bulid it in Vehicle
                            isValide = true;
                            index++;
                        }
                        
                    }
                    catch (Exception)
                    {

                        throw;
                    }

                } while (!isValide);
            }
        }
    }
}