using System;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        private float? m_MaxValue;
        private float? m_MinValue;

        public ValueOutOfRangeException(float? i_MaxValue, float? i_MinValue) 
        { 
            m_MaxValue = i_MaxValue;
            m_MinValue = i_MinValue;
        }

        public float MaxValue 
        { 
            get 
            { 
                return m_MaxValue.GetValueOrDefault();
            } 
        }

        public float MinValue
        {
            get
            {
                return m_MinValue.GetValueOrDefault();
            }
        }
    }
}
