using System;

namespace ConsoleApp7.View
{
    public class ConsoleDisplay : IDisplay
    {
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
                else messageToDisplay += "Your ship has been hit!";
            }
            else
            {
                messageToDisplay += "Fortunately it hit nothing...";
            }
            Console.WriteLine(messageToDisplay);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public void EndGameMessage(string winnerNick)
        {
            Console.Clear();
            Console.WriteLine($"{winnerNick} has was game! Congratulations!");
        }

        public void DisplaySwapPlayers(string enemyPlayerNick)
        {   Console.Clear(); 
            Console.WriteLine($"Time for {enemyPlayerNick}!\nClick any button to continue...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}