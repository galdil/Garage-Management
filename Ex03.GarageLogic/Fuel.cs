using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class Fuel : EnergySource
    {
        private readonly FuelType m_FuelType;

        internal Fuel(Dictionary<string, string> i_VehicleProperties)
            : base(i_VehicleProperties)
        {
            m_FuelType = FieldsChecker.CheckValidFuelType(i_VehicleProperties["Fuel type"]);
        }

        public enum FuelType { Soler, Octan95, Octan96, Octan98 }
        public FuelType TypeOfFuel
        {
            get { return m_FuelType; }
        }

        internal float Refuel(float i_AmountToAdd, FuelType i_FuelType)
        {
            if (i_FuelType.Equals(m_FuelType))
            {
                return AddEnergy(i_AmountToAdd);
            }

            else
            {
                throw new ArgumentException("The fuel you're trying to put isn't from the correct type.");
            }
        }

        public static List<string> GetFuelProperties()
        {
            List<string> fuelPropertiesList = new List<string>();
            fuelPropertiesList.Add("Current fuel amount");

            return fuelPropertiesList;
        }
    }
}
