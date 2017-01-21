using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Ex03.GarageLogic
{
    internal class FuelCar : Car
    {
        private readonly eFuelType k_FuelType = eFuelType.Octan95;
        private readonly float k_MaxAmountOfFule = 46;
        private const eNumOfWheels k_NumOfWheels = eNumOfWheels.four;
        private const int k_MaxWheelsAirPreasure = 32;
        public FuelCar(string i_LicenseNumber)
            :base(i_LicenseNumber, k_NumOfWheels, k_MaxWheelsAirPreasure)
        {
            Engine = new FuelEngine(k_MaxAmountOfFule, (int)k_FuelType);
            Console.WriteLine("In Fuel Car");
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("Vehicle : Fuel Car ");
            stringBuilder.AppendFormat("Fuel type : {0}", k_FuelType);

            return stringBuilder + base.ToString();
        }
    }
}
