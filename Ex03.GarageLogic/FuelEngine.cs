namespace Ex03.GarageLogic
{
    internal class FuelEngine : Engine
    {
        private readonly eFuelType r_FuelType;

        internal void AddFuel(float i_AmountToAdd, eFuelType i_FuelTypeToAdd)
        {
            if (r_FuelType != i_FuelTypeToAdd)
            {
                //throw exception
            }
            else if (m_CurrentEnergyLevel + i_AmountToAdd > m_MaxCapacity)
            {
                //throw exception
            }
            else
            {
                m_CurrentEnergyLevel += i_AmountToAdd;
            }
        }

        public override string ToString()
        {
            return string.Format(
@"*** Fuel Engine *** 
Fuel Type: {0}
{1}", r_FuelType.ToString(), base.ToString());
        }

    }
}
