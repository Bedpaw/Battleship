using System;
using System.Collections;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleApp7.Board.ShipType;

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
        
        public static string AskForOrientation() // HA GAY!
        {
            WriteLine("Please select orientation: ");
            WriteLine("1. Verctical ");
            WriteLine("2. Horizontal ");
            string input = ReadLine().ToLower();
            return input;
            
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
        public static int[] initPoints()
        {
            
            //TODO
            //Dopisać funkcje walidujące i sprawdzić to przed returnem;
            int [] points = new int[2];
            WriteLine("Please select TOP-LEFT field: ");
            WriteLine("Position X: ");
            points[0] = Convert.ToInt32(ReadLine());
            WriteLine("Position X: ");
            points[1] = Convert.ToInt32(ReadLine());
            return points;
        }

        public static Ship instaceShip(int value)
        {
            switch (value)
            {
                case 1:
                    return new Battleship();
                case 2:
                    return new Carrier();
                case 3: 
                    return new Destroyer();
                case 4:
                    return new Submarine();
                default:
                    // BackgroundColor("Red");
                    WriteLine("Error");
                    break;
            }
        }
        
        public static Ship CreateShip ()
        {
            int chooseShip = ShipSelection();
            Ship newShip = instaceShip(chooseShip);
            newShip.Orientation = AskForOrientation();
            newShip.StartPositions = initPoints();

            return newShip;
        }

 
    }
}