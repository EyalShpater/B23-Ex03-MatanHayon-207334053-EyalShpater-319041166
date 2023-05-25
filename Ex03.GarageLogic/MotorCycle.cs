using System;

namespace Ex03.GarageLogic
{
    public class MotorCycle : Vehicle
    {
        internal const eFuelType k_FuelType = eFuelType.Octan98;
        internal const float k_MaxFuelTank = 6.4f;
        internal const float k_MaxBatterySize = 2.6f;
        private const int k_NumOfWheels = 2;
        private const float k_MaxWheelAirPressure = 31;
        private const int k_NumOfAttributes = 2;
        private eLicenseType m_LicenseType;
        private int m_EngineVolume;

        public MotorCycle(Engine i_Engine, string i_LicenseNumber) : base(i_Engine, i_LicenseNumber)
        {
            m_LicenseType = 0;
            m_EngineVolume = 0;
            m_Wheels = CreateWheelsList(k_NumOfWheels, k_MaxWheelAirPressure);
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

        public override string ToString()
        {
            return string.Format(@"Motorcycle:
==========
{0}
License Type: {1}
Engine Volume: {2}", base.ToString(), LicenseType, EngineVolume);
        }

        internal override void SetUniqueAttributes(string[] i_Attributes)
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
    }
}
