using System;

namespace GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        public float MaxValue { get; }
        public float MinValue { get; }

        public ValueOutOfRangeException(float i_MaxValue, float i_MinValue)
            : base($"The provided value is out of the defined range! Valid range is between {i_MinValue} and {i_MaxValue}.")
        {
            MaxValue = i_MaxValue;
            MinValue = i_MinValue;
        }

        public ValueOutOfRangeException(string i_Message, float i_MaxValue, float i_MinValue)
            : base(i_Message)
        {
            MaxValue = i_MaxValue;
            MinValue = i_MinValue;
        }
    }
}
