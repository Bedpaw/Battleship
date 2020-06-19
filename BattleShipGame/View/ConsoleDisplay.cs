using System;
using ConsoleApp7.Interface;

namespace ConsoleApp7.View
{
    public class ConsoleDisplay : IDisplay
    {


        public IOceanDisplay DisplayOcean { get; set; } = new ConsoleOceanDisplay();

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

        public void DisplaySwapPlayers(string playerNick, bool isBetweenAttackResult)
        {
            var message = isBetweenAttackResult
                ? $"{playerNick} has been attacked!\nClick any button to continue..."
                : $"Time for {playerNick}!\nClick any button to continue...";
            
            Console.Clear(); 
            Console.WriteLine(message);
            Console.ReadKey();
            Console.Clear();
        }
    }
}