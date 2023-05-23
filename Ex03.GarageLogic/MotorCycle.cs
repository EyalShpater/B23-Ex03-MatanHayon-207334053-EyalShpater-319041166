using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class MotorCycle : Vehicle
    {
        private const int k_NumOfAttributes = 2;
        private eLicenseType m_LicenseType;
        private int m_EngineVolume;

        public MotorCycle(Engine i_Engine, List<Wheel> i_Wheels) 
            : base(i_Engine, i_Wheels)
        {
            m_LicenseType = 0;
            m_EngineVolume = 0;
        }

        public eLicenseType LicenseType
        {
            get 
            { 
                return m_LicenseType; 
            }

            private set 
            { 
                m_LicenseType = value; 
            }
        }

        public int EngineVolume
        {
            get 
            { 
                return m_EngineVolume; 
            }

            private set
            {
                if (value > 0)
                {
                    m_EngineVolume = value;
                }
                else
                {
                    throw new ValueOutOfRangeException(null, 0);
                }
            }
        }

        public override string[] GetUniqueAttributes()
        {
            return new string[] { "LicensesType", "EngineVolume" };
        }

        public override void SetUniqueAttributes(string[] i_Attributes)
        {
            ThrowExceptionIfNumOfGivenParametersIsDifferentFromExpected(k_NumOfAttributes, i_Attributes.Length);
            if (eLicenseType.TryParse(i_Attributes[0], out eLicenseType licenseType) && int.TryParse(i_Attributes[1], out int engineVolume))
            {
                LicenseType = licenseType;
                EngineVolume = engineVolume;
            }
            else
            {
                throw new FormatException();
            }
        }

        public override string ToString()
        {
            return string.Format(
@"Motorcycle:
{0}
License Type: {1}
Engine Volume: {2}
", base.ToString(), LicenseType, EngineVolume);
        }
    }
}
