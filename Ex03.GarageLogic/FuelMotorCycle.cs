using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class FuelMotorCycle : MotorCycle
    {
        private readonly eFuelType k_FuelType = eFuelType.Octan98;
        private readonly float k_MaxAmountOfFule = 6.2f;
        private const int k_NumOfWheels = 2;
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
            stringBuilder.AppendFormat("{1}Vehicle = Fual MotorCycle{0}{2}{0}", Environment.NewLine, "\t", Engine.ToString());
            return stringBuilder + base.ToString();
        }
    }
}
