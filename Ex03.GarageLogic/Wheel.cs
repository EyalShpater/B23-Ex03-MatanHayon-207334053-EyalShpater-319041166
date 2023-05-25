using System;
namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private string m_ManufacturerName;
        private float m_CurrentAirPressure;
        private readonly float r_MaxAirPressure;

        internal Wheel(float i_MaxAirPressure)
        {
            if (i_MaxAirPressure > 0)
            {
                r_MaxAirPressure = i_MaxAirPressure;
            }
            else
            {
                throw new ValueOutOfRangeException(null, 0);
            }

            m_ManufacturerName = null;
            m_CurrentAirPressure = 0;
        }

        public override string ToString()
        {
            return string.Format(@"Wheel
=====
Manufacturer Name: {0}
Current Air Pressure: {1}
Max Air Pressure: {2}
", m_ManufacturerName, m_CurrentAirPressure, r_MaxAirPressure);
        }

        internal float CurrentAirPressure
        {
            get 
            { 
                return m_CurrentAirPressure; 
            }
            private set
            {
                if (value <= r_MaxAirPressure && value >= 0)
                {
                    m_CurrentAirPressure = value;
                }
                else
                {
                    ValueOutOfRangeException ex = new ValueOutOfRangeException(r_MaxAirPressure, 0);
                }
            }
        }

        internal float MaxAirPressure
        {
            get
            {
                return r_MaxAirPressure;
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

            if (newAirPressure <= r_MaxAirPressure && newAirPressure >= 0)
            {
                m_CurrentAirPressure = newAirPressure;
            }
            else
            {
                throw new ValueOutOfRangeException(r_MaxAirPressure, 0);
            }
        }

        internal void SetAttributes(string i_ManufacturerName, string i_CurrentAirPressure)
        {
            ManufacturerName = i_ManufacturerName;
            m_CurrentAirPressure = float.Parse(i_CurrentAirPressure);
        }
    }
}