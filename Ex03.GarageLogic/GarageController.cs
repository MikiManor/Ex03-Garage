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

        public void AddNewVehicleElectricCar(string i_vehicleID, string i_manufacturer, string i_ownerName, string i_phoneNumber, Car.eNumOfDoors i_numOfDoors, Car.eColor i_carColor, float i_batteryLeft, Vehicle.structWheels i_wheels)
        {
            Vehicle.eStatus status = Vehicle.eStatus.InRepair;
            ElectricCar newVehicle = new ElectricCar(i_manufacturer, i_vehicleID, i_numOfDoors, i_carColor, i_batteryLeft, i_wheels);
            VehicleData newVehicleData = new VehicleData(i_ownerName, i_phoneNumber, newVehicle, status);
            m_GarageDictionary.Add(i_vehicleID, newVehicleData);
        }

        public void AddNewVehicleFuelCar(string i_vehicleID, string i_manufacturer, string i_ownerName, string i_phoneNumber, Car.eNumOfDoors i_numOfDoors, Car.eColor i_carColor, float i_fuelLeft, FuelEngine.eFuelType i_fuelType, Vehicle.structWheels i_wheels)
        {
            Vehicle.eStatus status = Vehicle.eStatus.InRepair;
            FuelCar newVehicle = new FuelCar();
            VehicleData newVehicleData = new VehicleData(i_ownerName, i_phoneNumber, newVehicle, status);
            m_GarageDictionary.Add(i_vehicleID, newVehicleData);
        }

        public void AddNewVehicleElectricMotorCycle(string i_vehicleID, string i_manufacturer, string i_ownerName, string i_phoneNumber, MotorCycle.eLicenseType i_licenseType, float i_batteryLeft, Vehicle.structWheels i_wheels)
        {
            Vehicle.eStatus status = Vehicle.eStatus.InRepair;
            ElectricMotorCycle newVehicle = new ElectricMotorCycle();
            VehicleData newVehicleData = new VehicleData(i_ownerName, i_phoneNumber, newVehicle, status);
            m_GarageDictionary.Add(i_vehicleID, newVehicleData);
        }

        public void AddNewVehicleFuelMotorCycle(string i_vehicleID, string i_manufacturer, string i_ownerName, string i_phoneNumber, MotorCycle.eLicenseType i_licenseType, float i_fuelLeft, FuelEngine.eFuelType i_fuelType, Vehicle.structWheels i_wheels)
        {
            Vehicle.eStatus status = Vehicle.eStatus.InRepair;
            FuelMotorCycle newVehicle = new FuelMotorCycle();
            VehicleData newVehicleData = new VehicleData(i_ownerName, i_phoneNumber, newVehicle, status);
            m_GarageDictionary.Add(i_vehicleID, newVehicleData);
        }

        public void AddNewVehicleTruck(string i_vehicleID, string i_manufacturer, string i_ownerName, string i_phoneNumber, Car.eNumOfDoors i_numOfDoors, Car.eColor i_carColor, float i_batteryLeft, Vehicle.structWheels i_wheels)
        {
            Vehicle.eStatus status = Vehicle.eStatus.InRepair;
            Truck newVehicle = new Truck();
            VehicleData newVehicleData = new VehicleData(i_ownerName, i_phoneNumber, newVehicle, status);
            m_GarageDictionary.Add(i_vehicleID, newVehicleData);
        }
    }
}
