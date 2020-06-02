using System.Collections.Generic;

namespace ConsoleApp7.Game
{
    public abstract class Player
    {
        /*private Board PlayerBoard = new Board();*/

        protected Player()
        {
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