﻿using System;
using System.Threading;
using ConsoleApp7.Interface;

namespace ConsoleApp7.View
{
    public class ConsoleDisplayAI: IDisplay
    {
        public IOceanDisplay DisplayOcean { get; set; } = new OceanNotDisplaying();

        public void DisplayAttackingResult(string attackedPosition, bool attackResult, bool isHitAndSink)
        {
            
        }

        public void DisplayDefendingResult(string attackedPosition, bool attackResult, bool isHitAndSink)
        {
    
        }

        public void EndGameMessage(string winnerNick)
        {
            Console.Clear();
            Console.WriteLine($"{winnerNick} has was game! Congratulations!");
        }

        public void DisplaySwapPlayers(string playerNick, bool isBetweenAttackResults)
        {
            if (!isBetweenAttackResults)
            {
                Console.Clear();
                Console.WriteLine($"{playerNick} is doing his move!");
                Thread.Sleep(1000);
            }
            Console.Clear();
        }
    }
}