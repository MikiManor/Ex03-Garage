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
            FuelTruck = 5,
        }

        public Dictionary<string, VehicleData> m_GarageDictionary;

        public GarageController()
        {
            m_GarageDictionary = new Dictionary<string, VehicleData>();
        }

        public void AddCarToGarage(string ownerName, string phoneNumber, string vehicleID,eVehicleType typeOfVehicleFromUser)
        {
        } 
    }
}
