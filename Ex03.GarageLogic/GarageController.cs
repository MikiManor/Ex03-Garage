using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class GarageController
    {
        public enum eVehicleType
        {
            Car = 1,
            MotorCycle,
            Truck
        }

        public enum eEngineType
        {
            Electic = 1,
            Fuel
        }

        Dictionary<string, VehicleData> m_GarageDictionary;
        public GarageController ()
        {
            m_GarageDictionary = new Dictionary<string, VehicleData>();
        }
        
        public void AddNewVehicle(string i_VehicleID,string i_OwnerName,string i_PhoneNumber, eVehicleType i_VehicleType, eEngineType i_EngineType)
        {
            if (i_VehicleType == eVehicleType.Car)
            {
                if (i_EngineType == eEngineType.Electic)
                {
                    ElectricCar newVehicle = new ElectricCar("Fiat", i_VehicleID, Car.eNumOfDoors.four, Car.eColor.blue);
                    VehicleData newVehicleData = new VehicleData(i_OwnerName, i_PhoneNumber, newVehicle);
                    m_GarageDictionary.Add(i_VehicleID, newVehicleData);
                    m_GarageDictionary.ToString();
                }
                else if (i_EngineType == eEngineType.Fuel)
                {

                }
            }
            else if (i_VehicleType == eVehicleType.MotorCycle)
            {
                if (i_EngineType == eEngineType.Electic)
                {

                }
                else if (i_EngineType == eEngineType.Fuel)
                {

                }
            }
            else if (i_VehicleType == eVehicleType.Truck)
            {

            }

        }
    }
}
