using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class GarageController
    {
        public enum eVehicleType
        {
            FuelMotorCycle = 1,
            ElectricMotorCycle = 2,
            FuelCar = 3,
            ElectricCar = 4,
            Truck = 5,
        }

        public Dictionary<string, VehicleData> m_GarageDictionary;
        public VehicleData m_CurrentVehicleData; // Data member which will assigned to every new vehicle.

        public GarageController()
        {
            m_GarageDictionary = new Dictionary<string, VehicleData>();
        }

        public void AddCarToGarage(string i_OwnerName, string i_PhoneNumber, string i_VehicleID,eVehicleType i_TypeOfVehicleFromUser)
        {
            //VehicleData newVehicle = null;
            Vehicle newVehicle;
            //if in garage
            //else
            newVehicle = AddNewVehicle(i_VehicleID, i_TypeOfVehicleFromUser);
            m_CurrentVehicleData = new VehicleData(i_OwnerName, i_PhoneNumber, newVehicle);
             //= AddNewVehicle(i_VehicleID, i_TypeOfVehicleFromUser);
            //newVehicle.NewVehicle
            m_GarageDictionary.Add(i_VehicleID, m_CurrentVehicleData);
        }

        private Vehicle AddNewVehicle(string i_vehicleID, eVehicleType i_typeOfVehicleFromUser)
        {
            Vehicle newVehicle = null;

            switch (i_typeOfVehicleFromUser)
            {
                case eVehicleType.FuelMotorCycle:
                    {
                        newVehicle = new FuelMotorCycle(i_vehicleID);
                        break;
                    }
                case eVehicleType.ElectricMotorCycle:
                    {
                        newVehicle = new ElectricMotorCycle(i_vehicleID);
                        break;
                    }
                    
                case eVehicleType.FuelCar:
                    {
                        newVehicle = new FuelCar(i_vehicleID);
                        break;
                    }
                case eVehicleType.ElectricCar:
                    {
                        newVehicle = new ElectricCar(i_vehicleID);
                        break;
                    }
                case eVehicleType.Truck:
                    {
                        newVehicle = new Truck(i_vehicleID);
                        break;
                    }
            }
            return newVehicle;
        }

        public Dictionary<int, string> GetProperties()
        {
            Dictionary<int, string> vehicleProperties = null;
            //somthing ck if null
            vehicleProperties = m_CurrentVehicleData.NewVehicle.GetVheicleProperties(); //build virtual and overide in classes
            return vehicleProperties;
        }

        public void SetProperties(int i_Properties, string i_value) //here??
        {
            

        }
    }
}
