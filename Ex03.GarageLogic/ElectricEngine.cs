namespace Ex03.GarageLogic
{
    internal class ElectricEngine : Engine
    {
        internal ElectricEngine(float i_MaxEngineCapacity) : base(i_MaxEngineCapacity) 
        { 

        }

        internal void Charge(float i_EnergyToAddInMinutes)
        {
            AddEnergy(convertMinutesToHours(i_EnergyToAddInMinutes));
        }

        public override string ToString()
        {
            return string.Format(@"Electric Engine: 
===============
{0}
", base.ToString());
        }

        private float convertMinutesToHours(float i_Minutes)
        {
            return i_Minutes / 60;
        }
    }
}
