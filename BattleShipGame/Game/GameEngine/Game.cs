﻿using ConsoleApp7.Players;
using ConsoleApp7.View;

namespace ConsoleApp7.Game.GameEngine
{
    public class Game
    {
        private Player AttackingPlayer { get; set; }
        private Player DefendingPlayer { get; set; }
        public Game( Player player1, Player player2 )
        {
            AttackingPlayer = player1;
            DefendingPlayer = player2;
        }
        private bool IsNotEndGame(bool isHitAndSink)
        {   
            if (isHitAndSink) return DefendingPlayer.IsFleetAlive();
            return true;
        }
        private void SwitchPLayers()
        {
            var temp = AttackingPlayer;
            AttackingPlayer = DefendingPlayer;
            DefendingPlayer = temp;
        }

        private void DisplayAttackResults(string attackedPosition, bool attackResult, bool isHitAndSink)
        {
            ConsolePlayerBoardDisplay.DisplayBothOceans(AttackingPlayer.PlayerBoard, DefendingPlayer.PlayerBoard);
            AttackingPlayer.Display.DisplayAttackingResult(attackedPosition, attackResult, isHitAndSink);
            
            DefendingPlayer.Display.DisplaySwapPlayers(DefendingPlayer.PlayerNick, true);
            
            ConsolePlayerBoardDisplay.DisplayBothOceans(DefendingPlayer.PlayerBoard, AttackingPlayer.PlayerBoard);
            DefendingPlayer.Display.DisplayDefendingResult(attackedPosition, attackResult, isHitAndSink);

        }
        public void GameLoop()
        {
            bool isHitAndSink;
            do
            {   
                AttackingPlayer.Display.DisplaySwapPlayers(AttackingPlayer.PlayerNick);
                ConsolePlayerBoardDisplay.DisplayBothOceans(AttackingPlayer.PlayerBoard, DefendingPlayer.PlayerBoard);
                
                var attackedPosition = AttackingPlayer.Attack();
                
                var attackResult = DefendingPlayer.UpdateMyBoard(attackedPosition);
                
                var isAttackSuccess = attackResult[0];
                isHitAndSink = attackResult[1];
                
                AttackingPlayer.SaveAttackResults(attackedPosition, isAttackSuccess, isHitAndSink);
                
                DisplayAttackResults(attackedPosition, isAttackSuccess, isHitAndSink);
                
                if (isAttackSuccess == false) SwitchPLayers();
                
            } while (IsNotEndGame(isHitAndSink));
        }
        public void DisplayEndGameMessage() => AttackingPlayer.Display.EndGameMessage(AttackingPlayer.PlayerNick);

    }
}