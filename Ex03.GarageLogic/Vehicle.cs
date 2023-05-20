using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        protected string m_Model;
        protected string m_LicenseNumber;
        protected float m_EnergyLevel;
        List<Wheel> m_Wheels;
        protected readonly Engine r_Engine;

        public Vehicle(bool i_IsElectricEngine)
        {
            if (i_IsElectricEngine)
            {
                r_Engine = new ElectricEngine();
            }
            else
            {
                r_Engine = new FuelEngine();
            }

            m_Model = null;
            m_LicenseNumber = null;
            m_EnergyLevel = 0;
            m_Wheels = null;
        }

        public string LicenseNumber
        {
            get
            {
                return m_LicenseNumber;
            }
        }

        public float EnergyLevel
        {
            get 
            { 
                return m_EnergyLevel; 
            }
        }

        internal void AddEnergy(float i_EnergyToAdd)
        {
            if (r_Engine is ElectricEngine engine)
            {
                engine.AddEnergy(i_EnergyToAdd);
            }
            else
            {
                throw new ArgumentException();
            }
        }

        internal void AddEnergy(float i_EnergyToAdd, eFuelType i_FuelType)
        {
            if (r_Engine is FuelEngine engine)
            {
                engine.AddFuel(i_EnergyToAdd, i_FuelType);
            }
            else 
            { 
                throw new ArgumentException(); 
            }
        }

        internal void InflateAllWheels()
        {
            foreach (Wheel wheel in m_Wheels) 
            {
                wheel.AddAir(wheel.MaxAirPressure - wheel.CurrentAirPressure);
            }
        }

        public abstract string[] GetUniqueAttributes();

        public abstract void SetUniqueAttributes(string[] i_Features);

        private void updateEnergyPercentage()
        {
            m_EnergyLevel = (r_Engine.CurrentEnergyLevel / r_Engine.MaxCapacity) * 100;
        }
    }
}