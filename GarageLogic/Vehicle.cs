using System;
using System.Collections.Generic;

namespace GarageLogic
{
    public abstract class Vehicle
    {
        public enum eVehicleType
        {
            ElectricCar,
            FuelCar,
            ElectricMotorcycle,
            FuelMotorcycle,
            FuelTruck
        }

        private readonly string r_Brand;
        private readonly string r_LicenseNumber;
        protected List<Wheel> m_Wheels;
        protected Engine m_Engine;

        public Vehicle(string i_Brand, string i_LicenseNumber, Engine i_Engine)
        {
            r_Brand = i_Brand;
            r_LicenseNumber = i_LicenseNumber;
            m_Engine = i_Engine;
        }

        public string Brand
        {
            get
            {
                return r_Brand;
            }
        }

        public string LicenseNumber
        {
            get
            {
                return r_LicenseNumber;
            }
        }

        public List<Wheel> Wheels
        {
            get
            {
                return m_Wheels;
            }
        }

        public Engine Engine
        {
            get
            {
                return m_Engine;
            }
        }

        public abstract float MaxAirPressure { get; }
        public abstract int NumberOfWheels { get; }
        public abstract List<VehicleParameter> GetRequiredParameters();
        public abstract void SetParameters(Dictionary<string, object> i_Parameters);

        public void InitializeWheels(List<string> i_ManufacturerNames, List<float> i_WheelsPressures, float i_MaxAirPressure, int i_NumberOfWheels)
        {
            if (i_WheelsPressures.Count != i_ManufacturerNames.Count)
            {
                throw new ArgumentException("The number of manufacturer names must match the number of wheels.");
            }
            m_Wheels = Wheel.CreateWheels(i_WheelsPressures, i_ManufacturerNames, i_MaxAirPressure, i_NumberOfWheels);
        }

        public void InflateWheelsToMax()
        {
            foreach (Wheel wheel in m_Wheels)
            {
                wheel.InflateWheel(wheel.MaxAirPressure - wheel.CurrentAirPressure);
            }
        }
    }
}
