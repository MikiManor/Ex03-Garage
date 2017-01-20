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

        protected string m_VehicleModel;
        protected string m_LicenseNumber;
        protected float m_EnergyRemains;
        protected eNumOfWheels r_NumOfWheels;
        protected readonly List<Wheel> r_WheelsOfVehicle;
        private readonly int k_MaxWheelsAirPreasure;


        public Vehicle(string i_Model, string i_LicenseNumber, eNumOfWheels i_NumOfWheels, int i_MaxWheelsAirPreasuer)
        {
            m_VehicleModel = i_Model;
            m_LicenseNumber = i_LicenseNumber;
            NumOfWheels = i_NumOfWheels;
            k_MaxWheelsAirPreasure = i_MaxWheelsAirPreasuer;
        }
        public override string ToString()
        {
            StringBuilder vehicleInfo = new StringBuilder();
            //לממש לצורך הדפסת פרטי הרכב
            return vehicleInfo.ToString();
        }
        //Vehicle  has wheels with the same firmas and specs
        public void SetWheel(string i_WheelFirma, float i_CurrentAirPreasure)
        {
            //To check if need here try-catch
            if (r_WheelsOfVehicle.Count < (int)r_NumOfWheels)
            {
                Wheel newWheel = new Wheel(i_WheelFirma, i_CurrentAirPreasure, k_MaxWheelsAirPreasure);
                r_WheelsOfVehicle.Add(newWheel);
            }
            else
            {
                throw new ValueOutOfRangeException("Cannot add another Weel, Maximim reached", (int)r_NumOfWheels, 1);
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



    }
}