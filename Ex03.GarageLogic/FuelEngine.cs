using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Ex03.GarageLogic
{
    public enum eFuelType
    {
        Octan98 = 98,
        Octan96 = 96,
        Octan95 = 95,
        Soler = 100
    }
    class FuelEngine
    {
        private readonly eFuelType m_FuelType;
        private float m_AmountOfLeftFuel;
        private readonly float k_MaxAmountOfFuel;

        public FuelEngine(float i_AmountOfLeftFuel, float i_MaxAmountOfFuel, eFuelType i_FuelType)
        {
            k_MaxAmountOfFuel = i_MaxAmountOfFuel;
            RemainingFuel = i_AmountOfLeftFuel;
            FuleType = i_FuelType;
        }

        public void AddFuel(float i_AmountToAdd, eFuelType i_FuleType)
        {
            if (Enum.IsDefined(typeof(eFuelType), i_FuleType))
            {
                if ((m_AmountOfLeftFuel + i_AmountToAdd) >= k_MaxAmountOfFuel)
                {
                    throw new ValueOutOfRangeException("Cannot add Fuel above maximum!", k_MaxAmountOfFuel - m_AmountOfLeftFuel, 0);
                }
                else
                {
                    m_AmountOfLeftFuel += i_AmountToAdd;
                }
            }
            else
            {
                throw new ArgumentException("Fuel type entered is unknown!");
            }

        }

        public float RemainingFuel
        {
            get { return m_AmountOfLeftFuel; }
            set
            {
                if (value > k_MaxAmountOfFuel)
                {
                    throw new ValueOutOfRangeException("Battery cannot contain higher energy then maximum", m_BatteryMaxTime, 0);
                }
                else
                {
                    m_AmountOfLeftFuel = value;
                }
            }
        }

        public eFuelType FuleType
        {
            get { return m_FuelType; }
            set
            {
                if (Enum.IsDefined(typeof(eFuelType), value))
                {
                    
                }
                else
                {
                    throw new InvalidEnumArgumentException("Wrong type of Fuel type selected!", (int)value, typeof(eFuelType));
                }
            }
        }
    }
}
