using ConsoleApp7.Board;
using ConsoleApp7.Game;

namespace ConsoleApp7.Players
{
    public class PlayerAI : Player
    {
        public string DifficultyLevel { get;}

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

        public override bool[] UpdateMyBoard(string attackedPosition)
        {
            throw new System.NotImplementedException();
        }

        public override bool IsFleetAlive()
        {
            throw new System.NotImplementedException();
        }

        private string SetDifficultyLevel()
        {
            return "MEDIUM";
        }
    }
}