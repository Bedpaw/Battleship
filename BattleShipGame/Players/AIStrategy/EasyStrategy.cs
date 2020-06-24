using ConsoleApp7.Board;
using ConsoleApp7.utils;

namespace ConsoleApp7.Players
{
    public class EasyStrategy : AiAttackStrategy
    {
        public override string Attack()
        {
            // Easy attack is totally random attack even though CPU hit into ship
            // it will still generate random positions
            
            var randomPositionsAttack = Utils.GenerateAndMakeUniqueRandomArray(UniqueShootsArray);
            return Utils.ConvertXYtoStringRepresentationOfCords(randomPositionsAttack);
        }

        public EasyStrategy(Ocean playerBoard) : base(playerBoard)
        {
        }
    }
}