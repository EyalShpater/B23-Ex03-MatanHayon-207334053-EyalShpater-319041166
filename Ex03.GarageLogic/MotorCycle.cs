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

        public eLicenseType LicenseType
        {
            get { return m_LicenseType; }
            set { m_LicenseType = value; }
        }

        public int EngineVolume
        {
            get { return m_EngineVolume; }
            set { m_EngineVolume = value; }
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

            LicenseType = (eLicenseType)Enum.Parse(typeof(eLicenseType), i_Attributes[0]);
            EngineVolume = int.Parse(i_Attributes[1]);
        }
    }
}
