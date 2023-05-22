using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ex03.GarageLogic;
namespace Ex03.ConsoleUI
{
    public class ConsoleUI
    {
        private Garage m_garage;
        public ConsoleUI()
        {
            m_garage = new Garage();
        }
        public void Run()
        {
            printMenu();
            string input = Console.ReadLine();
            while (input!="0")
            {
                switch (input)
                {
                    case "1":
                        AddVehicle();
                        break;
                    case "2":
                        ShowVehicles();
                        break;
                    case "3":
                        ChangeVehicleStatus();
                        break;
                    case "4":
                        AddAirToWheels();
                        break;
                    case "5":
                        AddFuel();
                        break;
                    case "6":
                        ChargeBattery();
                        break;
                    case "7":
                        DisplayOrder();
                        break;
                    case "0":
                        Console.WriteLine("Exiting the program...");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option.");
                        break;
                }
                printMenu();
                input = Console.ReadLine();
            }
        }


        private static void printMenu()
        {
            Console.WriteLine("Welcome To Our Majestic Garage!");
            Console.WriteLine("Enter a number to choose an option:");
            Console.WriteLine("1. Add vehicle");
            Console.WriteLine("2. Show vehicles in garage");
            Console.WriteLine("3. Change vehicle status");
            Console.WriteLine("4. Add air to wheels");
            Console.WriteLine("5. Add fuel");
            Console.WriteLine("6. Charge battery");
            Console.WriteLine("7. Display order");
            Console.WriteLine("0. Exit");
        }


        private static void AddVehicle()
        {
            Order vehicle = getOrderDataFromUser();
        }

        private static Order getOrderDataFromUser()
        {
            Order order = new Order();

            try
            {
                Console.WriteLine("Enter customer name:");
                order.CustomerName = Console.ReadLine();

                Console.WriteLine("Enter phone number (10 digits):");
                order.PhoneNumber = Console.ReadLine();

                eVehicleType selectedType = GetVehicleTypeChoice();
                order.Vehicle = VehicleFactory.CreateVehicle(selectedType);
                order.Status = eStatus.InRepair;
                Console.WriteLine("Object was born");
                getUniqueDataForVehicle(order);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred while getting order data: " + ex.Message);
            }

            return order;
        }

        private static void getUniqueDataForVehicle(Order order)
        {
            Vehicle vehicle = order.Vehicle;
            string[] uniqueAttributes = vehicle.GetUniqueAttributes();
            string[] dataInputFromUser = new string[uniqueAttributes.Length];
            Console.WriteLine("Enter Data for the next Attributes:");

            try
            {
                Console.WriteLine("License Number:");
                dataInputFromUser[0] = Console.ReadLine();
                for (int index = 1; index < uniqueAttributes.Length; index++)
                {
                    Console.WriteLine(uniqueAttributes[index] + ":");
                    dataInputFromUser[index] = Console.ReadLine();
                }

                vehicle.SetUniqueAttributes(dataInputFromUser);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred while getting unique data for vehicle: " + ex.Message);
            }
        }



        private static eVehicleType GetVehicleTypeChoice()
        {
            eVehicleType[] vehicleTypes = (eVehicleType[])Enum.GetValues(typeof(eVehicleType));
            bool isValidChoice = false;
            eVehicleType selectedType = 0;

            while (!isValidChoice)
            {
                Console.WriteLine("Enter vehicle type:");

                int index = 1;
                foreach (eVehicleType type in vehicleTypes)
                {
                    Console.WriteLine($"{index}. {type}");
                    index++;
                }

                string typeChoice = Console.ReadLine();

                if (int.TryParse(typeChoice, out int selectedIndex) && selectedIndex >= 1 && selectedIndex <= vehicleTypes.Length)
                {
                    selectedType = vehicleTypes[selectedIndex - 1];
                    isValidChoice = true;
                }
                else
                {
                    Console.WriteLine("Invalid vehicle type choice. Please try again.");
                }
            }

            return selectedType;
        }




        private static void ShowVehicles()
        {
            Console.WriteLine("Show Vehicles");
        }

        private static void ChangeVehicleStatus()
        {
            Console.WriteLine("Change Vehicle Status");
        }

        private static void AddAirToWheels()
        {
            Console.WriteLine("Add Air to Wheels");
        }

        private static void AddFuel()
        {
            Console.WriteLine("Add Fuel");
        }

        private static void ChargeBattery()
        {
            Console.WriteLine("Charge Battery");
        }

        private static void DisplayOrder()
        {
            Console.WriteLine("Display Order");
        }

        private static void printCars()
        {
            Console.WriteLine("Existing Cars in the Garage");
        }


        
    }
}
