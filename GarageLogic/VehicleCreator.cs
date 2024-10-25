using System;
using System.Collections.Generic;

namespace GarageLogic
{
    public class VehicleCreator
    {
        public static Vehicle CreateVehicle(Vehicle.eVehicleType i_VehicleType, string i_ModelName, string i_LicenseNumber)
        {
            Vehicle newVehicle;
            Engine engine;

            switch (i_VehicleType)
            {
                case Vehicle.eVehicleType.ElectricCar:
                    engine = new ElectricEngine(5f, 0f);
                    newVehicle = new Car(i_ModelName, i_LicenseNumber, engine);
                    break;
                case Vehicle.eVehicleType.FuelCar:
                    engine = new FuelEngine(49f, 0f, FuelEngine.eFuelType.Octan95);
                    newVehicle = new Car(i_ModelName, i_LicenseNumber, engine);
                    break;
                case Vehicle.eVehicleType.ElectricMotorcycle:
                    engine = new ElectricEngine(2.5f, 0f);
                    newVehicle = new Motorcycle(i_ModelName, i_LicenseNumber, engine);
                    break;
                case Vehicle.eVehicleType.FuelMotorcycle:
                    engine = new FuelEngine(6f, 0f, FuelEngine.eFuelType.Octan98);
                    newVehicle = new Motorcycle(i_ModelName, i_LicenseNumber, engine);
                    break;
                case Vehicle.eVehicleType.FuelTruck:
                    engine = new FuelEngine(130f, 0f, FuelEngine.eFuelType.Soler);
                    newVehicle = new Truck(i_ModelName, i_LicenseNumber, engine);
                    break;
                default:
                    throw new ArgumentException("Invalid vehicle type");
            }

            return newVehicle;
        }
    }
}
