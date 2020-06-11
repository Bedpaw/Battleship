using System.Collections.Generic;
using ConsoleApp7.Board;
using ConsoleApp7.Interface;

namespace ConsoleApp7.Game
{
    public class WebPlayer : Player, IDisplayingAttackResults
    {
        public override string Attack()
        {
            throw new System.NotImplementedException();
        }

        protected override void SetShips(Ocean PlayerBoard)
        {
            throw new System.NotImplementedException();
        }

        public override bool[] UpdateMyBoard(string attackedPosition)
        {
            throw new System.NotImplementedException();
        }

        public override bool IsFleetAlive()
        {
            throw new System.NotImplementedException();
        }

        public void DisplayAttackingResult(string attackedPosition, bool attackResult, bool isHitAndSink)
        {
            throw new System.NotImplementedException();
        }

        public void DisplayDefendingResult(string attackedPosition, bool attackResult, bool isHitAndSink)
        {
            throw new System.NotImplementedException();
        }
    }

 
}