using ConsoleApp7.Board;

namespace ConsoleApp7.Game
{
    public class PlayerAI : Player
    {
        private string DifficultyLevel;
        
        public PlayerAI()
        {
            DifficultyLevel = SetDifficultyLevel();
        }
        
        public override string Attack()
        {
            throw new System.NotImplementedException();
        }
        
        protected override void SetShips(Ocean PlayerBoard)
        {
            throw new System.NotImplementedException();
        }

        private string SetDifficultyLevel()
        {
            return "MEDIUM";
        }
    }
}