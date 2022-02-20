namespace Ex03.GarageLogic
{
    public class Wheel
    {
        internal readonly string r_Manufacture;
        internal readonly float r_MaxPressure;
        internal float m_CurrentPressure;

        internal Wheel(string i_Manufacture, float i_MaxPressure, float i_CurrentPressure)
        {
            r_Manufacture = i_Manufacture;
            r_MaxPressure = i_MaxPressure;
            m_CurrentPressure = i_CurrentPressure;
        }

        internal void Inflate(float i_AddedPressure)
        {
            if (m_CurrentPressure + i_AddedPressure <= r_MaxPressure)
            {
                m_CurrentPressure += i_AddedPressure;
            }
            else
            {
                throw new ValueOutOfRangeException(0, r_MaxPressure - m_CurrentPressure);
            }
        }

        internal void InflateToMax()
        {
            Inflate(r_MaxPressure - m_CurrentPressure);
        }
    }
}
