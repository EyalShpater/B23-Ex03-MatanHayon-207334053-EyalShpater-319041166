using static Ex03.GarageLogic.eVehicleType;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class VehicleFactory
    {
        public static Vehicle CreateVehicle(eVehicleType i_Type, string i_LicenseNumber, string i_Model)
        {
            Vehicle vehicle = null;
            Engine engine = null;

            switch (i_Type)
            {
                case ElectricCar:
                    engine = new ElectricEngine(Car.k_MaxBatterySize);
                    vehicle = new Car(engine, i_Model, i_LicenseNumber);
                    break;
                case FuelCar:
                    engine = new FuelEngine(Car.k_MaxFuelTank, Car.k_FuelType);
                    vehicle = new Car(engine, i_Model, i_LicenseNumber);
                    break;
                case ElectricMotorCycle:
                    engine = new ElectricEngine(MotorCycle.k_MaxBatterySize);
                    vehicle = new MotorCycle(engine, i_Model, i_LicenseNumber);
                    break;
                case FuelMotorCycle:
                    engine = new FuelEngine(MotorCycle.k_MaxFuelTank, MotorCycle.k_FuelType);
                    vehicle = new MotorCycle(engine, i_Model, i_LicenseNumber);
                    break;
                case eVehicleType.Truck:
                    engine = new FuelEngine(Truck.k_MaxFuelTank, Truck.k_eFuelType);
                    vehicle = new Truck(engine, i_Model, i_LicenseNumber);
                    break;
                default:
                    /// throw exception
                    break;
            }

            return vehicle;
        }

    }
}
