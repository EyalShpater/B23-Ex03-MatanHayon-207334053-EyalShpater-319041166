namespace Ex03.GarageLogic
{
    public abstract class Engine
    {
        protected float m_CurrentEnergyLevel;
        protected float m_MaxCapacity;

        protected Engine(float i_MaxCapacity)
        {
            m_MaxCapacity = i_MaxCapacity;
            m_CurrentEnergyLevel = 0;
        }

        public float CurrentEnergyLevel
        { 
            get 
            { 
                return m_CurrentEnergyLevel; 
            } 


        }

        public float MaxCapacity
        {
            get
            {
                return m_MaxCapacity;
            }

            set
            {
                if (value > 0)
                {
                    m_MaxCapacity = value;
                }
                else
                {
                    throw new ValueOutOfRangeException(null, 0);
                } 
            }
        }

        protected void AddEnergy(float i_EnergyToAdd)
        {
            if (this.CurrentEnergyLevel + i_EnergyToAdd <= m_MaxCapacity)
            {
                m_CurrentEnergyLevel += i_EnergyToAdd;
            }
            else
            {
                throw new ValueOutOfRangeException(m_MaxCapacity, 0);
            }
        }

        public override string ToString()
        {
            return string.Format(
@"Current Energy Level: {0}
Max Capacity: {1}",
                m_CurrentEnergyLevel, m_MaxCapacity);
        }

    }

}
