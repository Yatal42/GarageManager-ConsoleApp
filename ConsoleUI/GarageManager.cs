using GarageLogic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleUI
{
    public class GarageManager
    {
        private readonly Garage r_VehicleList = new Garage();
        private readonly UI r_UI = new UI();

        public GarageManager()
        {
            r_VehicleList.VehicleAdded += onVehicleAdded;
            r_VehicleList.VehicleExists += onVehicleExists;
        }

        public void ManageGarage()
        {
            bool exit = false;

            while (!exit)
            {
                int userInput = r_UI.GetMenuSelectionFromUser();

                switch (userInput)
                {
                    case 1:
                        checkInVehicle();
                        break;
                    case 2:
                        listVehicles();
                        break;
                    case 3:
                        changeVehicleStatus();
                        break;
                    case 4:
                        inflateTiresToMax();
                        break;
                    case 5:
                        fuelVehicle();
                        break;
                    case 6:
                        chargeVehicle();
                        break;
                    case 7:
                        showVehicleFullData();
                        break;
                    case 8:
                        exit = true;
                        break;
                    default:
                        r_UI.Print("Invalid input, please try again.");
                        break;
                }
            }
        }

        private void checkInVehicle()
        {
            r_UI.Print("Checking in a new vehicle...");
            string vehicleLicenseNumber = r_UI.GetVehicleLicenseNumber();
            try
            {
                Vehicle vehicle = r_VehicleList.GetVehicle(vehicleLicenseNumber);
                r_VehicleList.SetVehicleStatus(vehicleLicenseNumber, Garage.eVehicleStatus.Treated);
                r_UI.DeclareVehicleExists();
            }
            catch (ArgumentException)
            {
                Vehicle.eVehicleType vehicleType = r_UI.GetVehicleType();
                string vehicleModel = r_UI.GetVehicleModel();

                Vehicle vehicle = VehicleCreator.CreateVehicle(vehicleType, vehicleModel, vehicleLicenseNumber);

                List<VehicleParameter> requiredParameters = vehicle.GetRequiredParameters();
                Dictionary<string, object> parameters = r_UI.GetParametersFromUser(requiredParameters);
                vehicle.SetParameters(parameters);

                int numberOfWheels = vehicle.NumberOfWheels;
                float maxWheelPressure = vehicle.MaxAirPressure;
                List<string> wheelManufacturers;
                List<float> wheelPressures;
                r_UI.GetVehicleWheelManufacturersAndPressureFromUser(numberOfWheels, maxWheelPressure, out wheelManufacturers, out wheelPressures);
                vehicle.InitializeWheels(wheelManufacturers, wheelPressures, maxWheelPressure, numberOfWheels);

                if (vehicle.Engine is FuelEngine fuelEngine)
                {
                    fuelEngine.FuelVehicle(r_UI.GetFuelVolumeFromUser(fuelEngine.EngineMaxCapacity, fuelEngine.CurrentEngineEnergy), fuelEngine.FuelType);
                }
                else if (vehicle.Engine is ElectricEngine electricEngine)
                {
                    electricEngine.ChargeEngine(r_UI.GetMinutesToChargeFromUser(electricEngine.EngineHoursMaxCapacity, electricEngine.EngineCurrentHoursLeft));
                }

                string ownerName = r_UI.GetNewVehicleOwnerName();
                string phoneNumber = r_UI.GetNewVehicleOwnerPhoneNumber();
                GarageVehicle garageVehicle = new GarageVehicle(vehicle, ownerName, phoneNumber, Garage.eVehicleStatus.Treated);

                r_VehicleList.AddOrUpdateVehicle(garageVehicle);
            }
        }

        private void onVehicleAdded(string i_LicenseNumber)
        {
            r_UI.DeclareVehicleAdded();
        }

        private void onVehicleExists(string i_LicenseNumber)
        {
            r_UI.DeclareVehicleExists();
        }

        private void listVehicles()
        {
            int filter;
            int.TryParse(r_UI.GetStatusFromUserForFilteredListOfVehicles(), out filter);
            Dictionary<string, Garage.eVehicleStatus> filteredVehicleList =
                r_VehicleList.GetFilteredVehiclesByStatus((Garage.eVehicleStatus)filter);

            if (filteredVehicleList.Count == 0)
            {
                r_UI.Print("There are no vehicles in the garage.");
            }
            else
            {
                r_UI.Print("Listing all vehicles according to filter...");
                foreach (KeyValuePair<string, Garage.eVehicleStatus> entry in filteredVehicleList)
                {
                    r_UI.Print($"License Number: {entry.Key}, Status: {entry.Value}");
                }
            }
        }

        private void changeVehicleStatus()
        {
            try
            {
                string licenseNumber = r_UI.GetVehicleLicenseNumber();
                int inputStatus;
                int.TryParse(r_UI.GetStatusFromUserForUpdatingVehicle(), out inputStatus);
                Garage.eVehicleStatus status = (Garage.eVehicleStatus)inputStatus;
                bool statusUpdated = r_VehicleList.SetVehicleStatus(licenseNumber, status);

                if (statusUpdated)
                {
                    r_UI.Print($"Vehicle status changed to {status}.");
                }
            }
            catch (ArgumentException ex)
            {
                r_UI.Print($"Error: {ex.Message} Status update process aborted.");
            }
        }

        private void inflateTiresToMax()
        {
            try
            {
                string licenseNumber = r_UI.GetVehicleLicenseNumber();
                r_VehicleList.InflateVehicleTires(licenseNumber);
                r_UI.Print("Tires are inflated to maximum!");
            }
            catch (ArgumentException ex)
            {
                r_UI.Print($"Error: {ex.Message} Inflation process aborted.");
            }
        }

        private void fuelVehicle()
        {
            string licenseNumber = r_UI.GetVehicleLicenseNumber();

            try
            {
                FuelEngine.eFuelType fuelTypeToAdd = r_UI.GetFuelTypeFromUser();
                float fuelToAdd = r_UI.GetFuelVolumeFromUser(float.MaxValue, 0);
                r_VehicleList.FuelVehicle(licenseNumber, fuelToAdd, fuelTypeToAdd);
                r_UI.Print("Vehicle is fueled!");
            }
            catch (ArgumentException ex)
            {
                r_UI.Print($"Error: {ex.Message} Fueling process aborted.");
            }
        }

        private void chargeVehicle()
        {
            string licenseNumber = r_UI.GetVehicleLicenseNumber();

            try
            {
                float minutesToAdd = r_UI.GetMinutesToChargeFromUser(float.MaxValue, 0); 
                r_VehicleList.ChargeVehicle(licenseNumber, minutesToAdd);
                r_UI.Print("Vehicle is charged!");
            }
            catch (ArgumentException ex)
            {
                r_UI.Print($"Error: {ex.Message} Charging process aborted.");
            }
        }

        private void showVehicleFullData()
        {
            r_UI.Print("Showing vehicle's full data...");
            string licenseNumber = r_UI.GetVehicleLicenseNumber();

            try
            {
                Vehicle vehicle = r_VehicleList.GetVehicle(licenseNumber);
                HashSet<string> printedProperties = new HashSet<string>();
                printAndTrackProperty("LicenseNumber", vehicle.LicenseNumber, printedProperties);
                printAndTrackProperty("Brand", vehicle.Brand, printedProperties);
                printAndTrackProperty("OwnerName", r_VehicleList.GetVehicleOwnerName(licenseNumber), printedProperties);
                printAndTrackProperty("Status", r_VehicleList.GetVehicleStatus(licenseNumber).ToString(), printedProperties);
                handleWheels(vehicle.Wheels, printedProperties);
                handleEngine(vehicle.Engine, printedProperties);
                printRemainingProperties(vehicle, printedProperties);
            }
            catch (ArgumentException ex)
            {
                r_UI.Print(ex.Message);
            }
        }

        private void printAndTrackProperty(string i_PropertyName, object i_PropertyValue, HashSet<string> io_PrintedProperties)
        {
            r_UI.Print($"{i_PropertyName}: {i_PropertyValue}");
            io_PrintedProperties.Add(i_PropertyName);
        }

        private void handleWheels(List<Wheel> i_Wheels, HashSet<string> io_PrintedProperties)
        {
            if (i_Wheels != null && i_Wheels.Count > 0)
            {
                r_UI.Print($"WheelsManufacturers: {string.Join(", ", i_Wheels.Select(wheel => wheel.ManufacturerName))}");
                r_UI.Print($"WheelsPressures: {string.Join(", ", i_Wheels.Select(wheel => wheel.CurrentAirPressure))}");
                io_PrintedProperties.Add("Wheels");
            }
        }

        private void handleEngine(Engine i_Engine, HashSet<string> io_PrintedProperties)
        {
            if (i_Engine != null)
            {
                r_UI.Print($"EnergyPercentage: {i_Engine.EnergyPercentage}%");
                if (i_Engine is FuelEngine fuelEngine)
                {
                    r_UI.Print($"FuelType: {fuelEngine.FuelType}");
                }
                io_PrintedProperties.Add("EnergyPercentage");
                io_PrintedProperties.Add("Engine");
            }
        }

        private void printRemainingProperties(Vehicle i_Vehicle, HashSet<string> io_PrintedProperties)
        {
            var propertiesList = i_Vehicle.GetType().GetProperties();

            foreach (var property in propertiesList)
            {
                string propertyName = property.Name;
                if (!io_PrintedProperties.Contains(propertyName))
                {
                    object value = property.GetValue(i_Vehicle);
                    r_UI.Print($"{propertyName}: {value ?? "N/A"}");
                    io_PrintedProperties.Add(propertyName);
                }
            }
        }
    }
}
