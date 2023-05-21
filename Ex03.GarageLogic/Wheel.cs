﻿using System;
namespace Ex03.GarageLogic

{
    internal class Wheel
    {
        private string m_ManufacturerName;
        private float m_CurrentAirPressure;
        private float m_MaxAirPressure;

        internal float CurrentAirPressure
        {
            get 
            { 
                return m_CurrentAirPressure; 
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