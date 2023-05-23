using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ex03.GarageLogic;
namespace Ex03.ConsoleUI
{
    public class ConsoleUI
    {
        private Garage m_Garage;

        public ConsoleUI()
        {
            m_Garage = new Garage();
        }

        public void Run() // add enum
        {
            string input = null;

            while (input != "0") // input != QuitProgram (enum)
            {
                printMenu();
                input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        AddVehicle();
                        break;
                    case "2":
                        ShowVehiclesByStatusMenu();
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
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option.");
                        break;
                }
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


        private void AddVehicle()
        {
            Console.WriteLine("Enter license number:");
            string licenseNumber = Console.ReadLine();
            Order order = m_Garage.GetOrderByLicenseNumber(licenseNumber);
            if(order!=null) //change null to #define null NOTFOUND but i dont remember how
            {
                Console.WriteLine("Vehicle already in Garage.");
                Console.WriteLine("Changed Status to In-Repair");
                order.Status = eStatus.InRepair;
            }
            else
            {
                order = getOrderDataFromUser(licenseNumber);
            }
        }

        private Order getOrderDataFromUser(string i_LicenseNumber)
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
                getUniqueDataForVehicleFromUser(order,i_LicenseNumber);
                m_Garage.AddNewOrder(order);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred while getting order data: " + ex.Message);
            }

            return order;
        }

        private static void getUniqueDataForVehicleFromUser(Order order,string i_LicenseNumber)
        {
            Vehicle vehicle = order.Vehicle;
            string[] uniqueAttributes = vehicle.GetUniqueAttributes();
            string[] dataInputFromUser = new string[uniqueAttributes.Length + 1];

            dataInputFromUser[0] = i_LicenseNumber;
            Console.WriteLine("Enter Data for the next Attributes:");
            try
            {
                for (int index = 0; index < uniqueAttributes.Length; index++)
                {
                    Console.WriteLine(uniqueAttributes[index] + ":");
                    dataInputFromUser[index+1] = Console.ReadLine(); //first place in array is License number
                }
                getGeneralDataForVehicleFromUser(vehicle, i_LicenseNumber);
                vehicle.SetUniqueAttributes(dataInputFromUser);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred while getting unique data for vehicle: " + ex.Message);
            }
        }

        private static void getGeneralDataForVehicleFromUser(Vehicle vehicle,string i_LicenseNumber)
        {
            Console.WriteLine("Enter current energy ammount:");
            string currentEnergyAmmount = Console.ReadLine();
            Console.WriteLine("Enter wheels manufactorer:");
            string wheelsManufatorer = Console.ReadLine();
            Console.WriteLine("Enter wheels AirPressure");
            string wheelsAirPressure = Console.ReadLine();
            Console.WriteLine("Enter Car model:");
            string carModel = Console.ReadLine();

            vehicle.SetGeneralAttributes(i_LicenseNumber, currentEnergyAmmount, wheelsManufatorer, wheelsAirPressure, carModel);
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


        private void ShowVehiclesByStatusMenu()
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
