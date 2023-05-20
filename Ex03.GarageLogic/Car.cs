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
    }
}
