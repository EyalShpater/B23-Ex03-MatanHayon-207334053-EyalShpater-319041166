using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private Dictionary<string, Order> m_Orders;

        public Garage()
        {
            m_Orders = new Dictionary<string, Order>();
        }

        public void SetNewVehicleAttributes(string i_LicenseNumber, string[] i_UniquqAttributes, string[] i_GeneralAttributes)
        {
            if (m_Orders.ContainsKey(i_LicenseNumber))
            {
                m_Orders[i_LicenseNumber].Vehicle.SetGeneralAttributes(i_GeneralAttributes);
                m_Orders[i_LicenseNumber].Vehicle.SetUniqueAttributes(i_UniquqAttributes);
            }
            else
            {
                throw new ArgumentException("Vehicle is not found!");
            }
        }

        public List<string> GetLicenseNumbersByStatus(string i_Status)
        {
            List<string> licenseNumbers = new List<string>();

            foreach (Order order in m_Orders.Values)
            {
                if (order.Status.ToString().Equals(i_Status)) 
                {
                    licenseNumbers.Add(order.Vehicle.LicenseNumber);
                }
            }

            return licenseNumbers;
        } // debug

        public void ChangeVehicleStatus(string i_LicenseNumber, eOrderStatus i_Status)
        {
            if (m_Orders.ContainsKey(i_LicenseNumber))
            {
                m_Orders[i_LicenseNumber].Status = i_Status;
            }
            else
            {
                throw new ArgumentException("Vehicle is not found!");
            }
        }

        public void InflateAllWheelsToMax(string i_LicenseNumber)
        {
            if (m_Orders.ContainsKey(i_LicenseNumber))
            {
                m_Orders[i_LicenseNumber].Vehicle.InflateAllWheels();
            }
            else
            {
                throw new ArgumentException("Vehicle is not found!");
            }
        }

        public void AddFuel(string i_LicenseNumber, eFuelType i_FuelType, float i_Ammount)
        {
            Order order = GetOrderByLicenseNumber(i_LicenseNumber);

            if (order != null)
            {
                order.Vehicle.AddEnergy(i_Ammount, i_FuelType);
            }
            else
            {
                throw new ArgumentException("Vehicle is not found!");
            }
        }

        public void ChargeVehicle(string i_LicenseNumber, float i_Ammount)
        {
            Order order = GetOrderByLicenseNumber(i_LicenseNumber);

            if (order != null)
            {
                order.Vehicle.AddEnergy(i_Ammount);
            }
            else
            {
                throw new ArgumentException("Vehicle is not found!");
            }
        }

        public void AddNewOrder(Order i_Order)
        {
            if (!m_Orders.ContainsKey(i_Order.Vehicle.LicenseNumber))
            {
                m_Orders.Add(i_Order.Vehicle.LicenseNumber, i_Order);
            }
            else
            {
                throw new ArgumentException("Vehicle is already exist");
            }
        }

        public string[] GetVehiclesTypes()
        {
            return VehicleFactory.GetVehiclesTypes();
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

        public bool IsEmpty()
        {
            return m_Orders.Count == 0;
        }
    }
}
