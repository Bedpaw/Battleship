using System;
using System.Collections.Generic;
using ConsoleApp7.Game;
using ConsoleApp7.utils;

namespace ConsoleApp7.Players
{
    public class ConsolePlayer : Player, IDisplayingAttackResults
    {   
        private List<string> allPositionsAttackedByPlayer = new List<string>();  
        
        public override string Attack()
        {
            string attackedPosition;
            
            do
            {   Console.WriteLine("Please input position to attack: "); 
                attackedPosition = Console.ReadLine();
                
            } while (Validation.IsProperAttackPosition(attackedPosition, allPositionsAttackedByPlayer) == false);
            
            allPositionsAttackedByPlayer.Add(attackedPosition);
            return attackedPosition;
        }

        protected override void SetShips()
        {
            throw new System.NotImplementedException();
        }

        public void DisplayAttackingResult(string attackedPosition, bool attackResult, bool isHitAndSink)
        {
            var messageToDisplay = $"You shot into {attackedPosition}.\n";
            
            if (attackResult)
            {
                if (isHitAndSink) messageToDisplay += "HIT AND SINK!";
                else messageToDisplay += "YOU HIT ENEMY SHIP!";
            }
            else
            {
                messageToDisplay += "You hit nothing...";
            }
            Console.Write(messageToDisplay);
        }

        public void DisplayDefendingResult(string attackedPosition, bool attackResult, bool isHitAndSink)
        {
            var messageToDisplay = $"Enemy shot into {attackedPosition}.\n";
            if (attackResult)
            {
                if (isHitAndSink) messageToDisplay += "Your ship has been drown!";
                else messageToDisplay += "You ship has been hit!";
            }
            else
            {
                messageToDisplay += "Fortunately it hit nothing...";
            }
            Console.Write(messageToDisplay);
        }
    }
}