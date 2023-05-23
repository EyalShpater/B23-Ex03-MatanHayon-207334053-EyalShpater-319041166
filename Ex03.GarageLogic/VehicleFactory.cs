namespace Ex03.GarageLogic
{
    public static class VehicleFactory
    {
        public static string[] GetVehiclesTypes()
        {
            string[] types = { "Electric Car", "Fuel Car", "Electric MotorCycle", "Fuel MotorCycle", "Truck" };

            return types;
        }
        public static Vehicle CreateVehicle(int i_Type)
        {
            Vehicle vehicle = null;
            Engine engine = null;

            switch (i_Type)
            {
                case 0:
                    engine = new ElectricEngine(Car.k_MaxBatterySize);
                    vehicle = new Car(engine);
                    break;
                case 1:
                    engine = new FuelEngine(Car.k_MaxFuelTank, Car.k_FuelType);
                    vehicle = new Car(engine);
                    break;
                case 2:
                    engine = new ElectricEngine(MotorCycle.k_MaxBatterySize);
                    vehicle = new MotorCycle(engine);
                    break;
                case 3:
                    engine = new FuelEngine(MotorCycle.k_MaxFuelTank, MotorCycle.k_FuelType);
                    vehicle = new MotorCycle(engine);
                    break;
                case 4:
                    engine = new FuelEngine(Truck.k_MaxFuelTank, Truck.k_eFuelType);
                    vehicle = new Truck(engine);
                    break;
                default:
                    /// throw exception
                    break;
            }

            return vehicle;
        }

    }
}
