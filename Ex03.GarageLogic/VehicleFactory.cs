using static Ex03.GarageLogic.eVehicleType;

namespace Ex03.GarageLogic
{
    public class VehicleFactory
    {
        public Vehicle CreateNewVehicle(eVehicleType i_Type)
        {
            const bool v_IsElectric = true;
            Vehicle vehicle = null;

            switch(i_Type)
            {
                case ElectricCar:
                    vehicle = new Car(v_IsElectric);
                    break;
                case FuelCar:
                    vehicle = new Car(!v_IsElectric);
                    break;
                case ElectricMotorCycle:
                    vehicle = new MotorCycle(v_IsElectric);
                    break;
                case FuelMotorCycle:
                    vehicle = new MotorCycle(!v_IsElectric);
                    break;
                case eVehicleType.Truck:
                    vehicle = new Truck();
                    break;
                default:
                    /// throw exception
                    break;
            }

            return vehicle;
        }
    }
}
