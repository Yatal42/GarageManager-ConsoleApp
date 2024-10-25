namespace GarageLogic
{
    public abstract class Engine
    {
        public enum eEngineType
        {
            Electric,
            Fuel
        }

        private readonly eEngineType r_EngineType;
        private readonly float r_EnergyCapacity;
        private float m_CurrentEnergy;

        public Engine(float i_EnergyCapacity, eEngineType i_EngineType)
        {
            r_EnergyCapacity = i_EnergyCapacity;
            r_EngineType = i_EngineType;
        }

        public float EnergyCapacity
        {
            get
            {
                return r_EnergyCapacity;
            }
        }

        public float CurrentEnergy
        {
            get
            {
                return m_CurrentEnergy;
            }
            set
            {
                m_CurrentEnergy = value;
            }
        }

        public float EnergyPercentage
        {
            get
            {
                return ((CurrentEnergy / EnergyCapacity) * 100);
            }
        }
    }
}
