using System;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        private float m_MaxValue;
        private float m_MinValue;

        public float MaxValue
        {
            get { return this.m_MaxValue; }
        }

        public float MinValue
        {
            get { return this.m_MinValue; }
        }

        public ValueOutOfRangeException(float i_MaxValue, float i_MinValue)
            : base(string.Format("An invalid input has entered. Input should be in range {0}-{1}.",
                i_MinValue, i_MaxValue))
        {
            m_MinValue = i_MinValue;
            m_MaxValue = i_MaxValue;
        }
    }
}
