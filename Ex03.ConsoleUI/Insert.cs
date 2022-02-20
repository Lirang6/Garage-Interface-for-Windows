using System;
using System.Linq;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public enum eVehicleType
    {
        Car = 1,

        Motorcycle = 2,

        Truck = 3
    }

    class Insert
    {
        public static void InsertVehicle(Garage i_Garage)
        {
            bool validtion = false;
            String ownerName = "";

            while (!validtion)
            {
                ownerName = UIService.GetLine("Enter Owner's name: ");
                validtion = ownerName.All(c => char.IsLetter(c) || char.IsWhiteSpace(c));
                if (!validtion)
                {
                    Console.WriteLine("Name is invalid, please try again");
                    validtion = false;
                }
            }

            validtion = false;
            string ownerNumber = "";

            while (!validtion)
            {
                ownerNumber = UIService.GetLine("Enter Owner's phone number: (No dash needed)");
                validtion = ownerNumber.All(c => char.IsDigit(c));
                if (!validtion)
                {
                    Console.WriteLine("Phone number is invalid, please try again");
                    validtion = false;
                }
            }

            int vehicleTypeNumber = UIService.GetEnum(typeof(eVehicleType), "What kind of vehicle is it?");
            eVehicleType vehicleType = (eVehicleType)vehicleTypeNumber;

            string licenseNumber = UIService.GetLine("Enter License Number: ");
            bool inGarage = VehicleOps.IsInGarage(i_Garage, licenseNumber);

            if (!inGarage)
            {
                string model = UIService.GetLine("Enter model name: ");
                string manufacture = UIService.GetLine("Enter wheels manufacture: ");

                switch (vehicleType)
                {
                    case eVehicleType.Car:
                        insertCar(i_Garage, model, licenseNumber, manufacture, ownerName, ownerNumber);
                        break;
                    case eVehicleType.Motorcycle:
                        insertMotorcycle(i_Garage, model, licenseNumber, manufacture, ownerName, ownerNumber);
                        break;
                    case eVehicleType.Truck:
                        insertTruck(i_Garage, model, licenseNumber, manufacture, ownerName, ownerNumber);
                        break;
                }

                Console.WriteLine("Vehicle is now in the garage");
                Console.WriteLine();
            }

            else
            {
                Console.WriteLine("Looks like a vehicle with this license number is already in our garage");
                i_Garage.ChangeStatus(licenseNumber, eStatus.InRepair);
            }
        }

        private static void insertCar(Garage i_Garage, string i_Model, string i_LicenseNumber, string i_Manufacture, string i_OwnerName, string i_OwnerNumber)
        {
            bool carIsElectirc = isElectric();
            float currentEnergyLevel = UIService.CheckFloatValue(
                carIsElectirc ? VehicleFactory.k_CarMaxEngineTime : VehicleFactory.k_CarMaxFuel, "energy");
            float currentPressure = UIService.CheckFloatValue(Car.k_MaxPressure, "wheel pressure");
            int colorNumber = UIService.GetEnum(typeof(eColor), "What color is the car?");
            eColor color = (eColor)colorNumber;

            bool validtion = false;
            int intNumberOfDoors = 0;

            while (!validtion)
            {
                Console.WriteLine("Enter amount of doors: ");
                string input = Console.ReadLine();
                validtion = int.TryParse(input, out intNumberOfDoors);
                if (!validtion || intNumberOfDoors < 2 || intNumberOfDoors > 5)
                {
                    Console.WriteLine("Your input is invalid, please try again");
                    validtion = false;
                }
            }

            eNumberOfDoors numberOfDoors = (eNumberOfDoors)intNumberOfDoors;

            Car car = VehicleFactory.CreateCar(i_Model, i_LicenseNumber, carIsElectirc, currentEnergyLevel, i_Manufacture, currentPressure, color, numberOfDoors);
            i_Garage.AddGarageVehicle(car, i_OwnerName, i_OwnerNumber);
        }

        private static void insertMotorcycle(Garage i_Garage, string i_Model, string i_LicenseNumber, string i_Manufacture, string i_OwnerName, string i_OwnerNumber)
        {
            bool motorcycleIsElectirc = isElectric();
            float currentEnergyLevel = UIService.CheckFloatValue(
                motorcycleIsElectirc ? VehicleFactory.k_MotorcycleMaxEngineTime : VehicleFactory.k_MotorcycleMaxFuel, "energy");
            float currentPressure = UIService.CheckFloatValue(Motorcycle.k_MaxPressure, "wheel pressure");
            int intLicenseType = UIService.GetEnum(typeof(eLicenseType), "Enter license type: ");
            eLicenseType licenseType = (eLicenseType)intLicenseType;

            bool validtion = false;
            int engineCapacity = 0;

            while (!validtion)
            {
                Console.WriteLine("What is the engine volume?");
                string input = Console.ReadLine();
                validtion = int.TryParse(input, out engineCapacity);
                if (!validtion || engineCapacity < 0)
                {
                    Console.WriteLine("Your input is invalid, please try again");
                    validtion = false;
                }
            }

            Motorcycle motorcycle = VehicleFactory.CreateMotorcycle(i_Model, i_LicenseNumber, motorcycleIsElectirc, currentEnergyLevel, i_Manufacture, currentPressure, licenseType, engineCapacity);
            i_Garage.AddGarageVehicle(motorcycle, i_OwnerName, i_OwnerNumber);
        }

        private static void insertTruck(Garage i_Garage, string i_Model, string i_LicenseNumber, string i_Manufacture, string i_OwnerName, string i_OwnerNumber)
        {
            float currentEnergyLevel = UIService.CheckFloatValue(VehicleFactory.k_TruckMaxFuel, "energy");
            float currentPressure = UIService.CheckFloatValue(Truck.k_MaxPressure, "wheel pressure");

            bool validtion = false;
            bool isHazardous = false;

            while (!validtion)
            {
                Console.WriteLine("Does it carry hazardous materials? (true or false)");
                string input = Console.ReadLine();
                validtion = bool.TryParse(input, out isHazardous);
                if (!validtion)
                {
                    Console.WriteLine("Your input is invalid, enter true or false");
                    validtion = false;
                }
            }

            validtion = false;
            int maxLoadWeight = 0;

            while (!validtion)
            {
                Console.WriteLine("What is the maximum load weight?");
                string input = Console.ReadLine();
                validtion = int.TryParse(input, out maxLoadWeight);
                if (!validtion || maxLoadWeight < 0)
                {
                    Console.WriteLine("Your input is invalid, please try again");
                    validtion = false;
                }
            }

            Truck truck = VehicleFactory.CreateTruck(i_Model, i_LicenseNumber, currentEnergyLevel, i_Manufacture, currentPressure, isHazardous, maxLoadWeight);
            i_Garage.AddGarageVehicle(truck, i_OwnerName, i_OwnerNumber);
        }

        private static bool isElectric()
        {
            bool validtion = false;
            bool isElectric = false;

            while (!validtion)
            {
                Console.WriteLine("Is it electric? (true or false)");
                string input = Console.ReadLine();
                validtion = bool.TryParse(input, out isElectric);
                if (!validtion)
                {
                    Console.WriteLine("Your input is invalid, enter true or false");
                    validtion = false;
                }
            }

            return isElectric;
        }
    }
}
