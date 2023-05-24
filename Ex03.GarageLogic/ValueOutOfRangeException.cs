using System;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        private float? m_MaxValue;
        private float? m_MinValue;


        public ValueOutOfRangeException(float? i_MaxValue, float? i_MinValue)
            : this(i_MaxValue, i_MinValue, "")
        {

        }
        
        public ValueOutOfRangeException(float? i_MaxValue, float? i_MinValue, string message)
            : base(message)
        {
            m_MaxValue = i_MaxValue;
            m_MinValue = i_MinValue;
        }

        public override string Message
        {
            get
            {
                string message = base.Message + "Value out of range.";

                if (m_MaxValue != null)
                {
                    message += $" Maximum value: {m_MaxValue}.";
                }

                if (m_MinValue != null)
                {
                    message += $" Minimum value: {m_MinValue}.";
                }

                return message;
            }
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
