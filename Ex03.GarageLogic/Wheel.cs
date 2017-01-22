using System;

namespace Ex03.GarageLogic
{
    public struct WheelCollection
    {
        public string WheelFirma;
        public float CurrentAirPreasure; 
    }

    public class Wheel
    {
        private readonly string r_Firma = null;
        private readonly float r_MaxRecommandedAirPreasure = 0;
        private float m_CurrentAirPreasure = 0;

        public Wheel(string i_TireFirma, float i_CurrentAirPreasure, float i_MaxRecommandedAirPreasure)
        {
            if (i_TireFirma.Length == 0)
            {
                throw new Exception("Tire Firma cannot be blank!");
            }
            else if (i_CurrentAirPreasure > i_MaxRecommandedAirPreasure)
            {
                throw new Exception("Current tire preasure cannot be higher then the maximunx preasure the tire can handle!");
            }
            else if (i_CurrentAirPreasure < 0)
            {
                throw new Exception("Current tire preasure cannot be negative!");
            }
            else if (i_MaxRecommandedAirPreasure <= 0)
            {
                throw new Exception("Current max tire preasure must be higher then 0!");
            }
            else
            {
                r_Firma = i_TireFirma;
                r_MaxRecommandedAirPreasure = i_MaxRecommandedAirPreasure;
                m_CurrentAirPreasure = i_CurrentAirPreasure;
            }
        }

        public float CurrentAirPreasure
        {
            get { return m_CurrentAirPreasure; }
        }

        public float MaxRecommandedAirPreasure
        {
            get { return r_MaxRecommandedAirPreasure; }
        }

        public void TireInflating(float i_PreasureToAdd)
        {
            if (i_PreasureToAdd + m_CurrentAirPreasure > r_MaxRecommandedAirPreasure)
            {
                throw new ValueOutOfRangeException("Cannot add air preasure above max recommanded!", r_MaxRecommandedAirPreasure - m_CurrentAirPreasure, 0);
            }
            else
            {
                 m_CurrentAirPreasure += i_PreasureToAdd;
            }
        }

        public override string ToString()
        {
            return string.Format("\t\tFirma : {0}, CurrentAirPreasure : {1}, Max Air Preasure : {2}", r_Firma, m_CurrentAirPreasure, r_MaxRecommandedAirPreasure);
        }
    }
}
