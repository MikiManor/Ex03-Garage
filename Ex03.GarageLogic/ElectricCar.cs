using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ElectricCar : Car
    {
        //private static int k_NumOfWheels = 4;
        private readonly float k_MaxBatteryTime = 2.7f;
        private const eNumOfWheels k_NumOfWheels = eNumOfWheels.four;
        private const int k_MaxWheelsAirPreasure = 32;
        public ElectricCar(string i_Model, string i_LicenseNumber, eNumOfDoors i_NumOfDoors, eColor i_CarColor, 
            float i_RemainingBatteryTime)
            :base(i_Model, i_LicenseNumber, i_NumOfDoors, i_CarColor, k_NumOfWheels, k_MaxWheelsAirPreasure)
        {
            ElectricEngine carEngine = new ElectricEngine(i_RemainingBatteryTime, k_MaxBatteryTime);
            Console.WriteLine("In ECar");
        }
    }
}
