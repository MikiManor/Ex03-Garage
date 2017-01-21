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
        FuelType = 1,
        CurrentFuelLeft
    }

    internal class FuelEngine : Engine
    {
        private eFuelType m_FuelType;
        private float m_AmountOfLeftFuel;
        private readonly float k_MaxAmountOfFuel;

        public FuelEngine(float i_MaxAmountOfFuel, int i_FuelType)
            : base(i_MaxAmountOfFuel)
        {
            k_MaxAmountOfFuel = i_MaxAmountOfFuel;
            FuleType = i_FuelType;
        }

        public override Dictionary<int, string> GetEngineProperties()
        {
            Dictionary<int, string> properties = new Dictionary<int, string>();

            properties.Add(1, Vehicle.genericEnumUserMsg<eFuelType>("fuel type"));
            properties.Add(2, "Please enter fuel amount left in the tank");

            return properties;
        }

        public void FillOutEngine(float i_AmountToAdd, eFuelType i_FuleType)
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
            int inputFromUserInt;

            switch (property)
            {
                case eFuelEngineProperties.FuelType:
                    {
                        if (int.TryParse(i_InputFromUserStr, out inputFromUserInt))
                        {
                            FuleType = inputFromUserInt;
                        }
                        else
                        {
                            throw new FormatException("You have enterd wrong input!");
                        }

                        break;
                    }

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

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("Fuel Type is : " + m_FuelType.ToString());

            return stringBuilder.ToString();
        }

    }
}
