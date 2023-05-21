namespace Ex03.GarageLogic
{
    public abstract class Engine
    {
        protected float m_CurrentEnergyLevel;
        protected readonly float m_MaxCapacity;

        public float CurrentEnergyLevel
        { 
            get 
            { 
                return m_CurrentEnergyLevel; 
            } 

            set 
            {
                m_CurrentEnergyLevel = value;   
            }
        }

        public float MaxCapacity
        {
            get
            {
                return m_MaxCapacity;
            }
        }

        protected void AddEnergy(float i_EnergyToAdd)
        {
            if (this.CurrentEnergyLevel + i_EnergyToAdd <= m_MaxCapacity)
            {
                this.CurrentEnergyLevel += i_EnergyToAdd;
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
