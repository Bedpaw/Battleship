using ConsoleApp7.Board;
using ConsoleApp7.Interface;
using ConsoleApp7.View;

namespace ConsoleApp7.Players
{
    public abstract class Player
    {
        public IDisplay Display; 
        public Ocean PlayerBoard;
        public string PlayerNick;
        public abstract string Attack();
        protected abstract void SetShips(Ocean playerBoard, IOceanDisplay oceanDisplay);

        public abstract bool [] UpdateMyBoard(string attackPosition);

        public bool IsFleetAlive() => PlayerBoard.Fleet.Exists(ship => ship.IsSunk == false);
        
        public abstract void SaveAttackResults(string attackedPosition, bool isAttackSuccess, bool isHitAndSink);

    }
}