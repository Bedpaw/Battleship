using System;
using System.Runtime.CompilerServices;

namespace ConsoleApp7.Game
{
    public class Game
    {
        Player player1;
        Player player2;
        private Player AttackingPlayer;
        private Player DefendingPlayer;
        
        public Game(PlayerAI AIplayer)
        {
            AttackingPlayer = player1 = new ConsolePlayer();
            DefendingPlayer = player2 = AIplayer;
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
        private bool UpdateOceanAfterAttack(string attackedPosition)
        {    
            // update defendingPlayer.updateBoard(attackedPosition)
            // return True if shooted

            return false;
        }
        private bool IsNotEndGame()
        { 
            // return False if game end
            // else return True
            return true;
        }

        private void SwitchPLayers()
        {
            // Attacking = temp
            // Attacking = Defending
            // Defending = temp
            // a, b = b, a
        }

        private void DisplayAttackResults(string attackedPosition, bool attackResult /*,bool isHitAndSink*/)
        {
            bool isHitAndSink = false; // Mock, u need to get it in param
            
            // :TODO Check how to initialize Player with interface
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
            do
            {   
                string attackedPosition = AttackingPlayer.Attack();
                bool attackResult = UpdateOceanAfterAttack(attackedPosition);
                DisplayAttackResults(attackedPosition, attackResult);
                if (attackResult == false) SwitchPLayers();
            } while (IsNotEndGame());
        }
        

        public string DisplayEndGameMessage()
        {
            //return info about winner         
            return "Player 1 has won!";

        } 

    }
}