namespace Ex03.GarageLogic
{
    internal class Wheel
    {
        private readonly string r_ManufacturerName;
        private float m_CurrentAirPressure;
        private readonly float r_MaxAirPressure;

        internal float CurrentAirPressure
        {
            get 
            { 
                return m_CurrentAirPressure; 
            }
        }

        internal float MaxAirPressure
        {
            get
            {
                return r_MaxAirPressure;
            }
        }

        internal void AddAir(float i_AirToAdd)
        {
            float newAirPressure = i_AirToAdd + m_CurrentAirPressure;

            if (newAirPressure <= r_MaxAirPressure && newAirPressure >= 0)
            {
                m_CurrentAirPressure = newAirPressure;
            }
            else
            {
                throw new ValueOutOfRangeException(r_MaxAirPressure, 0);
            }
        }

        public override string ToString()
        {
            return string.Format(
    @"Manufacturer Name: {0}
Current Air Pressure: {1}
Max Air Pressure: {2}
", r_ManufacturerName, m_CurrentAirPressure, r_MaxAirPressure);
        }
    }
}