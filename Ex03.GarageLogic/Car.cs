using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        private eColor m_Color;
        private int m_NumOfDoors;

        public eColor Color
        {
            get { return m_Color; }
            set { m_Color = value; }
        }

        public int NumOfDoors
        {
            get { return m_NumOfDoors; }
            set { m_NumOfDoors = value; }
        }

        public Car(bool i_IsElectric) : base(i_IsElectric)
        {
            m_Color = 0;
            m_NumOfDoors = 0;
        }

        public override string[] GetUniqueAttributes()
        {
            return new string[] { "Color", "NumOfDoors" };
        }

        public override void SetUniqueAttributes(string[] attributes)
        {
            if (attributes.Length != 2) //needs to be updates check input
            {
                throw new ArgumentException("Invalid number of attributes.");
            }

            Color = (eColor)Enum.Parse(typeof(eColor), attributes[0]);
            NumOfDoors = int.Parse(attributes[1]);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Vehicle Type: Car");
            sb.AppendLine(base.ToString()); // Include the base class (Vehicle) details
            sb.AppendFormat("Color: {0}{1}", Color);
            sb.AppendFormat("Number of Doors: {0}{1}", NumOfDoors);

            return sb.ToString();
        }

    }
}
