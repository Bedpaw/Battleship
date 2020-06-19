using System;
using System.Collections.Generic;
using ConsoleApp7.Board;
using ConsoleApp7.Board.Ships;
using ConsoleApp7.Interface;
using ConsoleApp7.utils;

namespace ConsoleApp7.Players
{
    public class ConsolePlayer : Player
    {
        private List<string> AllPositionsAttackedByPlayer { get; set; }= new List<string>();
        
        public ConsolePlayer(IDisplay display)
        {
            PlayerBoard = new Ocean(10, 10);
            Display = display;
            PlayerNick = SetNick();
            SetShips(PlayerBoard, display.DisplayOcean);
        }

        public override string Attack()
        {
            string attackedPosition;
            do
            {
                Console.WriteLine($"{PlayerNick}, please input position to attack: ");
                attackedPosition = Console.ReadLine()?.ToUpper();

            } while (Validation.IsProperAttackPosition(attackedPosition, AllPositionsAttackedByPlayer) == false);
            
            return attackedPosition;
        }
        protected override void SetShips(Ocean playerBoard, IOceanDisplay displayOcean)
        {
            var fleet = ShipsCreation.CreateFleet();
  
            foreach (var ship in fleet)
            {  
                Console.Clear();
                displayOcean.MyOcean(playerBoard);
                Console.WriteLine($"Set {ship.Name} which has size on board: {ship.Size}");
                ship.Orientation = AskForOrientation();
                
                ship.StartPositions = ShipStartPoint(playerBoard, ship);
                playerBoard.AddNewShip(ship);
            }
        }
        public override bool[] UpdateMyBoard(string attackedPosition)
        {
            var attackedPositionXy = Utils.ConvertAttackedPositionToXy(attackedPosition);
            var attackResult = PlayerBoard.GetShot(attackedPositionXy);
            
            return attackResult;
        }
        
        public override void SaveAttackResults(string attackedPosition, bool isAttackSuccess, bool isHitAndSink)
        {
            AllPositionsAttackedByPlayer.Add(attackedPosition);
        }
        private static int AskForOrientation()
        {
            string input;
            do
            {
                Console.WriteLine("Please select orientation: ");
                Console.WriteLine("1. Vertical "); 
                Console.WriteLine("2. Horizontal ");
                input = Console.ReadLine();
            } while (input != "1" && input != "2");
            return Convert.ToInt32(input);
        }
        private static int[] ShipStartPoint(Ocean playerBoard, Ship ship)
        {
            string startPosition;
            do
            {   
                Console.WriteLine("Please select TOP-LEFT field: ");
                startPosition = Console.ReadLine()?.ToUpper();
                
            } while (Validation.IsProperStartPosition(startPosition, playerBoard, ship) == false);

            return Utils.ConvertAttackedPositionToXy(startPosition);
        }
        
        private static string SetNick()
        { 
            Console.Clear();
            Console.WriteLine("Set your Nick: ");
            return Console.ReadLine();
        }
    }
}