using System;
namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private string m_ManufacturerName;
        private float m_CurrentAirPressure;
        private float m_MaxAirPressure;

        public Wheel(float i_MaxAirPressure)
        {
            m_ManufacturerName = null;
            m_CurrentAirPressure = 0;
            MaxAirPressure = i_MaxAirPressure;
        }

        internal float CurrentAirPressure
        {
            get 
            { 
                return m_CurrentAirPressure; 
            }
            private set
            {
                if (value <= m_MaxAirPressure && value >= 0)
                {
                    m_CurrentAirPressure = value;
                }
                else
                {
                    ValueOutOfRangeException ex = new ValueOutOfRangeException(m_MaxAirPressure, 0);
                }
            }
        }

        internal float MaxAirPressure
        {
            get
            {
                return m_MaxAirPressure;
            }

            set
            {
                if (value > 0)
                {
                    m_MaxAirPressure = value;
                }
                else
                {
                    throw new ValueOutOfRangeException(null, 0);
                }
            }
        }

        internal string ManufacturerName
        {
            get
            {
                return m_ManufacturerName;
            }

            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    m_ManufacturerName = value;
                }
                else
                {
                    throw new FormatException();
                }
            }
        }

        internal void AddAir(float i_AirToAdd)
        {
            float newAirPressure = i_AirToAdd + m_CurrentAirPressure;

            if (newAirPressure <= m_MaxAirPressure && newAirPressure >= 0)
            {
                m_CurrentAirPressure = newAirPressure;
            }
            else
            {
                throw new ValueOutOfRangeException(m_MaxAirPressure, 0);
            }
        }

        public void SetAttributes(string i_ManufacturerName, string i_CurrentAirPressure)
        {
            ManufacturerName = i_ManufacturerName;
            m_CurrentAirPressure = float.Parse(i_CurrentAirPressure);
        }

        public override string ToString()
        {
            return string.Format(
    @"Manufacturer Name: {0}
Current Air Pressure: {1}
Max Air Pressure: {2}
", m_ManufacturerName, m_CurrentAirPressure, m_MaxAirPressure);
        }
    }
}