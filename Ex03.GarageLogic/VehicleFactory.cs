using static Ex03.GarageLogic.eVehicleType;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class VehicleFactory
    {
        //Regular Motorcycle consts:
        private const int k_RegularMotorCycleNumOfWheels = 2;
        private const float k_RegularMotorCycleMaxWheelAirPressure = 31;
        private const eFuelType k_RegularMotorCycleFuelType = eFuelType.Octan98;
        private const float k_RegularMotorCycleMaxFuelTank = 6.4f;

        //Electric Motorcycle consts:
        private const int k_ElectricMotorCycleNumOfWheels = 2;
        private const float k_ElectricMotorCycleMaxWheelAirPressure = 31;
        private const float k_ElectricMotorCycleMaxBattery = 2.6f;

        //Regular Car consts:
        private const int k_RegularCarNumOfWheels = 5;
        private const float k_RegularCarMaxAirPressure = 33;
        private const eFuelType k_RegularCarFuelType = eFuelType.Octan95;
        private const float k_RegularCarMaxFuelTank = 46f;

        //Electric Car consts:
        private const int k_ElectricCarNumOfWheels = 5;
        private const float k_ElectricCarMaxAirPressure = 33;
        private const float k_ElectricCarMaxBattery = 5.2f;

        //Truck consts:
        private const int k_TruckNumOfWheels = 14;
        private const float k_TruckMaxAirPressure = 26;
        private const eFuelType k_TruckFuelType = eFuelType.Soler;
        private const float k_TruckMaxFuelTank = 135f;

        public static Vehicle CreateVehicle(eVehicleType i_Type)
        {
            Vehicle vehicle = null;
            List<Wheel> wheels = null;
            Engine engine = null;

            switch (i_Type)
            {
                case ElectricCar:
                    engine = new ElectricEngine(k_ElectricCarMaxBattery);
                    wheels = createWheels(k_ElectricCarNumOfWheels, k_ElectricCarMaxAirPressure);
                    vehicle = new Car(engine, wheels);
                    break;
                case FuelCar:
                    engine = new FuelEngine(k_RegularCarMaxFuelTank, k_RegularCarFuelType);
                    wheels = createWheels(k_RegularCarNumOfWheels, k_RegularCarMaxAirPressure);
                    vehicle = new Car(engine, wheels);
                    break;
                case ElectricMotorCycle:
                    engine = new ElectricEngine(k_ElectricMotorCycleMaxBattery);
                    wheels = createWheels(k_ElectricMotorCycleNumOfWheels, k_ElectricMotorCycleMaxWheelAirPressure);
                    vehicle = new MotorCycle(engine, wheels);
                    break;
                case FuelMotorCycle:
                    engine = new FuelEngine(k_RegularMotorCycleMaxFuelTank, k_RegularMotorCycleFuelType);
                    wheels = createWheels(k_RegularMotorCycleNumOfWheels, k_RegularMotorCycleMaxWheelAirPressure);
                    vehicle = new MotorCycle(engine, wheels);
                    break;
                case eVehicleType.Truck:
                    engine = new FuelEngine(k_TruckMaxFuelTank, k_TruckFuelType);
                    wheels = createWheels(k_TruckNumOfWheels, k_TruckMaxAirPressure);
                    vehicle = new Truck(engine, wheels);
                    break;
                default:
                    /// throw exception
                    break;
            }

            return vehicle;
        }

        private static List<Wheel> createWheels(int i_NumOfWheels, float i_AirPressure)
        {
            List<Wheel> wheelsResult = new List<Wheel>(i_NumOfWheels);

            for (int i = 0; i < wheelsResult.Count; i++)
            {
                wheelsResult[i] = new Wheel(i_AirPressure);
            }

            return wheelsResult;
        }

    }
}
