using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class ElectricCar : Car
    {
        private static int k_NumOfWheels = 4;
        private readonly double k_MaxBatteryTime = 2.7;
        private readonly int k_MaxWheelsAirPreasure = 32;
        public ElectricCar(string i_Model, string i_LicenseNumber, eNumOfDoors i_NumOfDoors, eColor i_CarColor )
            :base(i_Model, i_LicenseNumber, k_NumOfWheels, i_NumOfDoors, i_CarColor)
        {
            ElectricEngine carEngine = new ElectricEngine(k_MaxBatteryTime,) 
            Console.WriteLine("In ECar");
        }
    }
}
