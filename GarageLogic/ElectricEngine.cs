namespace GarageLogic
{
    public class ElectricEngine : Engine
    {
        private readonly float r_EngineMaxHours;
        private float m_EngineHoursLeft;

        public ElectricEngine(float i_MaxBatteryCapacity, float i_CurrentBatteryLevel)
            : base(i_MaxBatteryCapacity, eEngineType.Electric)
        {
            m_EngineHoursLeft = i_CurrentBatteryLevel;
            CurrentEnergy = m_EngineHoursLeft;
            r_EngineMaxHours = i_MaxBatteryCapacity;
        }

        public float EngineHoursMaxCapacity
        {
            get
            {
                return r_EngineMaxHours;
            }
        }

        public float EngineCurrentHoursLeft
        {
            get
            {
                return m_EngineHoursLeft;
            }
        }

        public void ChargeEngine(float i_HoursToAdd)
        {
            m_EngineHoursLeft += i_HoursToAdd;
            CurrentEnergy = m_EngineHoursLeft;
        }
    }
}
