using System;
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
            DefendingPlayer = player2 = new ConsolePlayer();
        }
        public Game(WebPlayer player)
        {
            // :TODO
        }

        private bool[] UpdateOceansAfterAttack(string attackedPosition)
        {
            var attackResult = DefendingPlayer.UpdateMyBoard(attackedPosition);
            AttackingPlayer.UpdateEnemyBoard(attackedPosition, attackResult); // Do we need?

            return attackResult;
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
            {
                AttackingPlayer.DisplayAttackingResult(attackedPosition, attackResult, isHitAndSink);
            }
            if (DefendingPlayer is IDisplayingAttackResults)
            {
                DefendingPlayer.DisplayDefendingResult(attackedPosition, attackResult, isHitAndSink);
            }
        }
        public void GameLoop()
        {
            bool isHitAndSink;
            do
            {   
                var attackedPosition = AttackingPlayer.Attack();
               
                var attackResult = UpdateOceansAfterAttack(attackedPosition);
                var isAttackSuccess = attackResult[0];
                isHitAndSink = attackResult[1];
                
                DisplayAttackResults(attackedPosition, isAttackSuccess, isHitAndSink);
                
                if (isAttackSuccess == false) SwitchPLayers();
            } while (IsNotEndGame(isHitAndSink));
        }
        

        public string DisplayEndGameMessage()
        {
            //return info about winner         
            return "AttackingPlayer has won!";

        } 

    }
}