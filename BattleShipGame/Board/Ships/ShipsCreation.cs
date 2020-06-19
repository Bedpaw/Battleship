using System.Collections.Generic;
using ConsoleApp7.Board.Ships.ShipType;
using ConsoleApp7.utils;
using static System.Console;

namespace ConsoleApp7.Board.Ships
{
    public static class ShipsCreation
    {
        public static List<Ship> CreateFleet()
        {
            return new List<Ship>
            {
                new Destroyer(),
                // new Submarine(),
                // new Battleship(),
                // new Carrier()
            };
            
        }
    }
}