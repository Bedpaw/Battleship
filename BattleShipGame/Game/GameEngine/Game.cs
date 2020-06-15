using ConsoleApp7.Board;
using ConsoleApp7.Interface;
using ConsoleApp7.Players;

namespace ConsoleApp7.Game.GameEngine
{
    public class Game
    {

        private PlayerAI playerCpu;
        private ConsolePlayer AttackingPlayer;
        private ConsolePlayer DefendingPlayer;
        
        public Game(PlayerAI AIplayer)
        {
            AttackingPlayer =  new ConsolePlayer();
            playerCpu = AIplayer;
        }
        public Game()
        {
            AttackingPlayer = new ConsolePlayer(); 
            ConsolePlayer.DisplaySwapPlayers("next player");
            DefendingPlayer = new ConsolePlayer();
        }
        public Game(WebPlayer player)
        {
            // :TODO
        }
        private bool IsNotEndGame(bool isHitAndSink)
        {   
            if (isHitAndSink) return DefendingPlayer.IsFleetAlive();
            return true;
        }

        private void SwitchPLayers()
        {
            var temp = AttackingPlayer;
            AttackingPlayer = DefendingPlayer;
            DefendingPlayer = temp;
        }

        private void DisplayAttackResults(string attackedPosition, bool attackResult, bool isHitAndSink)
        {
            if (AttackingPlayer is IDisplayingAttackResults)
            {   
                Ocean.DisplayBothOceans(AttackingPlayer.PlayerBoard, DefendingPlayer.PlayerBoard);
                AttackingPlayer.DisplayAttackingResult(attackedPosition, attackResult, isHitAndSink);
            }
            if (DefendingPlayer is IDisplayingAttackResults)
            {
                ConsolePlayer.DisplaySwapPlayers(DefendingPlayer.PlayerNick); // Only for console -> to change in future
                Ocean.DisplayBothOceans(DefendingPlayer.PlayerBoard, AttackingPlayer.PlayerBoard);
                DefendingPlayer.DisplayDefendingResult(attackedPosition, attackResult, isHitAndSink);
                
            }
        }
        public void GameLoopForPlayerVsPlayer()
        {
            bool isHitAndSink;
            do
            {   ConsolePlayer.DisplaySwapPlayers(AttackingPlayer.PlayerNick);
                Ocean.DisplayBothOceans(AttackingPlayer.PlayerBoard, DefendingPlayer.PlayerBoard);
                
                var attackedPosition = AttackingPlayer.Attack();
                var attackResult = DefendingPlayer.UpdateMyBoard(attackedPosition);
                
                var isAttackSuccess = attackResult[0];
                isHitAndSink = attackResult[1];
                
                DisplayAttackResults(attackedPosition, isAttackSuccess, isHitAndSink);
                if (isAttackSuccess == false) SwitchPLayers();
            } while (IsNotEndGame(isHitAndSink));
        }

        public void GameLoopForPlayerVsComputer()
        {
            bool isHitAndSink;
            do
            {   ConsolePlayer.DisplaySwapPlayers(AttackingPlayer.PlayerNick); //always HumanPlayer hit first
                Ocean.DisplayBothOceans(AttackingPlayer.PlayerBoard, playerCpu.PlayerBoard);
                
                var attackedPosition = AttackingPlayer.Attack();
                var convAttackPosToArr = utils.Utils.ConvertAttackedPositionToXY(attackedPosition);
                var attackResult = playerCpu.UpdateMyBoard(convAttackPosToArr);
                
                var isAttackSuccess = attackResult[0];
                isHitAndSink = attackResult[1];
                
                DisplayAttackResults(attackedPosition, isAttackSuccess, isHitAndSink);
                if (isAttackSuccess == false) SwitchPLayers();
            } while (IsNotEndGame(isHitAndSink));
        }


        public void DisplayEndGameMessage() => ConsolePlayer.EndGameMessage(AttackingPlayer.PlayerNick);

    }
}