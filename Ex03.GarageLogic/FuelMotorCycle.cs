using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class FuelMotorCycle : MotorCycle
    {
        private readonly eFuelType k_FuelType = eFuelType.Octan98;
        private readonly float k_MaxAmountOfFule = 6.2f;
        private const eNumOfWheels k_NumOfWheels = eNumOfWheels.two;
        private const int k_MaxWheelsAirPreasure = 31;
        public FuelMotorCycle(string i_LicenseNumber)
            : base(i_LicenseNumber, k_NumOfWheels, k_MaxWheelsAirPreasure)
        {
            Engine = new FuelEngine(k_MaxAmountOfFule, (int)k_FuelType);
           // Console.WriteLine("In Fuel MotorCycle");
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("Vehicle : Fuel MotorCycle ");
            stringBuilder.AppendFormat("Fuel type : {0}", k_FuelType);

            return stringBuilder + base.ToString();
        }
    }
}
