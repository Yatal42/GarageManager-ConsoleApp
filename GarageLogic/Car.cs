using System.Collections.Generic;

namespace GarageLogic
{
    public class Car : Vehicle
    {
        public enum eCarColor
        {
            Blue,
            White,
            Black,
            Red
        }

        public enum eNumberOfDoors
        {
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5
        }

        private readonly int r_NumOfWheels = 4;
        private readonly float r_MaxAirPressure = 33f;
        private eCarColor m_VehicleColor;
        private eNumberOfDoors m_NumOfDoors;

        public Car(string i_Brand, string i_LicenseNumber, Engine i_Engine)
            : base(i_Brand, i_LicenseNumber, i_Engine)
        {
        }

        public eCarColor Color
        {
            get
            {
                return m_VehicleColor;
            }
            set
            {
                m_VehicleColor = value;
            }
        }

        public eNumberOfDoors NumberOfDoors
        {
            get
            {
                return m_NumOfDoors;
            }
            set
            {
                m_NumOfDoors = value;
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
                new VehicleParameter("Color", typeof(eCarColor)),
                new VehicleParameter("NumberOfDoors", typeof(eNumberOfDoors))
            };
        }

        public override void SetParameters(Dictionary<string, object> i_Parameters)
        {
            Color = (eCarColor)i_Parameters["Color"];
            NumberOfDoors = (eNumberOfDoors)i_Parameters["NumberOfDoors"];
        }
    }
}
