using System.Text;

namespace Ex03.GarageLogic
{
    internal class Order
    {
        private Vehicle m_Vehicle;
        private string m_CustomerName;
        private string m_PhoneNumber;
        private eStatus m_Status;

        public Vehicle Vehicle
        {
            get { return m_Vehicle; }
            set { m_Vehicle = value; }
        }

        public string CustomerName
        {
            get { return m_CustomerName; }
            set { m_CustomerName = value; }
        }

        public string PhoneNumber
        {
            get { return m_PhoneNumber; }
            set { m_PhoneNumber = value; }
        }

        public eStatus Status
        {
            get { return m_Status; }
            set { m_Status = value; }
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
