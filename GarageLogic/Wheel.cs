using System;
using System.Collections.Generic;

namespace GarageLogic
{
    public class Wheel
    {
        private string m_ManufacturerName;
        private float m_CurrentAirPressure;
        private float m_MaxAirPressure;

        public Wheel(string i_ManufacturerName, float i_WheelPressure, float i_MaxAirPressure)
        {
            m_ManufacturerName = i_ManufacturerName;
            m_CurrentAirPressure = i_WheelPressure;
            m_MaxAirPressure = i_MaxAirPressure;
        }

        public string ManufacturerName
        {
            get
            {
                return m_ManufacturerName;
            }
        }

        public float CurrentAirPressure
        {
            get
            {
                return m_CurrentAirPressure;
            }
        }

        public float MaxAirPressure
        {
            get { return m_MaxAirPressure; }
        }

        public static List<Wheel> CreateWheels(List<float> i_WheelsPressures, List<string> i_ManufacturerNames, float i_MaxAirPressure, int i_NumberOfWheels)
        {
            List<Wheel> wheels = new List<Wheel>();
            if (i_ManufacturerNames.Count == 1)
            {
                string manufacturerName = i_ManufacturerNames[0];
                float wheelPressure = i_WheelsPressures[0];
                for (int index = 0; index < i_NumberOfWheels; index++)
                {
                    wheels.Add(new Wheel(manufacturerName, wheelPressure, i_MaxAirPressure));
                }
            }
            else if (i_ManufacturerNames.Count == i_WheelsPressures.Count && i_ManufacturerNames.Count == i_NumberOfWheels)
            {
                for (int index = 0; index < i_NumberOfWheels; index++)
                {
                    wheels.Add(new Wheel(i_ManufacturerNames[index], i_WheelsPressures[index], i_MaxAirPressure));
                }
            }
            else
            {
                throw new ArgumentException("The number of manufacturer names must match the number of wheels.");
            }

            return wheels;
        }

        public void InflateWheel(float i_AirToAdd)
        {
            if (m_CurrentAirPressure + i_AirToAdd > m_MaxAirPressure)
            {
                throw new ValueOutOfRangeException(m_MaxAirPressure, 0);
            }
            m_CurrentAirPressure += i_AirToAdd;
        }
    }
}
