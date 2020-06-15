using System;
using System.Collections.Generic;
using ConsoleApp7.Board;
using ConsoleApp7.Board.Ships;
using ConsoleApp7.utils;

namespace ConsoleApp7.Players
{
    public class ConsolePlayer : Player

    {
        private List<string> allPositionsAttackedByPlayer = new List<string>();

        public ConsolePlayer()
        {
            PlayerBoard = new Ocean(10, 10);

            Console.Clear();
            Console.WriteLine("Set your Nick: ");
            PlayerNick = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Set your Ships:");
            SetShips(PlayerBoard);
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

        protected override void SetShips(Ocean playerBoard)
        {
            ShipsCreation.AddFleetToPlayerBoard(playerBoard);
        }


        public override bool[] UpdateMyBoard(string attackedPosition)
        {
            var attackedPositionXY = Utils.ConvertAttackedPositionToXy(attackedPosition);
            var attackResult = PlayerBoard.GetShot(attackedPositionXY);
            return attackResult;
        }

        public override bool IsFleetAlive()
        {
            return PlayerBoard.Fleet.Exists(ship => ship.IsSunk == false);
        }
    }
}