using System;
using System.Collections.Generic;
using System.Text;
namespace Ex03.GarageLogic
{
    public abstract class Engine
    {
        public enum eEngineProperties
        {
            LeftEnergy = 1
        }

        protected readonly float r_MaxEngineCapacity;
        protected float m_LeftEnergy;

        public Engine(float i_MaxEngineCapacity)
        {
            r_MaxEngineCapacity = i_MaxEngineCapacity;
        }

        public float MaxEngineEnergy
        {
            get { return r_MaxEngineCapacity; }
        }

        public float EnergyPrecentLeft
        {
            get
            {
                return (m_LeftEnergy * 100) / r_MaxEngineCapacity;
            }
        }

        protected float EngineCurrentEnergy
        {
            get { return m_LeftEnergy; }
            set
            {
                if (value <= r_MaxEngineCapacity)
                {
                    m_LeftEnergy = value;
                }
                else
                {
                    throw new ValueOutOfRangeException("Cannot add more then Maximun,", r_MaxEngineCapacity, 0);
                }
            }
        }

        public virtual void FillOutEngineToMaximum()
        {
            m_LeftEnergy = r_MaxEngineCapacity;
        }

        public virtual void FillOutEngine(eFuelType i_FuelType, float i_EnergyToAdd)
        { }

        public virtual Dictionary<int, string> GetEngineProperties()
        {
            Dictionary<int, string> EngineProperties = new Dictionary<int, string>();

            foreach (eEngineProperties property in Enum.GetValues(typeof(eEngineProperties)))
            {
                EngineProperties.Add((int)property, property.ToString());
            }

            return EngineProperties;
        }

        public virtual void SetEngineProperty(int i_EngineProperty, string i_InputFromUser)
        {
            float inputFromUserFloat;
            eEngineProperties property = (eEngineProperties)i_EngineProperty;

            switch (property)
            {
                case eEngineProperties.LeftEnergy:
                    {
                        if (float.TryParse(i_InputFromUser, out inputFromUserFloat))
                        {
                            EngineCurrentEnergy = inputFromUserFloat;
                        }
                        else
                        {
                            throw new FormatException("This property doesn't exist!");
                        }

                        break;
                    }
            }
        }
               
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendFormat("{1}Energy Left = {2}{0}{1}Maximum Energy Capacity = {3}{0}{1}Percentage Left = {4}", Environment.NewLine, "\t", m_LeftEnergy, r_MaxEngineCapacity, EnergyPrecentLeft);
            return stringBuilder.ToString();
        }

        public virtual void ChargeBattery(float i_HoursToAdd)
        { }
    }
}
