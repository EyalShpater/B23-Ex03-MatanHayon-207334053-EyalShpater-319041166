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

        public void RunGarageProgram()
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
                order.Status = eOrderStatus.InRepair;
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
            Console.WriteLine("===================================");
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
            Console.WriteLine("Enter vehicle model:");
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

            return selectedIndex - 1;
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
            int userInput;
            bool isValidInput = false;
            string input;

            while (!isValidInput)
            {
                input = printVehicleOrderStatusMenuAndGetStatusFromUser();
                if (int.TryParse(input, out userInput) && Enum.IsDefined(typeof(eOrderStatus), userInput))
                {
                    isValidInput = true;
                    eOrderStatus status = (eOrderStatus)(userInput);
                    DisplayVehiclesByStatus(status);
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }
        }

        private string printVehicleOrderStatusMenuAndGetStatusFromUser()
        {
            string input;

            Console.WriteLine("Choose a status:");
            Console.WriteLine("================\n");
            printOrderStatuses();
            Console.WriteLine("Enter the corresponding number: ");
            input = Console.ReadLine();

            return input;
        }

        private static void printOrderStatuses()
        {
            for (int i = 1; i <= Enum.GetNames(typeof(eOrderStatus)).Length; i++)
            {
                Console.WriteLine($"{i}. {Enum.GetName(typeof(eOrderStatus), i)}");
            }
        }

        private void DisplayVehiclesByStatus(eOrderStatus status)
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

        private static string askLicenseNumberFromUser()
        {
            Console.WriteLine("Please enter license number:");
            return Console.ReadLine();
        }

        private Order getOrderFromUserByLicenseNumber()
        {
            string licenseNumber = askLicenseNumberFromUser();
            Order order = m_Garage.GetOrderByLicenseNumber(licenseNumber);

            while (order == null)
            {
                Console.WriteLine("Couldn't find this license number! Please try again.");
                licenseNumber = askLicenseNumberFromUser();
                order = m_Garage.GetOrderByLicenseNumber(licenseNumber);
            }

            return order;
        }

        private void ChangeVehicleStatus()
        {
            if (m_Garage.IsEmpty())
            {
                Console.WriteLine("There is no vehicle in the Garage!");
            }
            else
            {
                Order order = getOrderFromUserByLicenseNumber();

                order.Status = getNewStatusFromUser();
            }
        }

        private eOrderStatus getNewStatusFromUser()
        {
            string input;
            int choice;

            Console.WriteLine("Choose a new status:");
            printOrderStatuses();
            input = Console.ReadLine();
            while (!int.TryParse(input, out choice) || !Enum.IsDefined(typeof(eOrderStatus), choice))
            {
                Console.WriteLine("Invalid input! Please try again!");
                input = Console.ReadLine();
            }
            
            return (eOrderStatus)choice;
        }

        private void AddAirToWheels()
        {
            string licenseNumber = askLicenseNumberFromUser();

            Console.WriteLine("Inflating license number: {0} wheels to max.", licenseNumber);
            m_Garage.InflateAllWheelsToMax(licenseNumber);
        }

        private void AddFuel()
        {
            Order order = getOrderFromUserByLicenseNumber();

            if (!order.Vehicle.IsElectric())
            {
                string input;

                Console.WriteLine("Please enter ");
            }
            else
            {
                Console.WriteLine("Error! This vehicle has an electric engine!");
            }


        }

        public static void printFuelTypes()
        {
            foreach(string fuelType in Enum.GetNames(typeof(eFuelType)))
            {
                Console.WriteLine($"{(int)Enum.Parse(typeof(eFuelType), fuelType)}. {fuelType}");
            }
        }

        private void ChargeBattery()
        {
            Order order = getOrderFromUserByLicenseNumber();

            if (order.Vehicle.IsElectric())
            {
                string input;

                Console.WriteLine("Please enter how many minutes to add");
                input = Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Error! This vehicle has a fuel engine!");
            }
        }

        private void DisplayOrder()
        {
            Console.WriteLine("Display Order:");
            Order order = getOrderFromUserByLicenseNumber();
            Console.WriteLine(order.ToString());
        }

        private void printCars()
        {
            Console.WriteLine("Existing Cars in the Garage");
        }
    }
}
