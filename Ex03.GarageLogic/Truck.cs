using System;
using System.Text;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private const int k_NumOfWheels = 14;
        private const float k_MaxWheelAirPressure = 26f;
        internal const float k_MaxFuelTank = 135f;
        internal const eFuelType k_eFuelType = eFuelType.Soler;
        private const int k_NumOfChangeableAttributes = 2;
        private bool m_IsDangerousMaterials;
        private float m_CargoVolume;

        public Truck(Engine i_Engine) : base(i_Engine)
        {
            m_IsDangerousMaterials = false;
            m_CargoVolume = 0;
            base.m_Wheels = CreateWheelsList(k_NumOfWheels, k_MaxWheelAirPressure);
        }

        public bool IsDangerousMaterials
        {
            get 
            { 
                return m_IsDangerousMaterials; 
            }

            set 
            { 
                m_IsDangerousMaterials = value; 
            }
        }

        public float CargoVolume
        {
            get 
            { 
                return m_CargoVolume; 
            }

            set 
            {
                if (value >= 0)
                {
                    m_CargoVolume = value;
                }
                else
                {
                    throw new ValueOutOfRangeException(null, 0);
                }
            }
        }

        public override string[] GetUniqueAttributes()
        {
            return new string[] { "Is Containing Dangerous Materials", "Cargo Volume" };
        }

        public override void SetUniqueAttributes(string[] i_Attributes)
        {
            bool isDangerousValidAnswer = i_Attributes[0].ToLower() == "yes" || i_Attributes[0].ToLower() == "no";

            ThrowExceptionIfNumOfGivenParametersIsDifferentFromExpected(k_NumOfChangeableAttributes, i_Attributes.Length);
            if (isDangerousValidAnswer && float.TryParse(i_Attributes[1], out float volume))
            {
                IsDangerousMaterials = isDangerousValidAnswer;
                CargoVolume = volume;
            }
            else
            {
                throw new FormatException();
            }
        }

        public override string ToString()
        { 
           StringBuilder res = new StringBuilder();

            res.AppendLine(base.ToString());
            res.AppendLine(string.Format(
@"{0} Dangerous materials.
Cargo Voulme: {1}",
                m_IsDangerousMaterials ? "Has" : "Doesn't has", m_CargoVolume));
         
            return res.ToString();
        }
    }
}
