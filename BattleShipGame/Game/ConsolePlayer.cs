namespace ConsoleApp7.Game
{
    public class ConsolePlayer : Player, IDisplayingAttackResults
    {
        public override string Attack()
        {
            throw new System.NotImplementedException();
        }

        protected override void SetShips()
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