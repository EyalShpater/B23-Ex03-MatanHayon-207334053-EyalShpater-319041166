namespace Ex03.GarageLogic
{
    public abstract class Engine
    {
        protected float m_CurrentEnergyLevel;
        protected readonly float r_MaxCapacity;

        protected Engine(float i_MaxCapacity)
        {
            if (i_MaxCapacity > 0)
            {
                r_MaxCapacity = i_MaxCapacity;
            }
            else
            {
                throw new ValueOutOfRangeException(null, 0);
            }
            
            m_CurrentEnergyLevel = 0;
        }

        public float CurrentEnergyLevel
        { 
            get 
            { 
                return m_CurrentEnergyLevel; 
            }

            internal set
            {
                if (value <= r_MaxCapacity  && value >= 0)
                {
                    m_CurrentEnergyLevel = value;
                }
                else
                {
                    throw new ValueOutOfRangeException(r_MaxCapacity, 0, "Engine: ");
                }
            }
        }

        public float MaxCapacity
        {
            get
            {
                return r_MaxCapacity;
            }
        }

        public override string ToString()
        {
            return string.Format(@"Current Energy Level: {0}
Max Capacity: {1}", m_CurrentEnergyLevel, r_MaxCapacity);
        }

        protected void AddEnergy(float i_EnergyToAdd)
        {
            CurrentEnergyLevel += i_EnergyToAdd;
        }
    }
}
