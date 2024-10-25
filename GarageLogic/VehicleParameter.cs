using System;

namespace GarageLogic
{
    public class VehicleParameter
    {
        public string Name { get; }
        public Type Type { get; }

        public VehicleParameter(string i_Name, Type i_Type)
        {
            Name = i_Name;
            Type = i_Type;
        }
    }
}
