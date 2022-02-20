namespace Ex03.GarageLogic
{
    public class ElectricEngine : Engine
    {
        public ElectricEngine(
            float i_EngineTimeLeft,
            float i_MaxEngineTime)
            : base(i_MaxEngineTime, i_EngineTimeLeft)
        {
        }

        internal void Recharge(float i_AddedEngineTime)
        {
            Refill(i_AddedEngineTime);
        }

        public override string ToString()
        {
            return string.Format("Electric Engine - Energy Precentage Left In Battery: {0}", m_EnergyLevelPctg);
        }
    }
}
