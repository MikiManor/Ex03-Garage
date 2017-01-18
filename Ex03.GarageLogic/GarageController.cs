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

        Dictionary <string, VehicleData> m_GarageDictionary;
        public GarageController ()
        {
            m_GarageDictionary = new Dictionary <string, VehicleData>();
        }
        
        public void AddNewVehicle(string i_model, string i_VehicleID,string i_OwnerName,string i_PhoneNumber, eVehicleType i_VehicleType, eEngineType i_EngineType, Car.eNumOfDoors i_NumOfDoors, Car.eColor i_CarColor)
        {
            if (i_VehicleType == eVehicleType.Car)
            {
                if (i_EngineType == eEngineType.Electic)
                {
                    ElectricCar newVehicle = new ElectricCar(i_model, i_VehicleID, i_NumOfDoors, i_CarColor);
                    VehicleData newVehicleData = new VehicleData(i_OwnerName, i_PhoneNumber, newVehicle);
                    m_GarageDictionary.Add(i_VehicleID, newVehicleData);
                    m_GarageDictionary.ToString();
                }
                else if (i_EngineType == eEngineType.Fuel)
                {
                    //fillup
                }
            }
            else if (i_VehicleType == eVehicleType.MotorCycle)
            {
                if (i_EngineType == eEngineType.Electic)
                {
                    ElectricMotorCycle newVehicle = new ElectricMotorCycle();//fillup
                }
                else if (i_EngineType == eEngineType.Fuel)
                {
                    //fillup
                }
            }
            else if (i_VehicleType == eVehicleType.Truck)
            {
                Truck newVehicle = new Truck(i_model, i_VehicleID, i_NumOfWheels, i_IsCarryingDangerousGoods, i_MaxCarryingWeight);
            }

        }
        public void ShowListOfVehicle()
        {
            
            PrintDictionary(m_GarageDictionary);
        }
    }
}
