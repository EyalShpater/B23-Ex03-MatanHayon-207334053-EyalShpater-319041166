using System;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Car : Vehicle
    {
        internal const eFuelType k_FuelType = eFuelType.Octan95;
        internal const float k_MaxFuelTank = 46f;
        internal const float k_MaxBatterySize = 5.2f;
        private const int k_NumOfWheels = 5;
        private const float k_MaxWheelAirPressure = 33;
        private const int k_MinNumOfDoors = 2;
        private const int k_MaxNumOfDoors = 5;
        private const int k_NumOfAttributes = 2;
        private eColor m_Color;
        private int m_NumOfDoors;

        public Car(Engine i_Engine, string i_LicenseNumber) : base(i_Engine, i_LicenseNumber)
        {
            m_Color = eColor.White;
            m_NumOfDoors = 0;
            m_Wheels = CreateWheelsList(k_NumOfWheels, k_MaxWheelAirPressure);
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
                    string message = $"Number of doors should be between {k_MinNumOfDoors}-{k_MaxNumOfDoors}";
                    throw new ValueOutOfRangeException(k_MaxNumOfDoors, k_MinNumOfDoors, message);
                }
            }
        }

        public override string[] GetUniqueAttributes()
        {
            return new string[] { "Color", "Number Of Doors" };
        }

        public override string ToString()
        {
            return string.Format(@"Car
===
{0}
Color: {1}
Number of doors: {2}
", base.ToString(), Color, NumOfDoors);
        }

        internal override void SetUniqueAttributes(string[] i_Attributes)
        {
            int numOfDoors;
            eColor color;

            ThrowExceptionIfNumOfGivenParametersIsDifferentFromExpected(k_NumOfAttributes, i_Attributes.Length);
            if(!eColor.TryParse(i_Attributes[0], out color))
            {
                string[] colors = Enum.GetNames(typeof(eColor));
                string message = $"Invalid color. Available colors: {string.Join(", ", colors)}";

                throw new FormatException(message);
            }
            else if(!int.TryParse(i_Attributes[1], out numOfDoors))
            {
                string message = "Number of doors should be decimal digits only";

                throw new FormatException(message);
            }
            else
            {
                Color = color;
                NumOfDoors = numOfDoors;
            }
        }
    }
}