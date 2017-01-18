using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private static bool m_IsCarryingDangerousGoods;
        private static float m_MaxCarryingWeight;
        public Truck(string i_Model, string i_LicenseNumber, int i_NumOfWheels, bool i_IsCarryingDangerousGoods, float i_MaxCarryingWeight)
            : base(i_Model, i_LicenseNumber, i_NumOfWheels)
        {

        }

    }
}
