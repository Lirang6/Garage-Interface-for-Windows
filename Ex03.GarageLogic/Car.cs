using System.Text;

namespace Ex03.GarageLogic
{
    public enum eColor
    {
        Red = 1,
        Silver = 2,
        White = 3,
        Black = 4
    }

    public enum eNumberOfDoors
    {
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5
    }

    public class Car : Vehicle
    {
        public const int k_NumOfWheels = 4;
        public const int k_MaxPressure = 32;
        private readonly eColor r_Color;
        private readonly eNumberOfDoors m_NumberOfDoors;

        public Car(
            string i_Model,
            string i_LicenseNumber,
            Engine i_Engine,
            string i_Manufacture,
            float i_CurrentPressure,
            eColor i_Color,
            eNumberOfDoors i_NumberOfDoors)
            : base(i_Model, i_LicenseNumber, i_Engine, k_NumOfWheels,
                i_Manufacture, k_MaxPressure, i_CurrentPressure)
        {
            r_Color = i_Color;
            m_NumberOfDoors = i_NumberOfDoors;
        }

        public override string ToString()
        {
            StringBuilder description = new StringBuilder(base.ToString());
            description.AppendLine(string.Format("The car has {0} doors, and its color is {1}", m_NumberOfDoors.ToString(), r_Color.ToString()));

            return description.ToString();
        }
    }
}
