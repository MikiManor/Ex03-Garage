using System;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class ElectricCar : Car
    {
        private const int k_NumOfWheels = 4;
        private const int k_MaxWheelsAirPreasure = 32;
        private readonly float r_MaxBatteryTime = 2.7f;

        public ElectricCar(string i_LicenseNumber)
            : base(i_LicenseNumber, k_NumOfWheels, k_MaxWheelsAirPreasure)
        {
            Engine = new ElectricEngine(r_MaxBatteryTime);
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendFormat("{1}Vehicle = Electric Car{0}{2}{0}", Environment.NewLine, "\t", Engine.ToString());
            return stringBuilder + base.ToString();
        }
    }
}
