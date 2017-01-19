using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Car : Vehicle
    {
        public enum eColor
        {
            blue = 1,
            white,
            black,
            silver
        }

        public enum eNumOfDoors
        {
           two = 2,
           three,
           four,
           five
        }

        private static eNumOfDoors m_NumOfDoors;
        private static eColor m_CarColor;

        public Car(string i_Model, string i_LicenseNumber, int i_NumOfWheels, eNumOfDoors i_NumOfDoors, eColor i_CarColor)
            :base(i_Model, i_LicenseNumber, i_NumOfWheels)
        {
            NumOfDoors = i_NumOfDoors;
            CarColor = i_CarColor;
        }

        public eNumOfDoors NumOfDoors
        {
            get { return m_NumOfDoors; }
            set
            {
                if (Enum.IsDefined(typeof(eNumOfDoors), value))
                {
                    m_NumOfDoors = value;
                }
                else
                {
                    throw new InvalidEnumArgumentException("Wrong number of doors selected!", (int)value, typeof(eNumOfDoors));
                }
            }

        }

        public eColor CarColor
        {
            get { return m_CarColor; }
            set
            {
                if(Enum.IsDefined(typeof(eColor), value))
                {
                    m_CarColor = value;
                }
                else
                {

                    throw new InvalidEnumArgumentException("Color is unknown!", (int)value, typeof(eColor));
                }
            }

        }
    }
}