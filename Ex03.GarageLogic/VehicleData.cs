using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class VehicleData
    {
        private string m_PhoneNumber;
        private string m_OwnerName;
        private Vehicle m_NewVehicle;

        public VehicleData(string i_OwnerName, string i_PhoneNumber, Vehicle i_NewVehicle)
        {
            OwnerName = i_OwnerName;
            PhoneNumber = i_PhoneNumber;
            NewVehicle = i_NewVehicle;
        }

        public string PhoneNumber
        {
            get { return m_PhoneNumber; }
            set { m_PhoneNumber = value; }
        }
        public string OwnerName
        {
            get { return m_OwnerName ; }
            set { m_OwnerName = value; }
        }
        public Vehicle NewVehicle
        {
            set { m_NewVehicle = value; }
        }
    }
}
