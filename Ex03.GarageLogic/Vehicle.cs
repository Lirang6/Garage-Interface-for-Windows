using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Vehicle
    {
        protected internal readonly string r_Model;
        protected internal readonly string r_LicenseNumber;
        protected internal readonly int r_NumberOfWheels;
        protected internal readonly float r_MaxPressure;
        protected internal readonly string r_Manufacture;
        protected internal readonly List<Wheel> r_Wheels = new List<Wheel>();
        protected internal readonly Engine r_Engine;

        public Vehicle(string i_Model, string i_LicenseNumber, Engine i_Engine, int i_NumberOfWheels, string i_Manufacture, float i_MaxPressure, float i_CurrentPressure)
        {
            r_Model = i_Model;
            r_LicenseNumber = i_LicenseNumber;
            r_Engine = i_Engine;
            r_NumberOfWheels = i_NumberOfWheels;
            r_MaxPressure = i_MaxPressure;
            r_Manufacture = i_Manufacture;

            for (int i = 0; i < i_NumberOfWheels; i++)
            {
                r_Wheels.Add(new Wheel(i_Manufacture, i_MaxPressure, i_CurrentPressure));
            }
        }

        public override string ToString()
        {
            StringBuilder description = new StringBuilder(string.Format("License number: {0}, Model: {1}{2}", 
                r_LicenseNumber, r_Model, Environment.NewLine));
            description.AppendLine(
                string.Format(
                    "Wheels Information: {0}Number of Wheels: {1}, Current Pressure: {2},  Maximum Pressure: {3}, Manufacture: {4}",
                    Environment.NewLine,
                    r_NumberOfWheels,
                    r_Wheels[0].m_CurrentPressure,
                    r_MaxPressure,
                    r_Manufacture));
            description.AppendLine(r_Engine.ToString());

            return description.ToString();
        }
    }
}
