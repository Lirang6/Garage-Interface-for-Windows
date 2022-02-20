using System.Text;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        public const int k_NumOfWheels = 16;
        public const int k_MaxPressure = 26;
        private readonly bool r_HazardousMaterials;
        private readonly float r_MaxLoadWeight;

        public Truck(
            string i_Model,
            string i_LicenseNumber,
            Engine i_Engine,
            string i_Manufacture,
            float i_CurrentPressure,
            bool i_HazardousMaterials,
            float i_MaxLoadWeight)
            : base(i_Model, i_LicenseNumber, i_Engine, k_NumOfWheels,
                i_Manufacture, k_MaxPressure, i_CurrentPressure)
        {
            r_HazardousMaterials = i_HazardousMaterials;
            r_MaxLoadWeight = i_MaxLoadWeight;
        }

        public override string ToString()
        {
            StringBuilder description = new StringBuilder(base.ToString());
            description.AppendLine(string.Format("The Truck maximum load weight is {0}, the truck carries hazardous materials: {1}", r_MaxLoadWeight, r_HazardousMaterials.ToString()));

            return description.ToString();
        }
    }
}