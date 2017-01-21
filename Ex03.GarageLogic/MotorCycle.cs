using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Ex03.GarageLogic
{
    class MotorCycle : Vehicle
    {
        public enum eLicenseType
        {
            A,
            A1,
            A2,
            B
        }

        public enum eMotorCycleInfo
        {
            VehicleFirma = 1,
            LicenseType = 2,
            EngineCapacity = 3
        }

        private static int m_EngineCapacity;
        private eLicenseType m_LicenseType;

        internal MotorCycle(string i_LicenseNumber, int i_NumOfWheels, int i_MaxWheelsAirPreasure)
            :base(i_LicenseNumber, i_NumOfWheels, i_MaxWheelsAirPreasure)
        {
        }

        public eLicenseType LicenseType
        {
            get { return m_LicenseType; }
            set
            {
                if (Enum.IsDefined(typeof(eLicenseType), value))
                {
                    m_LicenseType = value;
                }
                else
                {

                    throw new InvalidEnumArgumentException("License Type is unknown!", (int)value, typeof(eLicenseType));
                }
            }
        }

        public override void setVehicleProperty(int i_Property, string i_InputFromUserStr)
        {
            eMotorCycleInfo property = (eMotorCycleInfo)i_Property;
            int ParssedInputFromUser;

            switch (property)
            {
                case eMotorCycleInfo.VehicleFirma:
                    {
                        Firma = i_InputFromUserStr;
                        break;
                    }

                case eMotorCycleInfo.LicenseType:
                    {
                        if (int.TryParse(i_InputFromUserStr, out ParssedInputFromUser))
                        {
                            LicenseType = (eLicenseType)ParssedInputFromUser; //If License type doesn't exist, exception should returned
                        }
                        else
                        {
                            throw new FormatException("Got bad input!");
                        }

                        break;
                    }

                case eMotorCycleInfo.EngineCapacity:
                    {
                        if (int.TryParse(i_InputFromUserStr, out ParssedInputFromUser))
                        {
                            m_EngineCapacity = ParssedInputFromUser;
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
