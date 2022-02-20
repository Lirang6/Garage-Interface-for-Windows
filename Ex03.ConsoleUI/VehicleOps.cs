using System;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    class VehicleOps
    {
        public static void GetDescription(Garage i_Garage)
        {
            string licenseNumber = UIService.GetLine("Enter License Number: ");
            bool inGarage = IsInGarage(i_Garage, licenseNumber);

            if (inGarage)
            {
                Console.WriteLine();
                Console.WriteLine(i_Garage.VehicleDescription(licenseNumber));
            }
            else
            {
                Console.WriteLine("There is no vehicle with this license number in our gargae, try again");
            }
        }

        public static void RechargeVehicle(Garage i_Garage)
        {
            string licenseNumber = UIService.GetLine("Enter License Number: ");
            bool inGarage = IsInGarage(i_Garage, licenseNumber);

            if (inGarage)
            {
                bool validation = false;
                float addedTime = 0;

                while (!validation)
                {
                    Console.WriteLine("Enter hours to charge:");
                    string strAddedTime = Console.ReadLine();
                    validation = float.TryParse(strAddedTime, out addedTime);
                    if (!validation || addedTime < 0)
                    {
                        Console.WriteLine("Your input is invalid, please try again");
                        validation = false;
                    }
                }

                try
                {
                    i_Garage.RechargeVehicle(licenseNumber, addedTime);
                    Console.WriteLine("Vehicle is done recharging.");
                    Console.WriteLine();
                }
                catch (ValueOutOfRangeException)
                {
                    Console.WriteLine("Oops, too much hours.");
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Looks like this vehicle is not electric");
                }
            }
            else
            {
                Console.WriteLine("There is no vehicle with this license number in our gargae, try again");
            }
        }

        public static void RefuelVehicle(Garage i_Garage)
        {
            string licenseNumber = UIService.GetLine("Enter License Number: ");
            bool inGarage = IsInGarage(i_Garage, licenseNumber);

            if (inGarage)
            {

                int fuelTypeNumber = UIService.GetEnum(typeof(eFuelType), "What kind of fuel do you want to use?");
                eFuelType fuelType = (eFuelType)fuelTypeNumber;
                bool validation = false;
                float addedFuel = 0;

                while (!validation)
                {
                    Console.WriteLine("Enter quantity to refuel:");
                    string strAddedFuel = Console.ReadLine();
                    validation = float.TryParse(strAddedFuel, out addedFuel);
                    if (!validation || fuelTypeNumber < 0)
                    {
                        Console.WriteLine("Your input is invalid, please try again");
                        validation = false;
                    }
                }

                try
                {
                    i_Garage.refeulVehicle(licenseNumber, addedFuel, fuelType);
                    Console.WriteLine("Vehicle is done refueling.");
                    Console.WriteLine();
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Type of fuel does not match (might be electric vehicle).");
                }
                catch (ValueOutOfRangeException)
                {
                    Console.WriteLine("Oops, too much fuel.");
                }
            }
            else
            {
                Console.WriteLine("There is no vehicle with this license number in our gargae, try again");
            }
        }

        public static void ListVehicles(Garage i_Garage)
        {
            bool validtion = false;
            bool withFilter = false;

            while (!validtion)
            {
                Console.WriteLine("Do you want to use a filter? (true or false)");
                string strAnswer = Console.ReadLine();
                validtion = bool.TryParse(strAnswer, out withFilter);

                if (!validtion)
                {
                    Console.WriteLine("Your input is invalid, enter true or false");
                    validtion = false;
                }
            }

            if (withFilter)
            {
                int numFilter = UIService.GetEnum(typeof(eStatus), "What Filter would you like to use?");
                eStatus filterStatus = (eStatus)numFilter;

                Console.WriteLine(String.Join(Environment.NewLine, i_Garage.ListGarageVehicles(filterStatus)));

            }
            else
            {

                Console.WriteLine(String.Join(Environment.NewLine, i_Garage.ListGarageVehicles()));
            }
        }

        public static void ChangeStatus(Garage i_Garage)
        {
            string licenseNumber = UIService.GetLine("Enter License Number: ");
            bool inGarage = IsInGarage(i_Garage, licenseNumber);

            if (inGarage)
            {
                int numStatus = UIService.GetEnum(typeof(eStatus), "What status would you like: ");
                eStatus newStatus = (eStatus)numStatus;
                i_Garage.ChangeStatus(licenseNumber, newStatus);
                Console.WriteLine("Vehicle status changed");
            }
            else
            {
                Console.WriteLine("There is no vehicle with this license number in our gargae, try again");
            }
        }

        public static void InflateVehicle(Garage i_Garage)
        {
            string licenseNumber = UIService.GetLine("Enter License Number: ");
            bool inGarage = IsInGarage(i_Garage, licenseNumber);

            if (inGarage)
            {
                i_Garage.InflateVehicle(licenseNumber);
                Console.WriteLine("Vehicle inflated");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("There is no vehicle with this license number in our gargae, try again");
            }

        }

        public static bool IsInGarage(Garage i_Garage, string i_LicenseNumber)
        {
            return i_Garage.IsVehicleInGarage(i_LicenseNumber) != null;
        }
    }
}
