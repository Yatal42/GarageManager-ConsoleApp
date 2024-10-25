using System;

namespace GarageLogic
{
    public class FuelEngine : Engine
    {
        public enum eFuelType
        {
            Soler,
            Octan95,
            Octan96,
            Octan98
        }

        private readonly eFuelType r_FuelType;
        private readonly float r_EngineCapacity;
        private float m_CurrentEnergy;

        public FuelEngine(float i_MaxFuelCapacity, float i_CurrentFuelLevel, eFuelType i_FuelType)
            : base(i_MaxFuelCapacity, eEngineType.Fuel)
        {
            r_FuelType = i_FuelType;
            CurrentEnergy = i_CurrentFuelLevel;
            m_CurrentEnergy = i_CurrentFuelLevel;
            r_EngineCapacity = i_MaxFuelCapacity;
        }

        public float EngineMaxCapacity
        {
            get
            {
                return r_EngineCapacity;
            }
        }

        public float CurrentEngineEnergy
        {
            get
            {
                return m_CurrentEnergy;
            }
        }

        public eFuelType FuelType
        {
            get
            {
                return r_FuelType;
            }
        }

        public void FuelVehicle(float i_FuelToAdd, eFuelType i_FuelType)
        {
            if (i_FuelType != r_FuelType)
            {
                throw new ArgumentException("Fuel type does not match.");
            }
            m_CurrentEnergy += i_FuelToAdd;
            CurrentEnergy = m_CurrentEnergy;
        }
    }
}
