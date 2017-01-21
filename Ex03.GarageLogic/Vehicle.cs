using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        public enum eNumOfWheels
        {
            two = 2,
            four = 4,
            twelve = 12
        }

        public enum eVehicleInfo
        {
            VehicleFirma = 1
        }

        private string m_VehicleModel;
        private string m_LicenseNumber;
        private Engine m_CarEngine;
        private float m_EnergyRemains;
        private eNumOfWheels r_NumOfWheels;
        private readonly List<Wheel> r_WheelsOfVehicle;
        private readonly int k_MaxWheelsAirPreasure;


        public Vehicle(string i_LicenseNumber, eNumOfWheels i_NumOfWheels, int i_MaxWheelsAirPreasuer)
        {
            m_LicenseNumber = i_LicenseNumber;
            NumOfWheels = i_NumOfWheels;
            k_MaxWheelsAirPreasure = i_MaxWheelsAirPreasuer;
            r_WheelsOfVehicle = new List<Wheel>();      
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



        public override string ToString()
        {
            StringBuilder vehicleInfo = new StringBuilder();
            //לממש לצורך הדפסת פרטי הרכב
            return vehicleInfo.ToString();
        }
        
        private void SetWheel(string i_WheelFirma, float i_CurrentAirPreasure)
        {
            if (r_WheelsOfVehicle.Count < (int)r_NumOfWheels)
            {
                Wheel newWheel = new Wheel(i_WheelFirma, i_CurrentAirPreasure, k_MaxWheelsAirPreasure);
                r_WheelsOfVehicle.Add(newWheel);
            }
            else
            {
                throw new ValueOutOfRangeException("Cannot add another Weel, Maximum reached", (int)r_NumOfWheels, 1);
            }
        }
        
        internal void SetAllWheels(List<WheelCollection> i_WheelsCollection) //Gets list of WheelsCollection struct
        {
            if(i_WheelsCollection.Count == (int)r_NumOfWheels)
            {
                foreach(WheelCollection wheel in i_WheelsCollection)
                {
                    SetWheel(wheel.firma, wheel.currentAirPreasure);
                }
            }
            else
            {
                throw new ArgumentException("Not all wheels passed");
            }
        }

        internal void AddAirToWheels(float i_AirToAdd)
        {
            if (r_WheelsOfVehicle.Count != 0)
            {
                foreach (Wheel wheel in r_WheelsOfVehicle)
                {
                    try
                    {
                        wheel.TireInflating(i_AirToAdd);
                    }
                    catch (ValueOutOfRangeException)
                    {
                        //if one wheel is passing the max so inflating the wheel till the max
                        wheel.TireInflating(wheel.MaxRecommandedAirPreasure - wheel.CurrentAirPreasure);
                    }
                }
            }
        }

        internal void InfalingAllWheelsToMaxPreasure()
        {
            if (r_WheelsOfVehicle.Count != 0)
            {
                foreach (Wheel wheel in r_WheelsOfVehicle)
                {
                    wheel.TireInflating(wheel.MaxRecommandedAirPreasure - wheel.CurrentAirPreasure);
                }
            }
        }

        public eNumOfWheels NumOfWheels
        {
            get { return r_NumOfWheels; }
            set
            {
                if (Enum.IsDefined(typeof(eNumOfWheels), value))
                {
                    r_NumOfWheels = value;
                }
                else
                {
                    throw new InvalidEnumArgumentException("Wrong number of Wheels entered!", (int)value, typeof(eNumOfWheels));
                }
            }
        }

        public Dictionary<int, string> GetVheicleProperties() //should return the firma of vheicle only, the derived classes should return the additional properties the have
        {
            Dictionary<int, string> vehicleProperties = new Dictionary<int, string>();
            
            foreach (eVehicleInfo property in Enum.GetValues(typeof(eVehicleInfo)))
            {
                vehicleProperties.Add((int)property, property.ToString());
            }

            return vehicleProperties;
        }

        public virtual void setVehicleProperty(int i_Property, string i_InputFromUserStr) // should be overriden by derived classes - (more "cases")
        {
            eVehicleInfo property = (eVehicleInfo)i_Property;
            switch (property)
            {
                case eVehicleInfo.VehicleFirma:
                    Firma = i_InputFromUserStr;
                    break;
            }
        }

        public static string genericEnumUserMsg<T>(string i_Property)
        {
            StringBuilder stringBuilder = new StringBuilder();
            int propertyIndex = 1;

            stringBuilder.AppendFormat("Please choose {0} : {1}", i_Property, Environment.NewLine);
            foreach (T currentValue in Enum.GetValues(typeof(T)))
            {
                stringBuilder.AppendFormat("{0} - {1}{2}", propertyIndex, currentValue.ToString(), Environment.NewLine);
                propertyIndex++;
            }

            return stringBuilder.ToString();
        }
    }
}
