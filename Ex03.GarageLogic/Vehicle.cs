using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private readonly int r_MaxWheelsAirPreasure;
        private string m_VehicleModel;
        private string m_LicenseNumber;
        private Engine m_CarEngine;
        private float m_EnergyRemains;
        private int m_NumOfWheels;
        private List<Wheel> m_WheelsOfVehicle;

        public Vehicle(string i_LicenseNumber, int i_NumOfWheels, int i_MaxWheelsAirPreasuer)
        {
            m_LicenseNumber = i_LicenseNumber;
            NumOfWheels = i_NumOfWheels;
            r_MaxWheelsAirPreasure = i_MaxWheelsAirPreasuer;
            m_WheelsOfVehicle = new List<Wheel>();      
        }

        public enum eVehicleInfo
        {
            VehicleFirma = 1
        }

        public Engine Engine
        {
            get { return m_CarEngine; }
            set { m_CarEngine = value; }
        }

        public string Firma
        {
            get { return m_VehicleModel; }
            set { m_VehicleModel = value; }
        }

        public float EnergyPrecentLeft
        {
            get
            {
                return m_CarEngine.EnergyPrecentLeft;
            }
        }

        public string LicenseNumber
        {
            get { return m_LicenseNumber; }
            set { m_LicenseNumber = value; }
        }

        public int NumOfWheels
        {
            get { return m_NumOfWheels; }
            set
            {
                if (value > 0)
                {
                    m_NumOfWheels = value;
                }
                else
                {
                    throw new ArgumentException("Wrong number of Wheels entered!");
                }
            }
        }

        public float MaxWheelsPreasure
        {
            get { return r_MaxWheelsAirPreasure; }
        }

        public static string genericEnumUserMsg<T>(string i_Property)
        {
            StringBuilder stringBuilder = new StringBuilder();
            int propertyIndex = 1;

            stringBuilder.AppendFormat("\tPlease choose {0} : {1}", i_Property, Environment.NewLine);
            foreach (T currentValue in Enum.GetValues(typeof(T)))
            {
                stringBuilder.AppendFormat("\t\t{0} - {1}{2}", propertyIndex, currentValue.ToString(), Environment.NewLine);
                propertyIndex++;
            }

            return stringBuilder.ToString();
        }

        public override string ToString()
        {
            StringBuilder vehicleInfo = new StringBuilder();
            vehicleInfo.AppendFormat("{1}Vehicle Firma = {2}{0}{1}Number Of Wheels = {3}{0}{1}Wheels Information = {0}{4}{0}", Environment.NewLine, "\t", m_VehicleModel, m_NumOfWheels, GetAllWheelsInformation());
            return vehicleInfo.ToString();
        }

        public StringBuilder GetAllWheelsInformation()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (Wheel wheelInCollection in m_WheelsOfVehicle)
            {
                stringBuilder.AppendLine(wheelInCollection.ToString());
            }

            return stringBuilder;
        }

        public virtual Dictionary<int, string> GetVheicleProperties() ////should return the firma of vheicle only, the derived classes should return the additional properties the have
        {
            Dictionary<int, string> vehicleProperties = new Dictionary<int, string>();
            foreach (eVehicleInfo property in Enum.GetValues(typeof(eVehicleInfo)))
            {
                vehicleProperties.Add((int)property, property.ToString());
            }

            return vehicleProperties;
        }

        public virtual void SetVehicleProperty(int i_Property, string i_InputFromUserStr) //// should be overriden by derived classes - (more "cases")
        {
            eVehicleInfo property = (eVehicleInfo)i_Property;
            switch (property)
            {
                case eVehicleInfo.VehicleFirma:
                    Firma = i_InputFromUserStr;
                    break;
            }
        }

        internal void SetAllWheels(List<WheelCollection> i_WheelsCollection) ////Gets list of WheelsCollection struct
        {
            if (i_WheelsCollection.Count == (int)m_NumOfWheels)
            {
                foreach (WheelCollection wheel in i_WheelsCollection)
                {
                    SetWheel(wheel.WheelFirma, wheel.CurrentAirPreasure);
                }
            }
            else
            {
                throw new ArgumentException("Not all wheels passed");
            }
        }

        internal void AddAirToWheels(float i_AirToAdd)
        {
            if (m_WheelsOfVehicle.Count != 0)
            {
                foreach (Wheel wheel in m_WheelsOfVehicle)
                {
                    try
                    {
                        wheel.TireInflating(i_AirToAdd);
                    }
                    catch (ValueOutOfRangeException)
                    {
                        wheel.TireInflating(wheel.MaxRecommandedAirPreasure - wheel.CurrentAirPreasure);
                    }
                }
            }
        }

        internal void InfalingAllWheelsToMaxPreasure()
        {
            if (m_WheelsOfVehicle.Count != 0)
            {
                foreach (Wheel wheel in m_WheelsOfVehicle)
                {
                    wheel.TireInflating(wheel.MaxRecommandedAirPreasure - wheel.CurrentAirPreasure);
                }
            }
        }

        private void SetWheel(string i_WheelFirma, float i_CurrentAirPreasure)
        {
            if (m_WheelsOfVehicle.Count < (int)m_NumOfWheels)
            {
                Wheel newWheel = new Wheel(i_WheelFirma, i_CurrentAirPreasure, r_MaxWheelsAirPreasure);
                m_WheelsOfVehicle.Add(newWheel);
            }
            else
            {
                throw new ValueOutOfRangeException("Cannot add another Weel, Maximum reached", (int)m_NumOfWheels, 0);
            }
        }
    }
}
