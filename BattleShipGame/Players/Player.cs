using System.Collections.Generic;

using ConsoleApp7.Board;

namespace ConsoleApp7.Game
{
    public abstract class Player
    {
        private Ocean PlayerBoard;
        protected Player()
        {
            PlayerBoard = new Ocean(10, 10);
            SetShips();
        } 
        public abstract string Attack();
        protected abstract void SetShips();


        public void DisplayDefendingResult(string attackedPosition, in bool attackResult, in bool isHitAndSink)
        {
            throw new System.NotImplementedException();
        }

        public void DisplayAttackingResult(string attackedPosition, in bool attackResult, in bool isHitAndSink)
        {
            throw new System.NotImplementedException();
        }
    }
}