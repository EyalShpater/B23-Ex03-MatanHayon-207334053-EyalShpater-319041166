using System;

namespace Ex03.GarageLogic
{
    public class Order
    {
        private const int k_PhoneNumberLength = 10;
        private Vehicle m_Vehicle;
        private string m_CustomerName;
        private string m_PhoneNumber;
        private eStatus m_Status;

        public Order()
        {
            m_Vehicle = null;
            m_CustomerName = null;
            m_PhoneNumber = null;
            m_Status = 0;
        }

        public Vehicle Vehicle
        {
            get 
            { 
                return m_Vehicle; 
            }

            set 
            {
                if (value != null)
                {
                    m_Vehicle = value;
                }
                else
                {
                    throw new FormatException();
                }
            }
        }

        public string CustomerName
        {
            get 
            { 
                return m_CustomerName; 
            }
            set 
            {
                if (!string.IsNullOrEmpty(value))
                {
                    m_CustomerName = value;
                }
                else 
                { 
                    throw new FormatException(); 
                }
            }
        }

        public string PhoneNumber
        {
            get 
            {
                return m_PhoneNumber; 
            }

            set 
            {
                if (!string.IsNullOrEmpty(value) && int.TryParse(value, out int unusedDummyParameter))
                {
                    if (value.Length == k_PhoneNumberLength)
                    {
                        m_PhoneNumber = value;
                    }
                    else
                    {
                        throw new ValueOutOfRangeException(k_PhoneNumberLength, k_PhoneNumberLength);
                    }
                }
                else
                {
                    throw new FormatException();
                }
            }
        }

        public eStatus Status
        {
            get 
            { 
                return m_Status; 
            }

            set 
            { 
                m_Status = value; 
            }
        }

        public override string ToString()
        {
            return string.Format(
@"{0}
Customer Name: {1}
Phone Nuner: {2}
Status: {3}
", m_Vehicle.ToString(), m_CustomerName, m_PhoneNumber, m_Status.ToString());
        }
    }
}
