using System;
using System.Collections.Generic;
using ConsoleApp7.Board;
using ConsoleApp7.Board.Ships;
using ConsoleApp7.utils;
using ConsoleApp7.View;

namespace ConsoleApp7.Players
{
    public class ConsolePlayer : Player

    {
        private List<string> allPositionsAttackedByPlayer = new List<string>();
        public ConsolePlayer(IDisplay display)
        {
            PlayerBoard = new Ocean(10, 10);
            Display = display;
            Console.Clear();
            Console.WriteLine("Set your Nick: ");
            PlayerNick = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Set your Ships:");
            SetShips(PlayerBoard, display.DisplayOcean);
        }

        public override string Attack()
        {
            string attackedPosition;
            do
            {
                Console.WriteLine($"{PlayerNick}, please input position to attack: ");
                attackedPosition = Console.ReadLine()?.ToUpper();

            } while (Validation.IsProperAttackPosition(attackedPosition, allPositionsAttackedByPlayer) == false);

            allPositionsAttackedByPlayer.Add(attackedPosition);
            return attackedPosition;
        }
        

        protected override void SetShips(Ocean playerBoard, IOceanDisplay displayOcean)
        {
            ShipsCreation.AddFleetToPlayerBoard(playerBoard, displayOcean);
        }


        public override bool[] UpdateMyBoard(string attackedPosition)
        {
            var attackedPositionXy = Utils.ConvertAttackedPositionToXy(attackedPosition);
            var attackResult = PlayerBoard.GetShot(attackedPositionXy);
            return attackResult;
        }
        
        public override void SaveAttackResults(string attackedPosition, bool isAttackSuccess, bool isHitAndSink)
        {
            
        }
        
    }
}