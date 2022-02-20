using System;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    class Program
    {
        private enum eAction
        {
            Insert = 1,
            List = 2,
            Change = 3,
            Inflate = 4,
            Refuel = 5,
            Recharge = 6,
            Description = 7,
            Exit = 8
        }

        static void Main(string[] args)
        {
            runGarage();
        }

        private static void runGarage()
        {
            Garage garage = new Garage();
            Console.WriteLine("Welcome to Liran and Omer Garage");
            bool garageIsOpen = true;

            while (garageIsOpen)
            {
                runAction(garage, ref garageIsOpen);
            }

            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
        }

        private static void runAction(Garage i_Garage, ref bool io_GarageIsOpen)
        {
            bool validtion = false;
            int actionIndex = 0;

            while (!validtion)
            {
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1. Insert vehicle");
                Console.WriteLine("2. List vehicles");
                Console.WriteLine("3. Change vehicle status");
                Console.WriteLine("4. Inflate vehicle");
                Console.WriteLine("5. Refuel vehicle");
                Console.WriteLine("6. Recharge vehicle");
                Console.WriteLine("7. Get vehicle description");
                Console.WriteLine("8. Exit");

                string input = Console.ReadLine();
                validtion = int.TryParse(input, out actionIndex);
                if (!validtion || actionIndex < 1 || actionIndex > 8)
                {
                    Console.WriteLine("Your input is invalid, please try again");
                    validtion = false;
                }
            }

            eAction action = (eAction)actionIndex;

            switch (action)
            {
                case eAction.Insert:
                    Insert.InsertVehicle(i_Garage);
                    break;
                case eAction.List:
                    VehicleOps.ListVehicles(i_Garage);
                    break;
                case eAction.Change:
                    VehicleOps.ChangeStatus(i_Garage);
                    break;
                case eAction.Inflate:
                    VehicleOps.InflateVehicle(i_Garage);
                    break;
                case eAction.Refuel:
                    VehicleOps.RefuelVehicle(i_Garage);
                    break;
                case eAction.Recharge:
                    VehicleOps.RechargeVehicle(i_Garage);
                    break;
                case eAction.Description:
                    VehicleOps.GetDescription(i_Garage);
                    break;
                case eAction.Exit:
                    Console.WriteLine("Have a good one.");
                    io_GarageIsOpen = false;
                    break;
            }
        }
    }
}