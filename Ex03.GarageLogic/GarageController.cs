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

        public Dictionary<string, VehicleData> m_GarageDictionary;
        public GarageController()
        {
            m_GarageDictionary = new Dictionary<string, VehicleData>();
        }

        public void AddNewVehicleElectricCar(string i_vehicleID, string i_manufacturer, string i_ownerName, string i_phoneNumber, Car.eNumOfDoors i_numOfDoors, Car.eColor i_carColor, float i_batteryLeft)
        {
            ElectricCar newVehicle = new ElectricCar(i_manufacturer, i_vehicleID, i_numOfDoors, i_carColor);
            VehicleData newVehicleData = new VehicleData(i_ownerName, i_phoneNumber, newVehicle);
            m_GarageDictionary.Add(i_vehicleID, newVehicleData);
        }

        public void AddNewVehicleMotorCycle(string i_VehicleID, string i_OwnerName, string i_PhoneNumber)
        {

        }

        public void AddNewVehicleTruck()
        {


        }
    }
}
