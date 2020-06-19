namespace ConsoleApp7.View
{
    public interface IDisplay
    {
        public IOceanDisplay DisplayOcean { get; set; }
        public void DisplayAttackingResult(string attackedPosition, bool attackResult, bool isHitAndSink);
        
        public void DisplayDefendingResult(string attackedPosition, bool attackResult, bool isHitAndSink);
        
        public void EndGameMessage(string winnerNick);

        public void DisplaySwapPlayers(string enemyPlayerNick, bool isBetweenAttackResults = false);
        
    }
}