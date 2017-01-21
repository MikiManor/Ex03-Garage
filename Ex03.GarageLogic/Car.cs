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
           two = 1,
           three,
           four,
           five
        }

        public enum eCarInfo
        {
            CarFirma = 1,
            CarColor,
            NumberOfDoors
        }

        private static eNumOfDoors m_NumOfDoors;
        private static eColor m_CarColor;

        internal Car(string i_LicenseNumber, eNumOfWheels i_NumOfWheels, int i_MaxWheelsAirPreasure)
            :base(i_LicenseNumber, i_NumOfWheels, i_MaxWheelsAirPreasure)
        {
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

        public override void setVehicleProperty(int i_Property, string i_InputFromUserStr)
        {
            eCarInfo property = (eCarInfo)i_Property;
            int ParssedInputFromUser;

            switch (property)
            {
                case eCarInfo.CarFirma:
                    {
                        Firma = i_InputFromUserStr;
                        break;
                    }

                case eCarInfo.CarColor:
                    {
                        if (int.TryParse(i_InputFromUserStr, out ParssedInputFromUser))
                        {
                            CarColor = (eColor)ParssedInputFromUser; //If color doesn't exist, exception should returned
                        }
                        else
                        {
                            throw new FormatException("Got bad input!");
                        }

                        break;
                    }

                case eCarInfo.NumberOfDoors:
                    {
                        if (int.TryParse(i_InputFromUserStr, out ParssedInputFromUser))
                        {
                            NumOfDoors = (eNumOfDoors)ParssedInputFromUser;
                        }
                        else
                        {
                            throw new FormatException("Got bad input!");
                        }

                        break;
                    }
            }
        }

        public override string ToString()
        {
            return "koko";
        }
    }

}
