﻿using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class GarageController
    {
        public Dictionary<string, VehicleData> m_GarageDictionary;
        public VehicleData m_CurrentVehicleData;

        public Dictionary<string, VehicleData> GarageDictionary
        {
            get { return m_GarageDictionary; }
        }

        public GarageController()
        {
            m_GarageDictionary = new Dictionary<string, VehicleData>();
        }

        public enum eVehicleStatus
        {
            InRepair = 1,
            DoneRepair = 2,
            Paid = 3
        }

        public enum eVehicleType
        {
            FuelMotorCycle = 1,
            ElectricMotorCycle = 2,
            FuelCar = 3,
            ElectricCar = 4,
            Truck = 5,
        }

        public bool IsLicenseInGarage(string i_LicenseNumber)
        {
            return m_GarageDictionary.ContainsKey(i_LicenseNumber);
        }

        public void AddCarToGarage(string i_OwnerName, string i_PhoneNumber, string i_VehicleID, eVehicleType i_TypeOfVehicleFromUser)
        {
            Vehicle newVehicle = AddNewVehicle(i_VehicleID, i_TypeOfVehicleFromUser);
            m_CurrentVehicleData = new VehicleData(i_OwnerName, i_PhoneNumber, newVehicle);
            m_GarageDictionary.Add(i_VehicleID, m_CurrentVehicleData);
        }

        public Dictionary<int, string> GetVehicleProperties()
        {
            Dictionary<int, string> vehicleProperties = null;
            vehicleProperties = m_CurrentVehicleData.NewVehicle.GetVheicleProperties();
            return vehicleProperties;
        }

        public Dictionary<int, string> GetEngineProperties()
        {
            Dictionary<int, string> engineProperties = null;
            engineProperties = m_CurrentVehicleData.NewVehicle.Engine.GetEngineProperties();
            return engineProperties;
        }

        public void MakeWheels(List<WheelCollection> wheelList)
        {
            m_CurrentVehicleData.NewVehicle.SetAllWheels(wheelList);
        }

        public void FillUpWheelsToTheMaximun(string i_LicenseNumber)
        {
            VehicleData currentVehiclel;
            if (m_GarageDictionary.TryGetValue(i_LicenseNumber, out currentVehiclel))
            {
                currentVehiclel.NewVehicle.InfalingAllWheelsToMaxPreasure();
            }
            else
            {
                throw new Exception("\tVehicle license plate not found...");
            }
        }

        public void FuelUpAVehicle(string i_LicenseNumber, eFuelType i_FuleType, float i_FuleToAdd)
        {
            VehicleData currentVehiclel;

            if (m_GarageDictionary.TryGetValue(i_LicenseNumber, out currentVehiclel))
            {
                if (currentVehiclel.NewVehicle.Engine.GetType() == typeof(Ex03.GarageLogic.FuelEngine))
                {
                    currentVehiclel.NewVehicle.Engine.FillOutEngine(i_FuleType, i_FuleToAdd);
                }
                else
                {
                    throw new ArgumentException("This vehicle is not using fuel!");
                }
            }
            else
            {
                throw new ArgumentException("\tVehicle not found in garage!");
            }
        }

        public void ChargeAVehicle(string i_LicenseNumber, float i_HoursToAdd)
        {
            VehicleData currentVehiclel;
            if (m_GarageDictionary.TryGetValue(i_LicenseNumber, out currentVehiclel))
            {
                if (currentVehiclel.NewVehicle.Engine.GetType() == typeof(Ex03.GarageLogic.ElectricEngine))
                {
                    currentVehiclel.NewVehicle.Engine.ChargeBattery(i_HoursToAdd);
                }
                else
                {
                    throw new ArgumentException("This vehicle is not Electric!");
                }
            }
        }

        public void ChangeVehicleStatus(string i_LicenseNumber, eVehicleStatus i_status)
        {
            VehicleData currentVehiclel;
            if (m_GarageDictionary.TryGetValue(i_LicenseNumber, out currentVehiclel))
            {
                try
                {
                    currentVehiclel.VehicleStatus = i_status;
                }
                catch (Exception)
                {
                    throw new Exception("Error, Can't set new status!");
                }  
            }
            else
            {
                throw new ArgumentException("Vehicle not found!");
            }
        }

        public string GetEngineFuelType()
        {
            string fuleTypes = Vehicle.genericEnumUserMsg<eFuelType>("Fuel type");
            return fuleTypes;
        }

        public bool IsFuelEngine(string i_LicenseNumber)
        {
            VehicleData currentVehiclel;
            bool IsFuelEngine = true;
            m_GarageDictionary.TryGetValue(i_LicenseNumber, out currentVehiclel);
            if (currentVehiclel.NewVehicle.Engine.GetType() == typeof(Ex03.GarageLogic.ElectricEngine))
            {
                IsFuelEngine = false;
            }
            else if (currentVehiclel.NewVehicle.Engine.GetType() == typeof(Ex03.GarageLogic.FuelEngine))
            {
                IsFuelEngine = true;
            }
            else
            {
                throw new ArgumentException("\tEngine doesn't exist!");
            }

            return IsFuelEngine;
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
    }
}
