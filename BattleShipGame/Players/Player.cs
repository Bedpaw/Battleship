using ConsoleApp7.Board;

namespace ConsoleApp7.Players
{
    public abstract class Player
    {
        public Ocean PlayerBoard;
        public string PlayerNick;
        public abstract string Attack();
        protected abstract void SetShips(Ocean playerBoard);

        public abstract bool [] UpdateMyBoard(string attackPosition);

        public abstract bool IsFleetAlive();
        
        
    }
}