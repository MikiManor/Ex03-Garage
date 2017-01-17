using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {

        private string m_VehicleModel;
        private string m_LicenseNumber;
        private float m_EnergyRemains;
        private readonly int r_NumOfWheels;
        private readonly List<Wheel> r_WheelsOfVehicle;
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
        //Vehicle can have different Wheels with different firmas and specs
        public void SetWheel(string i_WheelFirma, float i_CurrentAirPreasure, float i_MaxRecommandedAirPreasure)
        {
            //To check if need here try-catch
            if(r_WheelsOfVehicle.Lenght() < r_NumOfWheels)
            {
                Wheel newWheel = new Wheel(i_WheelFirma, i_CurrentAirPreasure, i_MaxRecommandedAirPreasure);
            }
            else
            {
                throw new Exception("/////////////////////////////")
            }
        }
    }
}
