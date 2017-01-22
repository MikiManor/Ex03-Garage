using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Ex03.GarageLogic
{
    public enum eFuelType
    {
        Octan98 = 1,
        Octan96,
        Octan95,
        Soler
    }

    public enum eFuelEngineProperties
    {
        CurrentFuelLeft = 1
    }

    internal class FuelEngine : Engine
    {
        private eFuelType m_FuelType;

        public FuelEngine(float i_MaxAmountOfFuel, int i_FuelType)
            : base(i_MaxAmountOfFuel)
        {
            k_MaxAmountOfFuel = i_MaxAmountOfFuel;
            FuleType = i_FuelType;
        }
        

        public override Dictionary<int, string> GetEngineProperties()
        {
            Dictionary<int, string> FuelEngineProperties = new Dictionary<int, string>();

            foreach (eFuelEngineProperties property in Enum.GetValues(typeof(eFuelEngineProperties)))
            {
                FuelEngineProperties.Add((int)property, property.ToString());
            }

            return FuelEngineProperties;
        }

        public int FuleType
        {
            get { return (int)m_FuelType; }
            set
            {
                if (Enum.IsDefined(typeof(eFuelType), value))
                {
                    m_FuelType = (eFuelType)value;
                }
                else
                {
                    throw new InvalidEnumArgumentException("Wrong type of Fuel type selected!", (int)value, typeof(eFuelType));
                }
            }
        }

        public override void SetEngineProperty(int i_Property, string i_InputFromUserStr)
        {
            eFuelEngineProperties property = (eFuelEngineProperties)i_Property;
            float inputFromUserFloat;
            switch (property)
            {
                case eFuelEngineProperties.CurrentFuelLeft:
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

        public override void FillOutEngine(eFuelType i_FeulType, float i_EnergyToAdd)
        {
            if (i_FeulType == m_FuelType)
            {
                if (( m_LeftEnergy + i_EnergyToAdd) >= k_MaxAmountOfFuel)
                {
                    throw new ValueOutOfRangeException("Cannot fill out above maximum!", k_MaxAmountOfFuel - m_LeftEnergy, 0);
                }
                else
                {
                    m_LeftEnergy += i_EnergyToAdd;
                }
            }
            else
            {
                throw new ArgumentException(string.Format("\tFuel type isn't correct, this vehicle uses : {0}", m_FuelType.ToString()));
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendFormat("\tFuel Type is = {0}{1}", m_FuelType.ToString(), Environment.NewLine);
            return stringBuilder.ToString() + base.ToString();
        }
    }
}
