using System.Text;

namespace Ex03.GarageLogic
{
    public enum eLicenseType
    {
        A = 1,
        B1 = 2,
        AA = 3,
        BB = 4
    }

    public class Motorcycle : Vehicle
    {
        public const int k_NumOfWheels = 2;
        public const int k_MaxPressure = 30;
        private readonly eLicenseType r_LicenseType;
        private readonly int r_EngineCapacity;

        public Motorcycle (
            string i_Model,
            string i_LicenseNumber,
            Engine i_Engine,
            string i_Manufacture,
            float i_CurrentPressure,
            eLicenseType i_LicenseType, int i_EngineCapacity)
            : base(i_Model, i_LicenseNumber, i_Engine, k_NumOfWheels,
                i_Manufacture, k_MaxPressure, i_CurrentPressure)
        {
            r_LicenseType = i_LicenseType;
            r_EngineCapacity = i_EngineCapacity;
        }

        public override string ToString()
        {
            StringBuilder description = new StringBuilder(base.ToString());
            description.AppendLine(string.Format("The Motorcycle has engine volume of {0}, and its required license is {1}", r_EngineCapacity, r_LicenseType.ToString()));

            return description.ToString();
        }
    }
}
