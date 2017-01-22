using System;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class FuelCar : Car
    {
        private readonly eFuelType k_FuelType = eFuelType.Octan95;
        private readonly float k_MaxAmountOfFule = 46;
        private const int k_NumOfWheels = 4;
        private const int k_MaxWheelsAirPreasure = 32;
        public FuelCar(string i_LicenseNumber)
            : base(i_LicenseNumber, k_NumOfWheels, k_MaxWheelsAirPreasure)
        {
            Engine = new FuelEngine(k_MaxAmountOfFule, (int)k_FuelType);
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendFormat("{1}Vehicle = Fuel Car{0}{2}{0}", Environment.NewLine, "\t", Engine.ToString());
            return stringBuilder + base.ToString();
        }
    }
}
