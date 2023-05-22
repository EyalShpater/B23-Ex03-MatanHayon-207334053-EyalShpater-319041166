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

        public Vehicle GetVehicleByLicenseNumber(string i_LicenseNumber)
        {
            Vehicle vehicle = null;
            if (m_Orders.ContainsKey(i_LicenseNumber))
            {
                vehicle = m_Orders[i_LicenseNumber].Vehicle;
            }

            return vehicle;
        }

        public Vehicle CreateNewVehicle(eVehicleType i_Etype)
        {
            Vehicle newVehicle = VehicleFactory.CreateVehicle(i_Etype);

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

        public void ChangeVehicleStatus(string i_LicenseNumber, eStatus i_Status)
        {
            if (m_Orders.ContainsKey(i_LicenseNumber))
            {
                m_Orders[i_LicenseNumber].Status = i_Status;
            }
            else
            {
                //throw exception
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
                //throw exception
            }
        }

        public void AddFuel(string i_LicenseNumber, eFuelType i_FuelType, float i_Amount)
        {
            
        }

        public void ChargeVehicle(string i_LicenseNumber, float i_Level)
        {
            
        }

        public string GetOrderDataByLicenseNumber(string i_LicenseNumber)
        {
            if (m_Orders.ContainsKey(i_LicenseNumber))
            {
                return m_Orders[i_LicenseNumber].ToString();
            }
            else
            {
                return null; //throw exception
            }
        }

    }
}
