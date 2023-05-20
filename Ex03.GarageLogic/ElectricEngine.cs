namespace Ex03.GarageLogic
{
    internal class ElectricEngine : Engine
    {
        internal void AddEnergy(float i_EnergyToAdd)
        {
            if(this.CurrentEnergyLevel+i_EnergyToAdd>m_MaxCapacity)
            {
                //throw exception
            }
            else
            {
                this.CurrentEnergyLevel += i_EnergyToAdd;
            }
        }
    }
}
