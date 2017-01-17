using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Car : Veicle
    {
        private enum Color
        {
            blue,
            white,
            black,
            silver
        }
        private enum NumOfDoors
        {
            2,
            3,
            4,
            5
        }
        
        private static NumOfDoors m_NumOfDoors;
        
        public NumOfDoors()
        {
        
        get{return m_NumOfDoors; }
        set
        {
            if(value.ToLower() in NumOfDoors)
            {
                m_NumOfDoors = value;
            }else
            {
                trow new exception("Car can has 2,3,4 or 5 doors");
            }
        }
        
        }
    }
}
