using System;
using System.Collections;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using ConsoleApp7.Board.ShipType;
using ConsoleApp7.Players;

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
            int [] points = new int[2];
            WriteLine("Please select TOP-LEFT field: ");
            WriteLine("Position X: ");
            points[0] = Convert.ToInt32(ReadLine());
            WriteLine("Position Y: ");
            points[1] = Convert.ToInt32(ReadLine());
            // WriteLine($"{points[0]} | {points[1]}");
            return points;
        }

        public static List<Ship> CreateFleet()
        {
            var arrayShips = new List<Ship>
            {
                new Battleship(),
                new Carrier(),
                new Destroyer(),
                new Submarine(),
            };
            WriteLine("Arrrayyship");
            WriteLine(arrayShips.Count);

            return arrayShips;
        }

        public static void AddFleetToPlayerBoard(Ocean playerBoard)
        {
            var fleet = CreateFleet();

            foreach (var ship in fleet)
            {
                
                ship.Orientation = AskForOrientation();
                Console.WriteLine("OOOOOOOOOOOOOOOO");
                ship.StartPositions = ShipStartPoint(playerBoard, ship.Size);
                Console.WriteLine($"{ship.Name}");
                playerBoard.AddNewShip(ship);
            }
        }
        
    }
}