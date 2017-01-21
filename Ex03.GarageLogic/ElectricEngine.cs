using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class ElectricEngine : Engine
    {
        private float m_BatteryRemainingTime;
        private static float m_BatteryMaxTime;
         

        public ElectricEngine(float i_MaxBatteryTime)
            :base(i_MaxBatteryTime)
        {           
        }

        public override Dictionary<int, string> GetEngineProperties()
        {
            Dictionary<int, string> properties = new Dictionary<int, string>();
            properties.Add(1, "Enter battery time Left");
            return properties;
        }
    }
}
