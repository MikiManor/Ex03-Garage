using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Car : Vehicle
    {
        private static eNumOfDoors m_NumOfDoors;
        private static eColor m_CarColor;

        internal Car(string i_LicenseNumber, int i_NumOfWheels, int i_MaxWheelsAirPreasure)
            : base(i_LicenseNumber, i_NumOfWheels, i_MaxWheelsAirPreasure)
        {
        }

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
                if (Enum.IsDefined(typeof(eColor), value))
                {
                    m_CarColor = value;
                }
                else
                {
                    throw new InvalidEnumArgumentException("Color is unknown!", (int)value, typeof(eColor));
                }
            }
        }

        public override Dictionary<int, string> GetVheicleProperties() 
        {
            Dictionary<int, string> carProperties = new Dictionary<int, string>();

            foreach (eCarInfo property in Enum.GetValues(typeof(eCarInfo)))
            {
                if (property == eCarInfo.CarColor)
                {
                    carProperties.Add((int)property, genericEnumUserMsg<eColor>("car color > "));
                }
                else if (property == eCarInfo.NumberOfDoors)
                {
                    carProperties.Add((int)property, genericEnumUserMsg<eNumOfDoors>("number of doors > "));
                }
                else
                {
                    carProperties.Add((int)property, property.ToString());
                }
            }

            return carProperties;
        }

        public override void SetVehicleProperty(int i_Property, string i_InputFromUserStr)
        {
            eCarInfo property = (eCarInfo)i_Property;
            int parssedInputFromUser;

            switch (property)
            {
                case eCarInfo.CarFirma:
                    {
                        base.Firma = i_InputFromUserStr;
                        break;
                    }

                case eCarInfo.CarColor:
                    {
                        if (int.TryParse(i_InputFromUserStr, out parssedInputFromUser))
                        {
                            CarColor = (eColor)parssedInputFromUser; ////If color doesn't exist, exception should returned
                        }
                        else
                        {
                            throw new FormatException("Got bad input!");
                        }

                        break;
                    }

                case eCarInfo.NumberOfDoors:
                    {
                        if (int.TryParse(i_InputFromUserStr, out parssedInputFromUser))
                        {
                            NumOfDoors = (eNumOfDoors)parssedInputFromUser;
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
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendFormat("{1}Car Color = {2}{0}{1}Number Of Doors = {3}{0}", Environment.NewLine, "\t", m_CarColor.ToString(), m_NumOfDoors.ToString());
            return stringBuilder + base.ToString();
        }
    }
}
