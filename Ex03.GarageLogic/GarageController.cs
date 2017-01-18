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
            MotorCycle = 2,
            Truck = 3
        }

        public enum eEngineType
        {
            Electic = 1,
            Fuel = 2
        }

        Dictionary<string, Vehicle> m_GarageDictionary;
        public GarageController ()
        {
            m_GarageDictionary = new Dictionary<string, Vehicle>();
        }
        
        public void AddNewVehicle(string i_VehicleID,string i_OwnerName,string i_PhoneNumber, eVehicleType i_VehicleType, eEngineType i_EngineType)
        {


        }
    }
}
