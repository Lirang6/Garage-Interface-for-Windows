using System;

namespace Ex03.GarageLogic
{
    public enum eFuelType
    {
        Soler = 1,
        Octan95 = 2,
        Octan96 = 3,
        Octan98 = 4
    }

    public class FuelEngine : Engine
    {
        internal readonly eFuelType r_FuelType;
        
        public FuelEngine(
            eFuelType i_FuelType,
            float i_CurrentFeulLevel,
            float i_MaxFuelLevel) : base(i_MaxFuelLevel, i_CurrentFeulLevel)
        {
            r_FuelType = i_FuelType;
        }

        public void Refuel(eFuelType i_FuelType, float i_AddedFuel)
        {
            if (r_FuelType == i_FuelType)
            {
                Refill(i_AddedFuel);
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public override string ToString()
        {
            return string.Format("Fuel Engine - Fuel Precentage Left In Tank: {0}, Fuel Type: {1}", m_EnergyLevelPctg, r_FuelType);
        }
    }
}