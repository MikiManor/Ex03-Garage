using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class ValueOutOfRangeException : Exception
    {
        private float m_MaxValue;
        private float m_MinValue;


        public ValueOutOfRangeException(string i_MsgOfException, float i_MaxValue, float i_MinValue)
            : base(i_MsgOfException)
        {
            m_MaxValue = i_MaxValue;
            m_MinValue = i_MinValue;
        }
    }
}
