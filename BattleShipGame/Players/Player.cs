using System.Collections.Generic;

using ConsoleApp7.Board;

namespace ConsoleApp7.Game
{
    public abstract class Player
    {
        protected Ocean PlayerBoard;
        protected Ocean EnemyBoard;
        protected Player()
        {
            PlayerBoard = new Ocean(10, 10);
            EnemyBoard = new Ocean(10, 10);
            /*SetShips(PlayerBoard);*/
        }
        

        public abstract string Attack();
        protected abstract void SetShips(Ocean playerBoard);
        public abstract bool[] UpdateMyBoard(string attackedPosition);
        public abstract void UpdateEnemyBoard(string attackedPosition, IEnumerable<bool> attackResult);

        public abstract bool IsFleetAlive();
        
        
        
        
        
        
        // TODO This 2 function shouldn't be here, but error in game other way
        public void DisplayAttackingResult(string attackedPosition, in bool attackResult, in bool isHitAndSink)
        {
            throw new System.NotImplementedException();
        }

        public void DisplayDefendingResult(string attackedPosition, in bool attackResult, in bool isHitAndSink)
        {
            throw new System.NotImplementedException();
        }
    }
}