using System.Collections.Generic;

namespace GarageLogic
{
    public class Motorcycle : Vehicle
    {
        public enum eLicenseType
        {
            A,
            A1,
            A2,
            B
        }

        private readonly int r_NumOfWheels = 2;
        private readonly float r_MaxAirPressure = 31f;
        private eLicenseType m_LicenseType;
        private int m_EngineVolume;

        public Motorcycle(string i_Brand, string i_LicenseNumber, Engine i_Engine)
            : base(i_Brand, i_LicenseNumber, i_Engine)
        {
        }

        public eLicenseType LicenseType
        {
            get
            {
                return m_LicenseType;
            }
            set
            {
                m_LicenseType = value;
            }
        }

        public int EngineVolume
        {
            get
            {
                return m_EngineVolume;
            }
            set
            {
                m_EngineVolume = value;
            }
        }

        public override float MaxAirPressure
        {
            get { return r_MaxAirPressure; }
        }

        public override int NumberOfWheels
        {
            get { return r_NumOfWheels; }
        }

        public override List<VehicleParameter> GetRequiredParameters()
        {
            return new List<VehicleParameter>
            {
                new VehicleParameter("LicenseType", typeof(eLicenseType)),
                new VehicleParameter("EngineVolume", typeof(int))
            };
        }

        public override void SetParameters(Dictionary<string, object> i_Parameters)
        {
            LicenseType = (eLicenseType)i_Parameters["LicenseType"];
            EngineVolume = (int)i_Parameters["EngineVolume"];
        }
    }
}
