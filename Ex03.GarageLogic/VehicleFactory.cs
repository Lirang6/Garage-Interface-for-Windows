using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    using System.Reflection;

    public class VehicleFactory
    {
        public const float k_TruckMaxFuel = 120;
        public const float k_CarMaxFuel = 45;
        public const float k_CarMaxEngineTime = 3.2f;
        public const float k_MotorcycleMaxFuel = 6;
        public const float k_MotorcycleMaxEngineTime = 1.8f;
        public const eFuelType k_TruckFuelType = eFuelType.Soler;
        public const eFuelType k_CarFuelType = eFuelType.Octan95;
        public const eFuelType k_MotorcycleFuelType = eFuelType.Octan98;

        public static Truck CreateTruck(
                                string i_Model, 
                                string i_LicenseNumber,
                                float i_CurrentFeulLevel,
                                string i_Manufacture,
                                float i_CurrentPressure,
                                bool i_HazardousMaterials,
                                float i_MaxLoadWeight)
        {
            Engine engine = new FuelEngine(k_TruckFuelType, i_CurrentFeulLevel, k_TruckMaxFuel);
            Truck truck = new Truck(
                i_Model,
                i_LicenseNumber,
                engine,
                i_Manufacture,
                i_CurrentPressure,
                i_HazardousMaterials,
                i_MaxLoadWeight);

            return truck;
        }

        public static Car CreateCar(string i_Model,
                                    string i_LicenseNumber,
                                    bool i_IsElectric,
                                    float i_CurrentEnergyLevel,
                                    string i_Manufacture,
                                    float i_CurrentPressure,
                                    eColor i_Color,
                                    eNumberOfDoors i_NumberOfDoors)
        {
            Engine engine;

            if (i_IsElectric)
            {
                engine = new ElectricEngine(i_CurrentEnergyLevel, k_CarMaxEngineTime);
            }
            else
            {
                engine = new FuelEngine(k_CarFuelType, i_CurrentEnergyLevel, k_CarMaxFuel);
            }

            Car car = new Car(
                i_Model,
                i_LicenseNumber,
                engine,
                i_Manufacture,
                i_CurrentPressure,
                i_Color,
                i_NumberOfDoors);

            return car;
        }

        public static Motorcycle CreateMotorcycle(
            string i_Model,
            string i_LicenseNumber,
            bool i_IsElectric,
            float i_CurrentEnergyLevel,
            string i_Manufacture,
            float i_CurrentPressure,
            eLicenseType i_LicenseType,
            int i_EngineCapacity)
        {
            Engine engine;

            if (i_IsElectric)
            {
                engine = new ElectricEngine(i_CurrentEnergyLevel, k_MotorcycleMaxEngineTime);
            }
            else
            {
                engine = new FuelEngine(k_MotorcycleFuelType, i_CurrentEnergyLevel, k_MotorcycleMaxFuel);
            }

            Motorcycle motorcycle = new Motorcycle(
                i_Model,
                i_LicenseNumber,
                engine,
                i_Manufacture,
                i_CurrentPressure,
                i_LicenseType,
                i_EngineCapacity);

            return motorcycle;
        }
    }
}
