namespace Ex03.GarageLogic
{
    public class Engine
    {
        internal float m_CurrentEngineEnergy;
        internal readonly float r_MaxEngineEnergy;
        internal float m_EnergyLevelPctg;

        public Engine(float i_MaxEngineEnergy, float i_EngineEnergyLeft)
        {
            r_MaxEngineEnergy = i_MaxEngineEnergy;
            m_CurrentEngineEnergy = i_EngineEnergyLeft;
            m_EnergyLevelPctg = (i_EngineEnergyLeft / i_MaxEngineEnergy) * 100;
        }

        internal void Refill(float i_AddedEngineEnergy)
        {
            if (m_CurrentEngineEnergy + i_AddedEngineEnergy <= r_MaxEngineEnergy)
            {
                m_CurrentEngineEnergy += i_AddedEngineEnergy;
                m_EnergyLevelPctg = (m_CurrentEngineEnergy / r_MaxEngineEnergy) * 100;
            }
            else
            {
                float maxValue = r_MaxEngineEnergy - m_CurrentEngineEnergy;
                throw new ValueOutOfRangeException(0, maxValue);
            }
        }
    }
}
