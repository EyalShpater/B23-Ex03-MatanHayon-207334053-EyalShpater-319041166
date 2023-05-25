using System;

namespace Ex03.GarageLogic
{
    public class Order
    {
        private const int k_PhoneNumberLength = 10;
        private Vehicle m_Vehicle;
        private string m_CustomerName;
        private string m_PhoneNumber;
        private eOrderStatus m_Status;

        public Order(Vehicle i_Vehicle, string i_CustomerName, string i_PhoneNumber)
        {
            Vehicle = i_Vehicle;
            CustomerName = i_CustomerName;
            PhoneNumber = i_PhoneNumber;
            m_Status = eOrderStatus.InRepair;
        }

        public Vehicle Vehicle
        {
            get 
            { 
                return m_Vehicle; 
            }

            internal set 
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

            internal set 
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

            internal set 
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

        public eOrderStatus Status
        {
            get 
            { 
                return m_Status; 
            }

            internal set 
            { 
                m_Status = value; 
            }
        }

        public override string ToString()
        {
            return string.Format(@"
Customer Name: {0}
Phone Number: {1}
Status: {2}
Vehicle Details:

{3}", m_CustomerName, m_PhoneNumber, m_Status.ToString(), Vehicle.ToString());
        }

        public override int GetHashCode()
        {
            return m_Vehicle.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            bool isEqual = false;

            if (obj is Order order)
            {
                isEqual = order.GetHashCode() == this.GetHashCode();
            }

            return isEqual;
        }
    }
}
