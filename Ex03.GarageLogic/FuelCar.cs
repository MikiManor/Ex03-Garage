using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Ex03.GarageLogic
{
    public class FuelCar : Car
    {
        private readonly eFuelType k_FuelType = eFuelType.Octan95;
        private readonly float k_MaxAmountOfFule = 46;
        private const eNumOfWheels k_NumOfWheels = eNumOfWheels.four;
        private const int k_MaxWheelsAirPreasure = 32;
        public FuelCar(string i_Model, string i_LicenseNumber, eNumOfDoors i_NumOfDoors, eColor i_CarColor,
            float i_AmountOfFuelLeft)
            :base(i_Model, i_LicenseNumber, i_NumOfDoors, i_CarColor, k_NumOfWheels, k_MaxWheelsAirPreasure)
        {
            FuelEngine carEngine = new FuelEngine(i_AmountOfFuelLeft, k_MaxAmountOfFule, k_FuelType);
            Console.WriteLine("In Fuel Car");
        }
    }
}
