using ConsoleApp7.Board;

namespace ConsoleApp7.Players
{
    public class WebPlayer : Player
    {
        public override string Attack()
        {
            throw new System.NotImplementedException();
        }

        protected override void SetShips(Ocean playerBoard)
        {
            throw new System.NotImplementedException();
        }

        public override bool[] UpdateMyBoard(string attackPosition)
        {
            throw new System.NotImplementedException();
        }
        
        public override void SaveAttackResults(string attackedPosition, bool isAttackSuccess, bool isHitAndSink)
        {
            throw new System.NotImplementedException();
        }
    }

 
}