using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private string m_VehicleModelName;
        private string m_LicenseNumber;
        private float m_PercentageOfEnergyLeft;
        private string m_OwnerName;
        private string m_OwnerPhone;
        private StatusOfVehicle m_VehicleStatus;
        private EnergySource m_SourceOfEnergy;
        private List<Wheel> m_WheelSet;
        private Dictionary<string, string> m_VehicleProperties;

        internal Vehicle(Dictionary<string, string> i_VehicleProperties)
        {
            m_VehicleProperties = i_VehicleProperties;
            m_VehicleModelName = i_VehicleProperties["Model name"];
            m_LicenseNumber = i_VehicleProperties["License number"];
            m_OwnerName = i_VehicleProperties["Owner name"];
            m_OwnerPhone = i_VehicleProperties["Owner phone"];
            m_VehicleStatus = StatusOfVehicle.InRepair;

            if (i_VehicleProperties["Type of energy"] == "Electric")
            {
                m_SourceOfEnergy = new Electric(i_VehicleProperties);
            }

            else
            {
                m_SourceOfEnergy = new Fuel(i_VehicleProperties);
            }

            m_WheelSet = createCarWheels(i_VehicleProperties);
            m_PercentageOfEnergyLeft = m_SourceOfEnergy.EnergyPercentageCalculator();
            m_VehicleProperties.Add("Percentage of energy left in vehicle", m_PercentageOfEnergyLeft.ToString());
        }

        public enum StatusOfVehicle { InRepair, Fixed, Paid }

        internal float PercentageOfEnergyLeft
        {
            get { return m_PercentageOfEnergyLeft; }
        }
        internal StatusOfVehicle VehicleStatus
        {
            get { return m_VehicleStatus; }
            set { m_VehicleStatus = value; }
        }
        internal EnergySource SourceOfEnergy
        {
            get { return m_SourceOfEnergy; }
        }
        internal string LicenseNumber
        {
            get { return m_LicenseNumber; }
        }
        internal Dictionary<string,string> VehicleDictionary
        {
            get { return m_VehicleProperties; }
        }

        internal List<Wheel>  Wheels
        {
            get { return m_WheelSet; }
        }

        private List<Wheel> createCarWheels(Dictionary<string, string> i_VehicleProperties)
        {
            int wheelsNumber;
            bool converted = Int32.TryParse(i_VehicleProperties["Number of wheels"], out wheelsNumber);

            if (!converted)
            {
                throw new ArgumentException("Number of wheels should be a non-negative integer.");
            }

            List<Wheel> wheels = new List<Wheel>(wheelsNumber);
            for (int i = 0; i < wheelsNumber; i++)
            {
                wheels.Add(new Wheel(i_VehicleProperties));
            }

            return wheels;
        }
    }
}
