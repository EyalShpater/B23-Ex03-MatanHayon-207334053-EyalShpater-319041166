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
    }

}
