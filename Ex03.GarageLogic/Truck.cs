using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private bool m_IsDangerousMaterials;
        private float m_CargoVolume;

        public bool IsDangerousMaterials
        {
            get { return m_IsDangerousMaterials; }
            set { m_IsDangerousMaterials = value; }
        }

        public float CargoVolume
        {
            get { return m_CargoVolume; }
            set { m_CargoVolume = value; }
        }

        public override string[] GetUniqueAttributes()
        {
            return new string[] { "Is containing Dangerous Materials", "Cargo Volume" };
        }

        public override void SetUniqueAttributes(string[] i_Attributes)
        {
            if (i_Attributes.Length != 2)
            {
                throw new ArgumentException("Invalid number of features.");
            }

            IsDangerousMaterials = bool.Parse(i_Attributes[0]);
            CargoVolume = float.Parse(i_Attributes[1]);
        }
    }
}
