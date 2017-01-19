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
        
        public void AddNewVehicleElectricCar(string i_modelName, string i_VehicleID,string i_OwnerName,string i_PhoneNumber)
        {

            if (i_VehicleType == eVehicleType.Car)
            {
                
                if (i_EngineType == eEngineType.Electic)
                {
                    AddNewElectricCar();
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

        public void AddNewVehicleMotorCycle(string i_VehicleID, string i_OwnerName, string i_PhoneNumber)
        {

        }

        public void AddNewVehicleTruck()
        {
            
            //PrintDictionary(m_GarageDictionary);
        }
    }
}
