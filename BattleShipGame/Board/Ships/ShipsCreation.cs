using System;
using System.Collections;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using ConsoleApp7.Board.ShipType;
using ConsoleApp7.Players;
using ConsoleApp7.utils;

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
        
        public static int AskForOrientation() // HA GAY!
        {
            WriteLine("Please select orientation: ");
            WriteLine("1. Verctical ");
            WriteLine("2. Horizontal ");
            int input = Convert.ToInt32(ReadLine());
            return input;
            
        }

        public static int[] ShipStartPoint(Ocean playerBoard, int shipSize)
        {
            //TODO
            //Dopisać funkcje walidujące i sprawdzić to przed returnem;
            
            
            string startPosition;
            do
            {   
                WriteLine("Please select TOP-LEFT field: ");
                startPosition = ReadLine()?.ToUpper();
                
            } while (Validation.IsProperStartPosition(startPosition, playerBoard) == false);

            return utils.utils.ConvertAttackedPositionToXY(startPosition);


        }

        public static List<Ship> CreateFleet()
        {
            var arrayShips = new List<Ship>
            {
                new Destroyer(),
                new Submarine(),
                new Battleship(),
                new Carrier()
            };

            return arrayShips;
        }

        public static void AddFleetToPlayerBoard(Ocean playerBoard)
        {
            var fleet = CreateFleet();

            foreach (var ship in fleet)
            {
                playerBoard.DisplayMyOcean(playerBoard);
                WriteLine($"Set {ship.Name} which has size on board: {ship.Size}");
                ship.Orientation = AskForOrientation();
                ship.StartPositions = ShipStartPoint(playerBoard, ship.Size);
                WriteLine($" You set {ship.Name} in {ship.StartPositions[0]} {ship.StartPositions[1]}");
                playerBoard.AddNewShip(ship);
            }
        }
        
    }
}