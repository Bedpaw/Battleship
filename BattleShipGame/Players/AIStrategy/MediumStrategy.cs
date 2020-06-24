using System.Buffers.Text;
using ConsoleApp7.Board;

namespace ConsoleApp7.Players
{
    public class MediumStrategy : AiAttackStrategy
    {
        private EasyStrategy EasyAttack { get; set; }
        public override string Attack()
        {
            //Medium attack randomly search for ship but when it hit into ship the ship will be
            //destroyed in less possible moves

            if (!IsShipHitNotSink) return EasyAttack.Attack();
            return KillShipIfShoot();
        }
        public MediumStrategy(Ocean playerBoard) : base(playerBoard)
        {
            EasyAttack = new EasyStrategy(playerBoard);
        }
    }
}