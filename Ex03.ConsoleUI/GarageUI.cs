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
                        Console.WriteLine("No datta"); //need this?
                        break;
                    }
                    else
                    {
                        Console.WriteLine("License plate = {0}, Status = {3}, Owner name = {1}, Phone number = {2}", dataMember.Key, dataMember.Value.OwnerName, dataMember.Value.PhoneNumber, dataMember.Value.VehicleStatus);
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
                Console.WriteLine(m_MyGarage.m_CurrentVehicleData.NewVehicle.ToString());
            }

            else
            {
                Console.WriteLine("\tVehicle license plate not found...");
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
            string vehicleID = GetvehicleID();
            if (m_MyGarage.m_GarageDictionary.ContainsKey(vehicleID))
            {
                Console.WriteLine("\tLicense plate allready in! vehicle status will change to \"In Repair\"");
                m_MyGarage.ChangeVehicleStatus(vehicleID, GarageController.eVehicleStatus.InRepair);
            }
            else
            {
                string ownerName = GetInputFromUser<string>("\tPlease enter owner name > ");
                string phoneNumber = GetInputFromUser<string>("\tPlease enter phone number > ");
                GarageController.eVehicleType typeOfVehicleFromUser = getVehicleTypeFromUser();

                try
                {
                    m_MyGarage.AddCarToGarage(ownerName, phoneNumber, vehicleID, typeOfVehicleFromUser);
                    AddVehicleProperties();
                    AddEngineProperties();
                    AddWheels();
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void ShowListOfVehicle()
        {
            PrintFrame("Show list of vehicle");
            try
            {
                PrintVehicleDataDictionary(m_MyGarage.m_GarageDictionary);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            // 2. show vehicle lists(iD), can filter by status
        }

        private void ChangeVehicleStatus()
        {
            PrintFrame("Change vehicle status");
            string vehicleID = GetvehicleID();
            Console.WriteLine("\tChoose vehicle status");
            GarageController.eVehicleStatus newStatus = GetEnumFromUser<GarageController.eVehicleStatus>(GetListOfStatuses());
            m_MyGarage.ChangeVehicleStatus(vehicleID, newStatus);  
            // 3. change status (id) -> new status
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
            catch
            {
                Console.WriteLine("\tSonething went wrong");
            }

        }

        private void FuelUpAVehicle()
        {
            PrintFrame("Fuel up a vehicle");
            string vehicleID = GetvehicleID();
            int fuelTypeSelection = GetInputFromUser<int>(GetEngineFuelType() + "\t>");
            float fuelToAdd = GetInputFromUser<float>("\tEnter amount of fuel to add : >");

            try
            {
                m_MyGarage.FuelUpAVehicle(vehicleID, (eFuelType)fuelTypeSelection, fuelToAdd);
                Console.WriteLine("\tCar Is Fulled up");
            }
            catch (Exception ex)
            {
                Console.WriteLine("\t" + ex.Message);
            }
        }

        private void ChargeUpAnElectricVehicle()
        {
            PrintFrame("Charge up an electric vehicle");
            string vehicleID = GetvehicleID();
            try
            {
                m_MyGarage.chargeAVehicleToMax(vehicleID);
                Console.WriteLine("Vehicle is fully Charged ");
            }
            catch (Exception ex)
            {
                Console.WriteLine("\t" + ex.Message);
            }
            // 6. charge (non fual) (id, min to charge)
        }

        private void ShowVehicleFullDetails()
        {
            PrintFrame("Show vehicle full details");
            string vehicleID = GetvehicleID();
            PrintFullVehiclel(vehicleID);
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
                Console.WriteLine("\tWheel nummber {0}: ", i + 1);
                string tireFirma = GetInputFromUser<string>("\tPlease enter wheel firma > ");
                float currentAirPreasure = GetInputFromUser<float>("\tPlease enter wheel current air preasure  > ");
                vehicleWheel.CurrentAirPreasure = currentAirPreasure;
                vehicleWheel.WheelFirma = tireFirma;
                wheelsList.Add(vehicleWheel);
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
                            string input = GetInputFromUser<string>("\t" + item.Key + " - " + item.Value + "\t> ");//??
                            m_MyGarage.m_CurrentVehicleData.NewVehicle.setVehicleProperty(index, input); //bulid it in Vehicle
                            isValide = true;
                            index++;
                        
                    }
                    catch (Exception)
                    {

                        throw;
                    }

                } while (!isValide);
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
                    catch (Exception)
                    {

                        throw;
                    }

                } while (!isValide);
            }
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

            return stringBuilder.ToString();
        }
    }
}