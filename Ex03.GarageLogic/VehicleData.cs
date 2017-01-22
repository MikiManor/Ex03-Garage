namespace Ex03.GarageLogic
{
    public class VehicleData
    {
        private string m_PhoneNumber;
        private string m_OwnerName;
        private Vehicle m_NewVehicle;
        private GarageController.eVehicleStatus m_VehicleStatus;

        public VehicleData(string i_OwnerName, string i_PhoneNumber, Vehicle i_NewVehicle)
        {
            OwnerName = i_OwnerName;
            PhoneNumber = i_PhoneNumber;
            NewVehicle = i_NewVehicle;
            m_VehicleStatus = GarageController.eVehicleStatus.InRepair;
        }

        public GarageController.eVehicleStatus VehicleStatus
        {
            get { return m_VehicleStatus; }
            set { m_VehicleStatus = value; }
        }

        public string PhoneNumber
        {
            get { return m_PhoneNumber; }
            set { m_PhoneNumber = value; }
        }

        public string OwnerName
        {
            get { return m_OwnerName; }
            set { m_OwnerName = value; }
        }

        public Vehicle NewVehicle
        {
            set { m_NewVehicle = value; }
            get { return m_NewVehicle; }
        }
    }
}
