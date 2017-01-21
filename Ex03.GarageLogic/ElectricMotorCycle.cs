using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class ElectricMotorCycle : MotorCycle
    {
        //private static int k_NumOfWheels = 4;
        private readonly float k_MaxBatteryTime = 2.5f;
        private const eNumOfWheels k_NumOfWheels = eNumOfWheels.two;
        private const int k_MaxWheelsAirPreasure = 31;
        public ElectricMotorCycle(string i_LicenseNumber)
            : base(i_LicenseNumber, k_NumOfWheels, k_MaxWheelsAirPreasure)
        {
            Engine = new ElectricEngine(k_MaxBatteryTime);
            Console.WriteLine("In EMotorCycle");
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("Vehicle : Electric MotorCycle ");

            return stringBuilder + base.ToString();
        }

    }
}
