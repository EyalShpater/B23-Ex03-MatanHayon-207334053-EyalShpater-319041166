using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class ConsoleUI
    {
        private const int k_InvalidCohice = -1;
        private const object k_NotFound = null;
        private Garage m_Garage;

        public ConsoleUI()
        {
            m_Garage = new Garage();
        }

        public void Run()
        {
            bool endProgram = false;

            while (!endProgram)
            {
                printMenu();
                int input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case (int)eMenuOptions.AddVehicle:
                        AddVehicle();
                        break;
                    case (int)eMenuOptions.DisplayGarageVehicles:
                        showVehiclesByStatusMenu();
                        break;
                    case (int)eMenuOptions.ChangeVehicleStatus:
                        ChangeVehicleStatus();
                        break;
                    case (int)eMenuOptions.AddAirToWheels:
                        AddAirToWheels();
                        break;
                    case (int)eMenuOptions.AddFuel:
                        AddFuel();
                        break;
                    case (int)eMenuOptions.ChargeBattery:
                        ChargeBattery();
                        break;
                    case (int)eMenuOptions.DisplayOrder:
                        DisplayOrder();
                        break;
                    case (int)eMenuOptions.Exit:
                        Console.WriteLine("Exiting the program...");
                        endProgram = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option.");
                        break;
                }
            }
        }


        private static void printMenu()
        {
            Console.WriteLine($@"Welcome To Our Majestic Garage!
Enter a number to choose an option:
{(int)eMenuOptions.AddVehicle}. Add vehicle
{(int)eMenuOptions.DisplayGarageVehicles}. Show vehicles in garage
{(int)eMenuOptions.ChangeVehicleStatus}. Change vehicle status
{(int)eMenuOptions.AddAirToWheels}. Add air to wheels
{(int)eMenuOptions.AddFuel}. Add fuel
{(int)eMenuOptions.ChargeBattery}. Charge battery
{(int)eMenuOptions.DisplayOrder}. Display order
{(int)eMenuOptions.Exit}. Exit");
        }


        private void AddVehicle()
        {
            string licenseNumber;
            Order order;

            Console.WriteLine("Enter license number:");
            licenseNumber = Console.ReadLine();
            order = m_Garage.GetOrderByLicenseNumber(licenseNumber);
            if (order == k_NotFound)
            {
                order = getOrderDataFromUser(licenseNumber);
            }
            else
            {
                Console.WriteLine(@"Vehicle already in Garage.
Changed Status to In-Repair");
                order.Status = eStatus.InRepair;
            }
        }

        private Order getOrderDataFromUser(string i_LicenseNumber)
        {
            getCustomerDetails(out string customername, out string phoneNumber, out Vehicle vehicle);
            Order order = new Order(vehicle, customername, phoneNumber);
            Console.WriteLine("Object was born"); //
            getAndSetGeneralDataForVehicleFromUser(vehicle, i_LicenseNumber);
            getAndSetUniqueDataForVehicleFromUser(vehicle);
            m_Garage.AddNewOrder(order);

            return order;
        }

        private void getCustomerDetails(out string o_Name, out string o_PhoneNumber, out Vehicle o_Vehicle)
        {
            Console.WriteLine("Enter customer name:");
            o_Name = Console.ReadLine();
            Console.WriteLine("Enter phone number (10 digits):");
            o_PhoneNumber = Console.ReadLine();
            o_Vehicle = getVehicleFromUser();
        }

        private Vehicle getVehicleFromUser()
        {
            int selectedVehicleType = getVehicleTypeChoiceFromUser();

            return VehicleFactory.CreateVehicle(selectedVehicleType);
        }

        private static void getAndSetUniqueDataForVehicleFromUser(Vehicle io_Vehicle)
        {
            string[] uniqueAttributes = io_Vehicle.GetUniqueAttributes();
            string[] dataInputFromUser = new string[uniqueAttributes.Length];

            Console.WriteLine("Enter Data for the next Attributes:");
            try
            {
                for (int index = 0; index < uniqueAttributes.Length; index++)
                {
                    Console.WriteLine(uniqueAttributes[index] + ":");
                    dataInputFromUser[index] = Console.ReadLine();
                }

                io_Vehicle.SetUniqueAttributes(dataInputFromUser);
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error occurred while getting unique data for vehicle: " + ex.Message);
            }
        }

        private static void getAndSetGeneralDataForVehicleFromUser(Vehicle o_Vehicle, string i_LicenseNumber)
        {
            Console.WriteLine("Enter current energy ammount:");
            string currentEnergyAmmount = Console.ReadLine();
            Console.WriteLine("Enter wheels manufactorer:");
            string wheelsManufatorer = Console.ReadLine();
            Console.WriteLine("Enter wheels AirPressure");
            string wheelsAirPressure = Console.ReadLine();
            Console.WriteLine("Enter Car model:");
            string carModel = Console.ReadLine();

            o_Vehicle.SetGeneralAttributes(i_LicenseNumber, currentEnergyAmmount, 
                wheelsManufatorer, wheelsAirPressure, carModel);
        }

        private int getVehicleTypeChoiceFromUser()
        {
            bool isValidChoice = false;
            int selectedIndex = k_InvalidCohice;
            int numOfTypes = VehicleFactory.GetVehiclesTypes().Length;
            string typeChoice;

            while (!isValidChoice)
            {
                printVehiclesTypes();   
                typeChoice = Console.ReadLine();
                isValidChoice = isValidVehicleTypeChoise(typeChoice, ref selectedIndex, numOfTypes);
                if (!isValidChoice)
                {
                    Console.WriteLine("Invalid vehicle type choice. Please try again.");
                }
            }

            return selectedIndex;
        }

        private void printVehiclesTypes()
        {
            string[] vehiclesTypes = VehicleFactory.GetVehiclesTypes();

            Console.WriteLine("Enter vehicle type:");
            for (int i = 0; i < vehiclesTypes.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {vehiclesTypes[i]}");
            }
        }

        private bool isValidVehicleTypeChoise(string i_Choice, ref int io_SelectedIndex, int i_NumOfTypes)
        {
            return int.TryParse(i_Choice, out io_SelectedIndex) &&
                    isValidValueInRange(io_SelectedIndex, i_NumOfTypes, 1);
        }

        private bool isValidValueInRange(int i_Value, int i_Max, int i_Min)
        {
            return i_Value <= i_Max && i_Value >= i_Min;
        }

        private void showVehiclesByStatusMenu()
        {
            int userInput=0;
            bool isValidInput = false;

            while (!isValidInput)
            {
                Console.WriteLine("Choose a status:");
                for (int i = 0; i < Enum.GetNames(typeof(eStatus)).Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {Enum.GetName(typeof(eStatus), i)}");
                }

                Console.WriteLine("Enter the corresponding number: ");
                if (!int.TryParse(Console.ReadLine(), out userInput) || userInput < 1 || userInput > Enum.GetNames(typeof(eStatus)).Length)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
                else
                {
                    isValidInput = true;
                }
            }

            eStatus status = (eStatus)(userInput - 1);
            DisplayVehiclesByStatus(status);
        }


        private void DisplayVehiclesByStatus(eStatus status)
        {
            List<string> licenseNumbers = m_Garage.GetLicenseNumbersByStatus(status.ToString());

            Console.WriteLine($"Vehicles with status '{status}':");
            if (licenseNumbers.Count == 0)
            {
                Console.WriteLine("No vehicles with the specified status found.");
            }
            else
            {
                foreach (string licenseNumber in licenseNumbers)
                {
                    Console.WriteLine(licenseNumber);
                }
            }
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
