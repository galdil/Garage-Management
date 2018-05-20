using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class Electric : EnergySource
    {
        internal Electric(Dictionary<string, string> i_VehicleProperties)
            : base(i_VehicleProperties)
        {
        }

        internal float Recharge(float i_AmountToAdd)
        {
            return AddEnergy(i_AmountToAdd);
        }

        public static List<string> GetElectricProperties()
        {
            List<string> electricProperties = new List<string>();
            electricProperties.Add("Current battery status");

            return electricProperties;
        }
    }
}
