using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class Garage
    {
        private Dictionary<string, Order> m_Orders;

        public Vehicle GetVehicleByLicenseNumber(string i_LicenseNumber)
        {
        }

        public Vehicle CreateNewVehicle(eVehicleType i_Etype)
        {
        }

        public void SetNewVehicleAttributes(Vehicle i_Vehicle, string[] i_Attributes)
        {
        }

        public string[] GetLicenseNumbersByStatus(string i_Status)
        {
        }

        public void ChangeVehicleStatus(string i_LicenseNumber, eStatus status)
        {
        }

        public void InflateAllWheelsToMax(string i_LicenseNumber)
        {
        }

        public void AddFuel(string i_LicenseNumber, eFuelType i_FuelType, float i_Amount)
        {
        }

        public void ChargeVehicle(string i_LicenseNumber, float i_Level)
        {
        }

        public string[] GetOrderData()
        {
        }

    }
}
