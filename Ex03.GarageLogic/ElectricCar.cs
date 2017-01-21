using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class ElectricCar : Car
    {
        //private static int k_NumOfWheels = 4;
        private readonly float k_MaxBatteryTime = 2.7f;
        private const int k_NumOfWheels = 4;
        private const int k_MaxWheelsAirPreasure = 32;
        public ElectricCar(string i_LicenseNumber)
            :base(i_LicenseNumber, k_NumOfWheels, k_MaxWheelsAirPreasure)
        {
            Engine = new ElectricEngine(k_MaxBatteryTime);
            Console.WriteLine("In ECar");
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("Vehicle : Electric Car ");

            return stringBuilder + base.ToString();
        }

    }
}
