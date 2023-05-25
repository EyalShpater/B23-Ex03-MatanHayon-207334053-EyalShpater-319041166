using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        protected string m_Model;
        protected string m_LicenseNumber;
        protected float m_EnergyLevel;
        protected List<Wheel> m_Wheels;
        protected Engine m_Engine;

        public Vehicle(Engine i_Engine, string i_LicenseNumber)
        {
            m_Engine = i_Engine;
            m_Model = null;
            m_LicenseNumber = i_LicenseNumber;
            m_EnergyLevel = 0;
            m_Wheels = null;
        }


        public string LicenseNumber
        {
            get
            {
                return m_LicenseNumber;
            }

            internal set
            {
                if (value.Length > 0)
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
                    throw new ValueOutOfRangeException(null, 1);
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
                    throw new ValueOutOfRangeException(null, 1);
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
                throw new ArgumentException("Cannot charge a fuel engine!");
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
                throw new ArgumentException("Cannot add fuel to an electric engine!");
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

        internal abstract void SetUniqueAttributes(string[] i_Features);

        private void updateEnergyPercentage()
        {
            m_EnergyLevel = (m_Engine.CurrentEnergyLevel / m_Engine.MaxCapacity) * 100;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat(@"Model: {0}
License Number: {1}
Energy Level: {2}%

Engine:
=======
{3}

All Wheels:
===========
{4}
", m_Model, m_LicenseNumber, m_EnergyLevel, m_Engine.ToString(), m_Wheels[0].ToString());

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

        public string[] GetGeneralAttributes()
        {
            return new string[] { "Current Energy Amount", "Wheels Manufactorer", "Current Wheels Air Pressure", "Vehicle Model" };
        }

        internal void SetGeneralAttributes(params string[] i_Attributes)
        {
            m_Engine.CurrentEnergyLevel = float.Parse(i_Attributes[0]);
            updateEnergyPercentage();
            setAllWheelsAttributes(i_Attributes[1], i_Attributes[2]);
            Model = i_Attributes[3];
        }

        private void setAllWheelsAttributes(string i_Manufactorer, string i_AirPressure)
        {
            foreach(Wheel wheel in m_Wheels)
            {
                wheel.SetAttributes(i_Manufactorer, i_AirPressure);
            }
        }

        protected List<Wheel> CreateWheelsList(int i_NumOfWheels, float i_MaxAirPressure)
        {
            List<Wheel> wheels = new List<Wheel>(i_NumOfWheels);

            for (int i = 0; i < i_NumOfWheels; i++)
            {
                wheels.Add(new Wheel(i_MaxAirPressure));
            }

            return wheels;
        }

        public bool IsElectric()
        {
            return m_Engine is ElectricEngine;
        }

        public override int GetHashCode()
        {
            return m_LicenseNumber.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            bool isEqual = false;

            if (obj is Vehicle vehicle)
            {
                isEqual = vehicle.GetHashCode() == this.GetHashCode();
            }

            return isEqual;
        }
    }
}