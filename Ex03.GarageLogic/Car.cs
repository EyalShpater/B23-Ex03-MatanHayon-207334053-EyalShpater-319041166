using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        private const int k_MinNumOfDoors = 2;
        private const int k_MaxNumOfDoors = 5;
        private const int k_NumOfAttributes = 3;
        private eColor m_Color;
        private int m_NumOfDoors;

        public Car(Engine i_Engine, List<Wheel> i_Wheels) : base(i_Engine, i_Wheels)
        {
            m_Color = eColor.White;
            m_NumOfDoors = 0;
        }



        public eColor Color
        {
            get 
            { 
                return m_Color; 
            }

            set 
            { 
                m_Color = value; 
            }
        }

        public int NumOfDoors
        {
            get 
            { 
                return m_NumOfDoors; 
            }

            set 
            {
                if (value >= k_MinNumOfDoors && value <= k_MaxNumOfDoors)
                {
                    m_NumOfDoors = value;
                }
                else
                {
                    throw new ValueOutOfRangeException(k_MaxNumOfDoors, k_MinNumOfDoors);
                }
            }
        }

       
        public override string[] GetUniqueAttributes()
        {
            return new string[] { "Colour", "Number Of Doors" };
        }

        public override void SetUniqueAttributes(string[] i_Attributes)
        {
            ThrowExceptionIfNumOfGivenParametersIsDifferentFromExpected(k_NumOfAttributes, i_Attributes.Length);

            this.LicenseNumber = i_Attributes[0];

            if (eColor.TryParse(i_Attributes[1], out eColor color) && int.TryParse(i_Attributes[2], out int numOfDoors))
            {
                m_Color = color;
                m_NumOfDoors = numOfDoors; 
            }
            else
            {
                throw new FormatException();
            }
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
