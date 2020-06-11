using System;
using System.Collections.Generic;
using ConsoleApp7.Board.Ships.ShipType;
using ConsoleApp7.utils;
using static System.Console;

namespace ConsoleApp7.Board.Ships
{
    public static class ShipsCreation
    {
        private static int AskForOrientation()
        {
            string input;
            do
            {
                WriteLine("Please select orientation: ");
                WriteLine("1. Vertical ");
                WriteLine("2. Horizontal ");
                input = ReadLine();
            } while (input != "1" && input != "2");
            return Convert.ToInt32(input);
            
        }

        private static int[] ShipStartPoint(Ocean playerBoard, Ship ship)
        {
            string startPosition;
            do
            {   
                WriteLine("Please select TOP-LEFT field: ");
                startPosition = ReadLine()?.ToUpper();
                
            } while (Validation.IsProperStartPosition(startPosition, playerBoard, ship) == false);

            return Utils.ConvertAttackedPositionToXY(startPosition);
        }
        private static List<Ship> CreateFleet()
        {
            var arrayShips = new List<Ship>
            {
                new Destroyer(),
                new Submarine(),
                /*new Battleship(),
                new Carrier()*/
            };

            return arrayShips;
        }
        public static void AddFleetToPlayerBoard(Ocean playerBoard)
        {
            var fleet = CreateFleet();

            foreach (var ship in fleet)
            {  
                Clear(); 
                playerBoard.DisplayMyOcean(playerBoard);
                WriteLine($"Set {ship.Name} which has size on board: {ship.Size}");
                
                ship.Orientation = AskForOrientation();
                ship.StartPositions = ShipStartPoint(playerBoard, ship);
                playerBoard.AddNewShip(ship);
            }
        }
        
    }
}