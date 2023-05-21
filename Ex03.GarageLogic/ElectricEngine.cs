namespace Ex03.GarageLogic
{
    internal class ElectricEngine : Engine
    {
        internal void Charge(float i_EnergyToAdd)
        {
            base.AddEnergy(i_EnergyToAdd);
        }

        public override string ToString()
        {
            return string.Format("Electric Engine: {0}",base.ToString());

        }
    }
}
