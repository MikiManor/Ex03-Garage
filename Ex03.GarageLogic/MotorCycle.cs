using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class MotorCycle : Vehicle
    {
        private eLicenseType m_LicenseType;

        internal MotorCycle(string i_LicenseNumber, int i_NumOfWheels, int i_MaxWheelsAirPreasure)
            : base(i_LicenseNumber, i_NumOfWheels, i_MaxWheelsAirPreasure)
        {
        }

        public enum eLicenseType
        {
            A = 1,
            A1,
            A2,
            B
        }

        public enum eMotorCycleInfo
        {
            MotorCycleFirma = 1,
            LicenseType
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
                    throw new InvalidEnumArgumentException("License Type is unknown!");
                }
            }
        }

        public override Dictionary<int, string> GetVheicleProperties()
        {
            Dictionary<int, string> motorCycleProperties = new Dictionary<int, string>();

            foreach (eMotorCycleInfo property in Enum.GetValues(typeof(eMotorCycleInfo)))
            {
                if (property == eMotorCycleInfo.LicenseType)
                {
                    motorCycleProperties.Add((int)property, genericEnumUserMsg<eLicenseType>("License Type > "));
                }
                else
                {
                    motorCycleProperties.Add((int)property, property.ToString());
                }
            }

            return motorCycleProperties;
        }

        public override void SetVehicleProperty(int i_Property, string i_InputFromUserStr)
        {
            eMotorCycleInfo property = (eMotorCycleInfo)i_Property;
            int parssedInputFromUser;

            switch (property)
            {
                case eMotorCycleInfo.MotorCycleFirma:
                    {
                        base.Firma = i_InputFromUserStr;
                        break;
                    }

                case eMotorCycleInfo.LicenseType:
                    {
                        if (int.TryParse(i_InputFromUserStr, out parssedInputFromUser))
                        {
                            LicenseType = (eLicenseType)parssedInputFromUser; ////If License type doesn't exist, exception should returned
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
            stringBuilder.AppendFormat("{1}License Type = {2}{0}", Environment.NewLine, "\t", this.m_LicenseType.ToString());
            return stringBuilder + base.ToString();
        }
    }
}
