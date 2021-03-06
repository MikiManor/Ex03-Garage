﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class Truck : Vehicle
    {
        private const int k_NumOfWheels = 12;
        private const int k_MaxWheelsAirPreasure = 26;
        private readonly eFuelType r_FuelType = eFuelType.Octan96;
        private readonly float r_MaxAmountOfFuel = 150;
        private bool m_IsCarryingDangerousGoods;
        private float m_MaxCarryingWeight;
        private float m_CurrentGoodsWeight;
        
        internal Truck(string i_LicenseNumber)
            : base(i_LicenseNumber, k_NumOfWheels, k_MaxWheelsAirPreasure)
        {
            Engine = new FuelEngine(r_MaxAmountOfFuel, (int)r_FuelType);
        }

        public enum eTruckProperties
        {
            Firma = 1,
            IsCarryingDangerousGoods,
            MaxCarryWeight,
            CurrentCarryWeight
        }

        public enum eIsCarryingDengerousGoods
        {
            Yes = 1,
            No
        }

        public bool IsCarryingDangerousGoods
        {
            get { return m_IsCarryingDangerousGoods; }
            set { m_IsCarryingDangerousGoods = value; }
        }

        public float MaxCarryWeight
        {
            get { return m_MaxCarryingWeight; }
            set { m_MaxCarryingWeight = value; }
        }

        public float CurrentGoodsWeight
        {
            get { return m_CurrentGoodsWeight; }
            set
            {
                if (value > 0 && value <= m_MaxCarryingWeight)
                {
                    m_CurrentGoodsWeight = value;
                }
                else
                {
                    throw new ValueOutOfRangeException("The truck cannot carry more than maximum allowed", m_MaxCarryingWeight, 0);
                }
            }
        }

        public override Dictionary<int, string> GetVheicleProperties()
        {
            Dictionary<int, string> truckProperties = new Dictionary<int, string>();

            foreach (eTruckProperties property in Enum.GetValues(typeof(eTruckProperties)))
            {
                if (property == eTruckProperties.CurrentCarryWeight)
                {
                    truckProperties.Add((int)property, "Truck's Current Carring Weight ");
                }
                else if (property == eTruckProperties.Firma)
                {
                    truckProperties.Add((int)property, "Firma of Truck ");
                }
                else if (property == eTruckProperties.IsCarryingDangerousGoods)
                {
                    truckProperties.Add((int)property, genericEnumUserMsg<eIsCarryingDengerousGoods>("If Truck is Carrying Dangerous goods? "));
                }
                else
                { 
                    truckProperties.Add((int)property, property.ToString());
                }
            }

            return truckProperties;
        }

        public override void SetVehicleProperty(int i_Property, string i_InputFromUserStr)
        {
            eTruckProperties property = (eTruckProperties)i_Property;
            int parssedInputFromUser;
            float parssedInputFromUserFloat;

            switch (property)
            {
                case eTruckProperties.Firma:
                    {
                        base.Firma = i_InputFromUserStr;
                        break;
                    }

                case eTruckProperties.IsCarryingDangerousGoods:
                    {
                        if (int.TryParse(i_InputFromUserStr, out parssedInputFromUser))
                        {
                            if (parssedInputFromUser == 1)
                            {
                                IsCarryingDangerousGoods = true;
                            }
                            else if (parssedInputFromUser == 2)
                            {
                                IsCarryingDangerousGoods = false;
                            }
                            else
                            {
                                throw new FormatException("Got bad input!");
                            }
                        }
                        else
                        {
                            throw new FormatException("Got bad input!");
                        }

                        break;
                    }

                case eTruckProperties.MaxCarryWeight:
                    {
                        if (float.TryParse(i_InputFromUserStr, out parssedInputFromUserFloat))
                        {
                            MaxCarryWeight = parssedInputFromUserFloat;
                        }
                        else
                        {
                            throw new FormatException("Got bad input!");
                        }

                        break;
                    }

                case eTruckProperties.CurrentCarryWeight:
                    {
                        if (float.TryParse(i_InputFromUserStr, out parssedInputFromUserFloat))
                        {
                            CurrentGoodsWeight = parssedInputFromUserFloat;
                        }
                        else
                        {
                            throw new FormatException("Got bad input!");
                        }

                        break;
                    }
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendFormat("{1}Vehicle = Truck{0}{2}{0}{1}Carrying Dangerous Goods = {3}{0}{1}Maximum Carrying Weight = {4}{0}{1}Current Goods Weight = {5}{0}", Environment.NewLine, "\t", Engine.ToString(), m_IsCarryingDangerousGoods.ToString(), m_MaxCarryingWeight, m_CurrentGoodsWeight);
            return stringBuilder + base.ToString();
        }
    }
}
