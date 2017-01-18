using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.ConsoleUI
{
    class Program
    {
        public static void Main()
        {
            Ex03.GarageLogic.ElectricCar eCar = new GarageLogic.ElectricCar("fiat", "123465",GarageLogic.Car.eNumOfDoors.three,GarageLogic.Car.eColor.blue);
            //Menu.RunMenu();
        }
    }
}
