using System;
using System.Collections.Generic;
namespace Ex03.GarageLogic
{
    public enum eElectricEngineProperties
    {
        CurrentEnergyLeftInBattery = 1
    }
    internal class ElectricEngine : Engine
    {
        public ElectricEngine(float i_MaxBatteryTime)
            : base(i_MaxBatteryTime)
        {           
        }
        
        public override Dictionary<int, string> GetEngineProperties()
        {
            Dictionary<int, string> ElectricEngineProperties = new Dictionary<int, string>();

            foreach (eElectricEngineProperties property in Enum.GetValues(typeof(eElectricEngineProperties)))
            {
                ElectricEngineProperties.Add((int)property, property.ToString());
            }

            return ElectricEngineProperties;
        }

        public override void SetEngineProperty(int i_Property, string i_InputFromUserStr)
        {
            eElectricEngineProperties property = (eElectricEngineProperties)i_Property;
            float inputFromUserFloat;
            switch (property)
            {
                case eElectricEngineProperties.CurrentEnergyLeftInBattery:
                    {
                        if (float.TryParse(i_InputFromUserStr, out inputFromUserFloat))
                        {
                            EngineCurrentEnergy = inputFromUserFloat;
                        }
                        else
                        {
                            throw new FormatException("You have enterd wrong input!");
                        }

                        break;
                    }
            }
        }

        public override void ChargeBattery(float i_HoursToAdd)
        {
            if ((m_LeftEnergy + i_HoursToAdd) >= r_MaxEngineCapacity)
            {
                throw new ValueOutOfRangeException("Cannot fill out above maximum!", r_MaxEngineCapacity - m_LeftEnergy, 0);
            }
            else
            {
                m_LeftEnergy += i_HoursToAdd;
            }
        }
    }
}
