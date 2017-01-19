using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class ElectricEngine
    {
        private float m_BatteryRemainingTime;
        private static float m_BatteryMaxTime;
         

        public ElectricEngine(float i_RemainingBatteryTime, float i_MaxBatteryTime)
        {
            MaxBatteryTime = i_MaxBatteryTime;
            RemainingTime = i_RemainingBatteryTime;
        }
        public void ChargeBattery(float i_HoursToAdd)
        {
            if ((m_BatteryRemainingTime + i_HoursToAdd) >= m_BatteryMaxTime)
            {
                throw new ValueOutOfRangeException("Cannot add charge battery above maximum!", m_BatteryMaxTime - m_BatteryRemainingTime, 0);
            }
            else
            {
                m_BatteryRemainingTime += i_HoursToAdd;
            }
        }
        public float RemainingTime
        {
            get { return m_BatteryRemainingTime; }
            set
            {
                if(value > m_BatteryMaxTime)
                {
                    throw new ValueOutOfRangeException("Battery cannot contain higher energy then maximum", m_BatteryMaxTime, 0);
                }
                else
                {
                    m_BatteryRemainingTime = value;
                }
            }
        }
        public float MaxBatteryTime
        {
            get { return m_BatteryMaxTime; }
            set
            {
                if(value <= 0)
                {
                    throw new ArgumentException("Battery should can has energy for at least 1 minute!");
                }
                else
                {
                    m_BatteryMaxTime = value;
                }
            }
        }
    }
}
