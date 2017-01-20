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

        public void AddCarToGarage(string i_OwnerName, string i_PhoneNumber, string i_VehicleID,eVehicleType i_TypeOfVehicleFromUser)
        {
            VehicleData newVehicle;
            //if in garage
            //else
            newVehicle = AddNewVehicle(i_VehicleID, i_TypeOfVehicleFromUser);

            m_GarageDictionary.Add(i_VehicleID, newVehicle);
        }

        private VehicleData AddNewVehicle(string i_vehicleID, eVehicleType i_typeOfVehicleFromUser)
        {
            VehicleData newVehicle = null;

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
                case eVehicleType.FuelTruck:
                    {
                        newVehicle = new FuelTruck(i_vehicleID);
                        break;
                    }
            }
            return newVehicle;
        }
    }
}
