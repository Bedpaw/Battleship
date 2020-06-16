using ConsoleApp7.Board;
using ConsoleApp7.Players;
using ConsoleApp7.View;

namespace ConsoleApp7.Game.GameEngine
{
    public class Game
    {
        private Player AttackingPlayer { get; set; }
        private Player DefendingPlayer { get; set; }
        private IDisplay Display { get; }
        public Game( Player player1, Player player2, IDisplay display )
        {
            Display = display;
            AttackingPlayer = player1;
            DefendingPlayer = player2;
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
            Ocean.DisplayBothOceans(AttackingPlayer.PlayerBoard, DefendingPlayer.PlayerBoard);
            Display.DisplayAttackingResult(attackedPosition, attackResult, isHitAndSink);
            
            Display.DisplaySwapPlayers(DefendingPlayer.PlayerNick);
            
            Ocean.DisplayBothOceans(DefendingPlayer.PlayerBoard, AttackingPlayer.PlayerBoard);
            Display.DisplayDefendingResult(attackedPosition, attackResult, isHitAndSink);

        }
        public void GameLoopForPlayerVsPlayer() // Name to change GameLoop
        {
            bool isHitAndSink;
            do
            {   
                Display.DisplaySwapPlayers(AttackingPlayer.PlayerNick);
                Ocean.DisplayBothOceans(AttackingPlayer.PlayerBoard, DefendingPlayer.PlayerBoard);
                
                var attackedPosition = AttackingPlayer.Attack();
                var attackResult = DefendingPlayer.UpdateMyBoard(attackedPosition);
                
                var isAttackSuccess = attackResult[0];
                isHitAndSink = attackResult[1];
                
                DisplayAttackResults(attackedPosition, isAttackSuccess, isHitAndSink);
                if (isAttackSuccess == false) SwitchPLayers();
            } while (IsNotEndGame(isHitAndSink));
        }

        // public void GameLoopForPlayerVsComputer()
        // {
            // bool isHitAndSink = false;
            // do
            // {   ConsolePlayer.DisplaySwapPlayers(AttackingPlayer.PlayerNick); //always HumanPlayer hit first
                // Ocean.DisplayBothOceans(AttackingPlayer.PlayerBoard, playerCpu.PlayerBoard);
                
                // var attackedPosition = AttackingPlayer.Attack();
                // var convAttackPosToArr = utils.Utils.ConvertAttackedPositionToXY(attackedPosition);
                // var attackResult = playerCpu.UpdateMyBoard(convAttackPosToArr);
                
                // var isAttackSuccess = attackResult[0];
                // isHitAndSink = attackResult[1];
                
                // DisplayAttackResults(attackedPosition, isAttackSuccess, isHitAndSink);
                // if (isAttackSuccess == false) SwitchPLayers();
            // } while (IsNotEndGame(isHitAndSink));
        // }


        public void DisplayEndGameMessage() => Display.EndGameMessage(AttackingPlayer.PlayerNick);

    }
}