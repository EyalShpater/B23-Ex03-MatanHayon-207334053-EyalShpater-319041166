using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private Dictionary<string, Order> m_Orders;

        public Garage()
        {
            m_Orders = new Dictionary<string, Order>();
        }

        public Order GetOrderByLicenseNumber(string i_LicenseNumber)
        {
            Order order = null;

            if (m_Orders.ContainsKey(i_LicenseNumber))
            {
                order = m_Orders[i_LicenseNumber];
            }

            return order;
        }

        public Vehicle CreateNewVehicle(int i_Type)
        {
            Vehicle newVehicle = VehicleFactory.CreateVehicle(i_Type);

            return newVehicle;
        }

        public void SetNewVehicleAttributes(Vehicle i_Vehicle, string[] i_Attributes)
        {
            i_Vehicle.SetUniqueAttributes(i_Attributes);
        }

        public List<string> GetLicenseNumbersByStatus(string i_Status)
        {
            List<string> licenseNumbers = new List<string>();

            foreach (Order order in m_Orders.Values)
            {
                if (order.Status.ToString().Equals(i_Status)) //debug
                {
                    licenseNumbers.Add(order.Vehicle.LicenseNumber);
                }
            }

            return licenseNumbers;
        }

        public bool ChangeVehicleStatus(string i_LicenseNumber, eOrderStatus i_Status)
        {
            bool isSucceed = false;

            if (m_Orders.ContainsKey(i_LicenseNumber))
            {
                m_Orders[i_LicenseNumber].Status = i_Status;
                isSucceed = true;
            }
            
            return isSucceed;
        }

        public bool InflateAllWheelsToMax(string i_LicenseNumber)
        {
            bool isSucceed = false;

            if (m_Orders.ContainsKey(i_LicenseNumber))
            {
                m_Orders[i_LicenseNumber].Vehicle.InflateAllWheels();
                isSucceed = true;
            }

            return isSucceed;
        }

        public bool AddFuel(string i_LicenseNumber, eFuelType i_FuelType, float i_Ammount)
        {
            bool isSucceed = false;
            Order order = GetOrderByLicenseNumber(i_LicenseNumber);

            if(order!=null)
            {
                order.Vehicle.AddEnergy(i_Ammount, i_FuelType);
                isSucceed = true;
            }

            return isSucceed;
        }

        public bool ChargeVehicle(string i_LicenseNumber, float i_Ammount)
        {
            bool isSucceed = false;
            Order order = GetOrderByLicenseNumber(i_LicenseNumber);

            if (order != null)
            {
                order.Vehicle.AddEnergy(i_Ammount);
                isSucceed = true;
            }

            return isSucceed;
        }

        public bool AddNewOrder(Order i_Order)
        {
            bool isSuccessful = false;

            if (!m_Orders.ContainsKey(i_Order.Vehicle.LicenseNumber))
            {
                m_Orders.Add(i_Order.Vehicle.LicenseNumber, i_Order);
                isSuccessful = true;
            }

            return isSuccessful;
        }

        public bool IsEmpty()
        {
            return m_Orders.Count == 0;
        }

    }
}
