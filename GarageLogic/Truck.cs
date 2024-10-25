using System.Collections.Generic;

namespace GarageLogic
{
    public class Truck : Vehicle
    {
        private readonly int r_NumOfWheels = 14;
        private readonly float r_MaxAirPressure = 28f;
        private bool m_IsCarryingHazardousMaterials;
        private float m_CargoVolume;

        public Truck(string i_Brand, string i_LicenseNumber, Engine i_Engine)
            : base(i_Brand, i_LicenseNumber, i_Engine)
        {
        }

        public bool IsCarryingHazardousMaterials
        {
            get
            {
                return m_IsCarryingHazardousMaterials;
            }
            set
            {
                m_IsCarryingHazardousMaterials = value;
            }
        }

        public float CargoVolume
        {
            get
            {
                return m_CargoVolume;
            }
            set
            {
                m_CargoVolume = value;
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
                new VehicleParameter("IsCarryingHazardousMaterials", typeof(bool)),
                new VehicleParameter("CargoVolume", typeof(float))
            };
        }

        public override void SetParameters(Dictionary<string, object> i_Parameters)
        {
            IsCarryingHazardousMaterials = (bool)i_Parameters["IsCarryingHazardousMaterials"];
            CargoVolume = (float)i_Parameters["CargoVolume"];
        }
    }
}
