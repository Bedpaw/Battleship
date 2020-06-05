﻿using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using ConsoleApp7.Players;

namespace ConsoleApp7.Game
{
    public class Game
    {
        ConsolePlayer player1;
        ConsolePlayer player2;
        private ConsolePlayer AttackingPlayer;
        private ConsolePlayer DefendingPlayer;
        
        public Game(PlayerAI AIplayer)
        {
            AttackingPlayer = player1 = new ConsolePlayer();
            // DefendingPlayer = player2 = AIplayer;
        }
        public Game()
        {
            AttackingPlayer = player1 = new ConsolePlayer(); 
            ConsolePlayer.DisplaySwapPlayers("next player");
            DefendingPlayer = player2 = new ConsolePlayer();
        }
        public Game(WebPlayer player)
        {
            // :TODO
        }
        private bool IsNotEndGame(bool isHitAndSink)
        {   
            if (isHitAndSink) return DefendingPlayer.IsFleetAlive();
            else return true;
        }

        private void SwitchPLayers()
        {
            var temp = AttackingPlayer;
            AttackingPlayer = DefendingPlayer;
            DefendingPlayer = temp;
        }

        private void DisplayAttackResults(string attackedPosition, bool attackResult, bool isHitAndSink)
        {
            if (AttackingPlayer is IDisplayingAttackResults)
            {   Console.WriteLine($"Display {AttackingPlayer.PlayerNick} board..."); //Display both oceans (AttackingPlayer.board, DefendingPlayer.boar)
                AttackingPlayer.DisplayAttackingResult(attackedPosition, attackResult, isHitAndSink);
            }
            if (DefendingPlayer is IDisplayingAttackResults)
            {
                ConsolePlayer.DisplaySwapPlayers(DefendingPlayer.PlayerNick); // Only for console -> to change in future
                Console.WriteLine($"Display {DefendingPlayer.PlayerNick} board...");//Display both oceans (AttackingPlayer.board, DefendingPlayer.boar)
                DefendingPlayer.DisplayDefendingResult(attackedPosition, attackResult, isHitAndSink);
                
            }
        }
        public void GameLoop()
        {
            bool isHitAndSink;
            do
            {   
                var attackedPosition = AttackingPlayer.Attack();
                var attackResult = DefendingPlayer.UpdateMyBoard(attackedPosition);
                
                var isAttackSuccess = attackResult[0];
                isHitAndSink = attackResult[1];
                
                DisplayAttackResults(attackedPosition, isAttackSuccess, isHitAndSink);
                if (isAttackSuccess == false) SwitchPLayers();
            } while (IsNotEndGame(isHitAndSink));
        }


        public void DisplayEndGameMessage() => ConsolePlayer.EndGameMessage(AttackingPlayer.PlayerNick);

    }
}