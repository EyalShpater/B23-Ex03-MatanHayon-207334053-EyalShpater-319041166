using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        const int k_MaxLicenseLength = 8;
        const int k_MaxModelLength = 30;
        protected string m_Model;
        protected string m_LicenseNumber;
        protected float m_EnergyLevel;
        List<Wheel> m_Wheels;
        protected Engine m_Engine;

        public Vehicle(bool i_IsElectricEngine)
        {
            if (i_IsElectricEngine)
            {
                m_Engine = new ElectricEngine();
            }
            else
            {
                m_Engine = new FuelEngine();
            }

            m_Model = null;
            m_LicenseNumber = null;
            m_EnergyLevel = 0;
            m_Wheels = null;
        }
        
        public void setConstData(bool i_IsElectric, int i_NumOfWheels, float i_MaxAirPressure, float i_MaxEngineCapacity, eFuelType i_eFuelType)
        {   //without i_iselectirc?
            m_Engine.MaxCapacity = i_MaxEngineCapacity;
            if (!i_IsElectric && m_Engine is FuelEngine fuelEngine)
            {
                fuelEngine.FuelType = i_eFuelType;
            }

            m_Wheels = new List<Wheel>(i_NumOfWheels);
            foreach (Wheel wheel in m_Wheels)
            {
                wheel.MaxAirPressure = i_MaxAirPressure;
            }


        }


        public string LicenseNumber
        {
            get
            {
                return m_LicenseNumber;
            }
            set
            {
                if (value.Length <= k_MaxLicenseLength && value.Length > 0) 
                {
                    if (int.TryParse(value, out int dummyInt))
                    {
                        m_LicenseNumber = value;
                    }
                    else
                    {
                        throw new FormatException();
                    }
                }
                else
                {
                    throw new ValueOutOfRangeException(k_MaxLicenseLength, 1);
                }
            }
        }

        public float EnergyLevel
        {
            get 
            { 
                return m_EnergyLevel; 
            }
        }

        public string Model
        {
            get 
            { 
                return m_Model; 
            }
            private set
            {
                if (value.Length >= 1)
                {
                    m_Model = value; 
                }
                else
                {
                    throw new ValueOutOfRangeException(k_MaxModelLength, 1);
                }
            }
        }

        internal void AddEnergy(float i_EnergyToAdd)
        {
            if (m_Engine is ElectricEngine engine)
            {
                engine.Charge(i_EnergyToAdd);
            }
            else
            {
                throw new ArgumentException();
            }
        }

        internal void AddEnergy(float i_EnergyToAdd, eFuelType i_FuelType)
        {
            if (m_Engine is FuelEngine engine)
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

        public void SetWheelsAttributes(string i_ManufacturerName, float i_CurrentAirPressure, float i_MaxAirPressure)
        {
            foreach(Wheel wheel in m_Wheels)
            {
                wheel.ManufacturerName = i_ManufacturerName;
                wheel.MaxAirPressure = i_MaxAirPressure;
                wheel.AddAir(i_CurrentAirPressure);
            }
        }

        private void updateEnergyPercentage()
        {
            m_EnergyLevel = (m_Engine.CurrentEnergyLevel / m_Engine.MaxCapacity) * 100;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat(
        @"Model: {0}
License Number: {1}
Energy Level: {2}%
{3}
", m_Model, m_LicenseNumber, m_EnergyLevel, m_Engine.ToString());

            int wheelNumber = 0;
            foreach (Wheel wheel in m_Wheels)
            {
                wheelNumber++;
                sb.AppendFormat("Wheel number: {0}{1}{2}", wheelNumber, Environment.NewLine, wheel.ToString());
            }

            return sb.ToString();
        }

        protected void ThrowExceptionIfNumOfGivenParametersIsDifferentFromExpected(int i_Expected, int i_Actual)
        {
            if (i_Expected != i_Actual)
            {
                throw new ArgumentException("Invalid number of attributes.");
            }
        }
    }
}