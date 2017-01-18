using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {

        protected string m_VehicleModel;
        protected string m_LicenseNumber;
        protected float m_EnergyRemains;
        protected readonly int r_NumOfWheels;
        protected readonly List<Wheel> r_WheelsOfVehicle;
        bool m_IsElectricEngine;


        public Vehicle(string i_Model, string i_LicenseNumber, int i_NumOfWheels)
        {
            m_VehicleModel = i_Model;
            m_LicenseNumber = i_LicenseNumber;
            r_NumOfWheels = i_NumOfWheels;
        }
        public override string ToString()
        {
            StringBuilder vehicleInfostring = new StringBuilder();
            //לממש לצורך הדפסת פרטי הרכב
            return vehicleInfostring.ToString();
        }
        //Vehicle  has wheels with the same firmas and specs
        public void SetWheel(string i_WheelFirma, float i_CurrentAirPreasure, float i_MaxRecommandedAirPreasure)
        {
            //To check if need here try-catch
            if(r_WheelsOfVehicle.Count < r_NumOfWheels)
            {
                Wheel newWheel = new Wheel(i_WheelFirma, i_CurrentAirPreasure, i_MaxRecommandedAirPreasure);
                r_WheelsOfVehicle.Add(newWheel);
            }
            else
            {
                throw new ValueOutOfRangeException("Cannot add another Weel, Maximim reached", r_NumOfWheels, 1);
            }
        }
    }
}
