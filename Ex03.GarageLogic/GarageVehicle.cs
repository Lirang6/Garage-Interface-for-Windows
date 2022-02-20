using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public enum eStatus
    {
        InRepair = 1,
        FinishedRepair = 2,
        Paid = 3
    }

    public class GarageVehicle
    {
        internal readonly Vehicle r_Vehicle;
        internal readonly string r_OwnerName;
        internal readonly string r_OwnerPhone;
        internal eStatus m_Status;

        public GarageVehicle(
            Vehicle i_Vehicle,
            string i_OwnerName,
            string i_OwnerPhone)
        {
            r_Vehicle = i_Vehicle;
            r_OwnerName = i_OwnerName;
            r_OwnerPhone = i_OwnerPhone;
            m_Status = eStatus.InRepair;
        }

        public override string ToString()
        {
            StringBuilder description = new StringBuilder(r_Vehicle.ToString());
            description.AppendLine(string.Format("Owner's Name: {0}, Vehicle Status: {1}", r_OwnerName, m_Status));

            return description.ToString();
        }
    }
}
