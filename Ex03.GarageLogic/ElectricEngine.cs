namespace Ex03.GarageLogic
{
    internal class ElectricEngine : Engine
    {
        internal ElectricEngine(float i_MaxEngineCapacity) : base(i_MaxEngineCapacity) 
        { 

        }

        internal void Charge(float i_EnergyToAdd)
        {
            AddEnergy(i_EnergyToAdd);
        }

        public override string ToString()
        {
            return string.Format(@"Electric Engine: 
===============
{0}
", base.ToString());
        }
    }
}
