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

        private readonly float r_MaxEngineCapacity;
        private float m_LeftEnergy;

        public Engine(float i_MaxEngineCapacity)
        {
            r_MaxEngineCapacity = i_MaxEngineCapacity;
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
                    throw new ValueOutOfRangeException("Cannot add more then Maximun,",1, r_MaxEngineCapacity);
                }
            }
        }

        public virtual void FillOutEngine(float i_EnergyToAdd)
        {
            if ((m_LeftEnergy + i_EnergyToAdd) >= r_MaxEngineCapacity)
            {
                throw new ValueOutOfRangeException("Cannot fill out above maximum!", r_MaxEngineCapacity - m_LeftEnergy, 1);
            }
            else
            {
                m_LeftEnergy += i_EnergyToAdd;
            }
        }

        public float MaxEngineEnergy
        {
            get { return r_MaxEngineCapacity; }
        }

        public virtual Dictionary<int, string> GetEngineProperties()
        {
            Dictionary<int, string> EngineProperties = new Dictionary<int, string>();

            EngineProperties.Add(1, "Enter current energy");

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

        public float EnergyPrecentLeft
        {
            get
            {
                return (m_LeftEnergy * 100) / r_MaxEngineCapacity;
            }
        }
    }
}
