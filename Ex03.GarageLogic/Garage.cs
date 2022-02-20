using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    using System.Threading;

    public class Garage
    {
        private readonly List<GarageVehicle> r_Vehicles;

        public Garage()
        {
            r_Vehicles = new List<GarageVehicle>();
        }

        public GarageVehicle IsVehicleInGarage(string i_LicenseNumber)
        {
            GarageVehicle garageVehicle = r_Vehicles.Find(gv => gv.r_Vehicle.r_LicenseNumber.Equals(i_LicenseNumber));
            return garageVehicle;
        }

        public void AddGarageVehicle(Vehicle i_Vehicle, String i_OwnerName, string i_OwnerPhone)
        {
            GarageVehicle garageVehicle = new GarageVehicle(i_Vehicle, i_OwnerName, i_OwnerPhone);
            r_Vehicles.Add(garageVehicle);
        }

        public List<string> ListGarageVehicles()
        {
            List<string> relevantNumbers = new List<string>();

            foreach (GarageVehicle garageVehicle in r_Vehicles)
            {
                relevantNumbers.Add(garageVehicle.r_Vehicle.r_LicenseNumber);
            }
            
            return relevantNumbers;

        }

        public List<string> ListGarageVehicles(eStatus i_Status)
        {
            List<string> relevantNumbers = new List<string>();

            foreach (GarageVehicle garageVehicle in r_Vehicles)
            {
                if (garageVehicle.m_Status == i_Status)
                {
                    relevantNumbers.Add(garageVehicle.r_Vehicle.r_LicenseNumber);
                }
            }

            return relevantNumbers;
        }

        public void ChangeStatus(string i_LicenseNumber, eStatus i_NewStatus)
        {
            GarageVehicle garageVehicle = IsVehicleInGarage(i_LicenseNumber);
            garageVehicle.m_Status = i_NewStatus;
        }

        public void InflateVehicle(string i_LicenseNumber)
        {
            GarageVehicle garageVehicle = IsVehicleInGarage(i_LicenseNumber);

            foreach (Wheel wheel in garageVehicle.r_Vehicle.r_Wheels)
            {
                wheel.InflateToMax();
            }
        }

        public void refeulVehicle(string i_LicenseNumber, float i_AddedFuel, eFuelType i_FuelType)
        {
            GarageVehicle garageVehicle = IsVehicleInGarage(i_LicenseNumber);

            if (garageVehicle.r_Vehicle.r_Engine is FuelEngine)
            {
                ((FuelEngine)garageVehicle.r_Vehicle.r_Engine).Refuel(i_FuelType, i_AddedFuel);
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public void RechargeVehicle(string i_LicenseNumber, float i_AddedEngineTime)
        {
            GarageVehicle garageVehicle = IsVehicleInGarage(i_LicenseNumber);

            if (garageVehicle.r_Vehicle.r_Engine is ElectricEngine)
            {
                ((ElectricEngine)garageVehicle.r_Vehicle.r_Engine).Recharge(i_AddedEngineTime);
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public string VehicleDescription(string i_LicenseNumber)
        {
            GarageVehicle garageVehicle = IsVehicleInGarage(i_LicenseNumber);

            return garageVehicle.ToString();
        }
    }
}
