using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        private const int k_NumOfWheels = 5;
        private const float k_MaxWheelAirPressure = 33;
        internal const eFuelType k_FuelType = eFuelType.Octan95;
        internal const float k_MaxFuelTank = 46f;
        internal const float k_MaxBatterySize = 5.2f;
        private const int k_MinNumOfDoors = 2;
        private const int k_MaxNumOfDoors = 5;
        private const int k_NumOfAttributes = 2;
        private eColor m_Color;
        private int m_NumOfDoors;

        public Car(Engine i_Engine, string i_LicenseNumber) : base(i_Engine, i_LicenseNumber)
        {
            m_Color = eColor.White;
            m_NumOfDoors = 0;
            base.m_Wheels = CreateWheelsList(k_NumOfWheels, k_MaxWheelAirPressure);
        }

        public eColor Color
        {
            get 
            { 
                return m_Color; 
            }

            internal set 
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

            internal set 
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
            return new string[] { "Color", "Number Of Doors" };
        }

        internal override void SetUniqueAttributes(string[] i_Attributes)
        {
            ThrowExceptionIfNumOfGivenParametersIsDifferentFromExpected(k_NumOfAttributes, i_Attributes.Length);

            if (eColor.TryParse(i_Attributes[0], out eColor color) && int.TryParse(i_Attributes[1], out int numOfDoors))
            {
                Color = color;
                NumOfDoors = numOfDoors; 
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
            sb.AppendLine(base.ToString()); 
            sb.AppendFormat("Color: {0}", Color);
            sb.AppendFormat("Number of Doors: {0}", NumOfDoors);

            return sb.ToString();
        }
    }
}
