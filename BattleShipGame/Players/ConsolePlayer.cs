using System;
using System.Collections.Generic;
using ConsoleApp7.Board;
using ConsoleApp7.Game;
using ConsoleApp7.utils;

namespace ConsoleApp7.Players
{
    public class ConsolePlayer : Player, IDisplayingAttackResults
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
            /*SetShips(PlayerBoard);*/
        }
        
        public override string Attack()
        {
            string attackedPosition;
            
            DisplaySwapPlayers(PlayerNick);
            do
            {   Console.Clear();
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
            var attackedPositionXY = utils.utils.ConvertAttackedPositionToXY(attackedPosition);
            var attackResult = PlayerBoard.GetShot(attackedPositionXY);
            return attackResult;
        }
        

        public override bool IsFleetAlive()
        {
             return PlayerBoard.Fleet.Exists(ship => ship.IsSunk == false);
        }

        public void DisplayAttackingResult(string attackedPosition, bool attackResult, bool isHitAndSink)
        {
            var messageToDisplay = $"You shot into {attackedPosition}. ";
            
            if (attackResult)
            {
                if (isHitAndSink) messageToDisplay += "HIT AND SINK!";
                else messageToDisplay += "YOU HIT ENEMY SHIP!";
            }
            else
            {
                messageToDisplay += "You hit nothing...";
            }
            Console.WriteLine(messageToDisplay);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public void DisplayDefendingResult(string attackedPosition, bool attackResult, bool isHitAndSink)
        {
            var messageToDisplay = $"Enemy shot into {attackedPosition}. ";
            if (attackResult)
            {
                if (isHitAndSink) messageToDisplay += "Your ship has been drown!";
                else messageToDisplay += "You ship has been hit!";
            }
            else
            {
                messageToDisplay += "Fortunately it hit nothing...";
            }
            Console.WriteLine(messageToDisplay);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public static void DisplaySwapPlayers(string enemyPlayerNick)
        {   Console.Clear(); 
            Console.WriteLine($"Time for {enemyPlayerNick}!\nClick any button to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        public static void EndGameMessage(string WinnerNick)
        {
            Console.Clear();
            Console.WriteLine($"{WinnerNick} has was game! Congratulations!");
        }
    }
}