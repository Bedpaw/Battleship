using System;
using System.Collections;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp7.Board
{
    public class ShipsCreation
    {
        enum AvailableShips
        {
            Destroyer,
            Submarine,
            Battleship,
            Carrier,
        }
        public static int ShipSelection()
        {
           
                WriteLine("Please Select one of the ship you want to place on Ocean");
                WriteLine("1. Destroyer");
                WriteLine("2. Submarine");
                WriteLine("3. Battleship");
                WriteLine("4. Carrier");
                int selector;
                do
                {
                    string input = ReadLine();
                    selector = Convert.ToInt32(input);
                    
                } while (selector< 1 || selector>4);

                return selector;
        }
    }
}