using System;
using System.Collections.Generic;

namespace GarageLogic
{
    public class Garage
    {
        public enum eVehicleStatus
        {
            Treated = 1,
            Fixed,
            Paid
        }

        private readonly Dictionary<string, GarageVehicle> r_VehiclesInGarage = new Dictionary<string, GarageVehicle>();

        public event Action<string> VehicleAdded;
        public event Action<string> VehicleExists;

        public void AddOrUpdateVehicle(GarageVehicle i_GarageVehicle)
        {
            if (r_VehiclesInGarage.ContainsKey(i_GarageVehicle.Vehicle.LicenseNumber))
            {
                r_VehiclesInGarage[i_GarageVehicle.Vehicle.LicenseNumber].Status = eVehicleStatus.Treated;
                VehicleExists?.Invoke(i_GarageVehicle.Vehicle.LicenseNumber);
            }
            else
            {
                r_VehiclesInGarage.Add(i_GarageVehicle.Vehicle.LicenseNumber, i_GarageVehicle);
                VehicleAdded?.Invoke(i_GarageVehicle.Vehicle.LicenseNumber);
            }
        }

        public Vehicle GetVehicle(string i_LicenseNumber)
        {
            if (!r_VehiclesInGarage.TryGetValue(i_LicenseNumber, out GarageVehicle garageVehicle))
            {
                throw new ArgumentException($"No vehicle with license number {i_LicenseNumber} found in the garage.");
            }
            return garageVehicle.Vehicle;
        }

        public eVehicleStatus GetVehicleStatus(string i_LicenseNumber)
        {
            if (!r_VehiclesInGarage.TryGetValue(i_LicenseNumber, out GarageVehicle garageVehicle))
            {
                throw new ArgumentException($"No vehicle with license number {i_LicenseNumber} found in the garage.");
            }
            return garageVehicle.Status;
        }

        public bool SetVehicleStatus(string i_LicenseNumber, eVehicleStatus i_Status)
        {
            if (r_VehiclesInGarage.TryGetValue(i_LicenseNumber, out GarageVehicle garageVehicle))
            {
                garageVehicle.Status = i_Status;
                return true;
            }
            return false;
        }

        public string GetVehicleOwnerName(string i_LicenseNumber)
        {
            if (r_VehiclesInGarage.TryGetValue(i_LicenseNumber, out GarageVehicle garageVehicle))
            {
                return garageVehicle.OwnerName;
            }
            throw new ArgumentException($"No vehicle with license number {i_LicenseNumber} found in the garage.");
        }

        public Dictionary<string, eVehicleStatus> GetFilteredVehiclesByStatus(eVehicleStatus? i_StatusFilter = null)
        {
            Dictionary<string, eVehicleStatus> filteredVehicles = new Dictionary<string, eVehicleStatus>();

            foreach (var entry in r_VehiclesInGarage)
            {
                if (i_StatusFilter == null || entry.Value.Status == i_StatusFilter)
                {
                    filteredVehicles.Add(entry.Key, entry.Value.Status);
                }
            }

            return filteredVehicles;
        }

        public void InflateVehicleTires(string i_LicenseNumber)
        {
            Vehicle vehicle = GetVehicle(i_LicenseNumber);
            vehicle.InflateWheelsToMax();
        }

        public void FuelVehicle(string i_LicenseNumber, float i_FuelAmount, FuelEngine.eFuelType i_FuelType)
        {
            Vehicle vehicle = GetVehicle(i_LicenseNumber);
            if (vehicle.Engine is FuelEngine fuelEngine)
            {
                fuelEngine.FuelVehicle(i_FuelAmount, i_FuelType);
            }
            else
            {
                throw new ArgumentException("Vehicle does not have a fuel engine.");
            }
        }

        public void ChargeVehicle(string i_LicenseNumber, float i_HoursToCharge)
        {
            Vehicle vehicle = GetVehicle(i_LicenseNumber);
            if (vehicle.Engine is ElectricEngine electricEngine)
            {
                electricEngine.ChargeEngine(i_HoursToCharge);
            }
            else
            {
                throw new ArgumentException("Vehicle does not have an electric engine.");
            }
        }
    }
}
