using System;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class FuelMotorCycle : MotorCycle
    {
        private const int k_NumOfWheels = 2;
        private const int k_MaxWheelsAirPreasure = 31;
        private readonly eFuelType r_FuelType = eFuelType.Octan98;
        private readonly float r_MaxAmountOfFule = 6.2f;
        
        public FuelMotorCycle(string i_LicenseNumber)
            : base(i_LicenseNumber, k_NumOfWheels, k_MaxWheelsAirPreasure)
        {
            Engine = new FuelEngine(r_MaxAmountOfFule, (int)r_FuelType);
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendFormat("{1}Vehicle = Fual MotorCycle{0}{2}{0}", Environment.NewLine, "\t", Engine.ToString());
            return stringBuilder + base.ToString();
        }
    }
}
