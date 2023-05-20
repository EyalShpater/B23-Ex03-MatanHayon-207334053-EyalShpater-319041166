using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class MotorCycle : Vehicle
    {
        private eLicenseType m_LicenseType;
        private int m_EngineVolume;

        public MotorCycle(bool i_IsElectric) : base(i_IsElectric)
        {
            m_LicenseType = 0;
            m_EngineVolume = 0;
        }

        public eLicenseType LicenseType
        {
            get { return m_LicenseType; }
        }

        public int EngineVolume
        {
            get { return m_EngineVolume; }
        }

        public override string[] GetUniqueAttributes()
        {
            return new string[] { "LicensesType", "EngineVolume" };
        }

        public override void SetUniqueAttributes(string[] i_Attributes)
        {
            if (i_Attributes.Length != 2)
            {
                throw new ArgumentException("Invalid number of attributes.");
            }

            m_LicenseType = (eLicenseType)Enum.Parse(typeof(eLicenseType), i_Attributes[0]);
            m_EngineVolume = int.Parse(i_Attributes[1]);
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
