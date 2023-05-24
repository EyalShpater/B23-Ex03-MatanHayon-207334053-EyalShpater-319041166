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
        private const string k_EmptyGarageMessege = "There are no vehicles in the garage!";
        private Garage m_Garage;
        private const string k_TitlesChar = "-";

        /******* User Functions ********/

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
                int input = getIntFromUser();
                switch (input)
                {
                    case (int)eMenuOptions.AddVehicle:
                        addVehicle();
                        break;
                    case (int)eMenuOptions.DisplayGarageVehicles:
                        showVehiclesByStatusMenu();
                        break;
                    case (int)eMenuOptions.ChangeVehicleStatus:
                        changeVehicleStatus();
                        break;
                    case (int)eMenuOptions.AddAirToWheels:
                        addAirToWheels();
                        break;
                    case (int)eMenuOptions.AddFuel:
                        addFuel();
                        break;
                    case (int)eMenuOptions.ChargeBattery:
                        chargeBattery();
                        break;
                    case (int)eMenuOptions.DisplayOrder:
                        displayOrder();
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

        /******* menu Functions ********/

        private void addVehicle()
        {
            printMessageAsTitle("Add Vehicle");
            try
            {
                string licenseNumber = getLicenseNumberFromUser();
                Order order = m_Garage.GetOrderByLicenseNumber(licenseNumber);

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
            catch(Exception i_Exception)
            {
                Console.WriteLine(i_Exception.Message);
            }
            
        }
        
        private void showVehiclesByStatusMenu()
        {
            int userInput;
            bool isValidInput = false;
            string input;

            printMessageAsTitle("Show Vehicles By Status");
            while (!isValidInput)
            {
                input = printVehicleOrderStatusMenuAndGetStatusFromUser();
                if (int.TryParse(input, out userInput) && Enum.IsDefined(typeof(eOrderStatus), userInput))
                {
                    isValidInput = true;
                    eOrderStatus status = (eOrderStatus)(userInput);
                    displayVehiclesByStatus(status);
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }
        }

        private void changeVehicleStatus()
        {
            printMessageAsTitle("Change Vehicle Status");
            if (m_Garage.IsEmpty())
            {
                Console.WriteLine(k_EmptyGarageMessege);
            }
            else
            {
                Order order = getOrderFromUserByLicenseNumber();

                if (order != null)
                {
                    order.Status = getNewOrderStatusFromUser();
                }
                else
                {
                    Console.WriteLine("Couldn't find the vehicle!");
                }
            }
        }

        private void addAirToWheels()
        {
            printMessageAsTitle("Add Air To Wheels");
            if (m_Garage.IsEmpty())
            {
                Console.WriteLine(k_EmptyGarageMessege);
            }
            else
            {
                try
                {
                    string licenseNumber = getLicenseNumberFromUser();

                    m_Garage.InflateAllWheelsToMax(licenseNumber);
                    Console.WriteLine("Inflating vehicle license number: {0} wheels to max.", licenseNumber);
                }
                catch (ArgumentException i_Exception)
                {
                    Console.WriteLine(i_Exception.Message);
                }
                catch
                {
                    Console.WriteLine("General error occured");
                }
            }
        }

        private void addFuel()
        {
            printMessageAsTitle("Add fuel");
            if (m_Garage.IsEmpty())
            {
                Console.WriteLine(k_EmptyGarageMessege);
            }
            else
            {
                try
                {
                    string licenseNumber = getLicenseNumberFromUser();
                    float fuelAmmountToAdd = getEnergyAmountToAddFromUser();
                    eFuelType fuelType = getFuelTypeFromUser();

                    m_Garage.AddFuel(licenseNumber, fuelType, fuelAmmountToAdd);
                }
                catch (ValueOutOfRangeException ex)
                {
                    Console.WriteLine($"Fuel tank cannot contain more fuel than {ex.MaxValue}!");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("General error occured!");
                }
            }
        }

        private void chargeBattery()
        {
            printMessageAsTitle("Charge Battery");
            if (m_Garage.IsEmpty())
            {
                Console.WriteLine(k_EmptyGarageMessege);
            }
            else
            {
                try
                {
                    string licenseNumber = getLicenseNumberFromUser();
                    float minutesToAdd = getEnergyAmountToAddFromUser();

                    m_Garage.ChargeVehicle(licenseNumber, minutesToAdd);
                }
                catch (ValueOutOfRangeException ex)
                {
                    Console.WriteLine($"Fuel tank cannot contain more fuel than {ex.MaxValue}!");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("General error occured!");
                }
            }
        }

        private void displayOrder()
        {
            printMessageAsTitle("Display Order");
            if (!m_Garage.IsEmpty())
            {
                Order order = getOrderFromUserByLicenseNumber();

                Console.WriteLine(order != null ? order.ToString() : "Couldn't find this license number!");
            }
            else
            {
                Console.WriteLine(k_EmptyGarageMessege);
            }
        }

        /******* Utility Printers Functions ********/

        private static void printMenu()
        {
            printMessageAsTitle("Welcome To Our Majestic Garage!");
            Console.WriteLine($@"Enter a number to choose an option:
{(int)eMenuOptions.AddVehicle}. Add vehicle
{(int)eMenuOptions.DisplayGarageVehicles}. Show vehicles in garage
{(int)eMenuOptions.ChangeVehicleStatus}. Change vehicle status
{(int)eMenuOptions.AddAirToWheels}. Add air to wheels
{(int)eMenuOptions.AddFuel}. Add fuel
{(int)eMenuOptions.ChargeBattery}. Charge battery
{(int)eMenuOptions.DisplayOrder}. Display order
{(int)eMenuOptions.Exit}. Exit");
        }

        private static void printFuelTypes()
        {
            foreach (string fuelType in Enum.GetNames(typeof(eFuelType)))
            {
                Console.WriteLine($"{(int)Enum.Parse(typeof(eFuelType), fuelType)}. {fuelType}");
            }
        }

        private void printVehiclesTypes()
        {
            string[] vehiclesTypes = VehicleFactory.GetVehiclesTypes();

            for (int i = 0; i < vehiclesTypes.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {vehiclesTypes[i]}");
            }
        }

        private static void printOrderStatuses()
        {
            for (int i = 1; i <= Enum.GetNames(typeof(eOrderStatus)).Length; i++)
            {
                Console.WriteLine($"{i}. {Enum.GetName(typeof(eOrderStatus), i)}");
            }
        }

        private void displayVehiclesByStatus(eOrderStatus status)
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

        private string printVehicleOrderStatusMenuAndGetStatusFromUser()
        {
            string input;

            printOrderStatuses();
            Console.WriteLine("Enter the corresponding number: ");
            input = Console.ReadLine();

            return input;
        }

        private static void printMessageAsTitle(string i_FunctionName)
        {
            printLineOfSameChars(k_TitlesChar,  i_FunctionName.Length);
            Console.WriteLine(i_FunctionName);
            printLineOfSameChars(k_TitlesChar, i_FunctionName.Length);

        }

        private static void printLineOfSameChars(string i_WantedChar, int i_NumOfPrintsInLine)
        {
            for (int i = 0; i < i_NumOfPrintsInLine; i++)
            {
                Console.Write(i_WantedChar);
            }
            Console.WriteLine();
        }

        /******* Utility "Get Data From User" Functions ********/

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
                Console.WriteLine("Enter vehicle type:");
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

        private Order getOrderFromUserByLicenseNumber()
        {
            string licenseNumber = getLicenseNumberFromUser();
            Order order = m_Garage.GetOrderByLicenseNumber(licenseNumber);

            while (order == null)
            {
                Console.WriteLine("Couldn't find this license number! Please try again.");
                licenseNumber = getLicenseNumberFromUser();
                order = m_Garage.GetOrderByLicenseNumber(licenseNumber);
            }

            return order;
        }

        private static string getLicenseNumberFromUser()
        {
            Console.WriteLine("Please enter license number:");
            return Console.ReadLine();
        }

        private eOrderStatus getNewOrderStatusFromUser()
        {
            int choice;

            Console.WriteLine("Choose a new status:");
            printOrderStatuses();
            choice = getIntFromUser();
            while (!Enum.IsDefined(typeof(eOrderStatus), choice))
            {
                Console.WriteLine("Invalid input! Please try again!");
                choice = getIntFromUser();
            }

            return (eOrderStatus)choice;
        }

        private static float getEnergyAmountToAddFromUser()
        {
            float res;
            string input;

            Console.WriteLine("Please enter wanted amount to add:");
            input = Console.ReadLine();
            while (!float.TryParse(input, out res))
            {
                Console.WriteLine("Invalid Input! Please try again!");
                input = Console.ReadLine();
            }

            return res;
        }

        private static eFuelType getFuelTypeFromUser()
        {
            int choice;

            Console.WriteLine("Please enter the wanted fuel type:");
            printFuelTypes();
            choice = getIntFromUser();
            while (Enum.IsDefined(typeof(eFuelType), choice))
            {
                Console.WriteLine("Invalid innput! Please try Again");
                choice = getIntFromUser();
            }

            return (eFuelType)choice;
        }

        private static int getIntFromUser()
        {
            string input = Console.ReadLine();
            int res;

            while(!int.TryParse(input, out res))
            {
                Console.WriteLine("Invalid value! Please enter an integer.");
                input = Console.ReadLine();
            }

            return res;
        }

        /******* Validators Functions ********/

        private bool isValidVehicleTypeChoise(string i_Choice, ref int io_SelectedIndex, int i_NumOfTypes)
        {
            return int.TryParse(i_Choice, out io_SelectedIndex) &&
                    isValidValueInRange(io_SelectedIndex, i_NumOfTypes, 1);
        }

        private bool isValidValueInRange(int i_Value, int i_Max, int i_Min)
        {
            return i_Value <= i_Max && i_Value >= i_Min;
        }


    }
}
