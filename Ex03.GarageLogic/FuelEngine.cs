using System;

namespace Ex03.GarageLogic
{
    internal class FuelEngine : Engine
    {
        private eFuelType r_FuelType;
        public eFuelType FuelType
        {
            get { return r_FuelType; }
            set { r_FuelType = value; }
        }

        internal void AddFuel(float i_AmountToAdd, eFuelType i_FuelTypeToAdd)
        {
            if (r_FuelType == i_FuelTypeToAdd)
            {
                base.AddEnergy(i_AmountToAdd);
            }
            else
            {
                throw new ArgumentException(string.Format("Wrong Fuel Type! Fuel Type must be {0}!", r_FuelType.ToString()));
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
