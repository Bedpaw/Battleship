using System;
using ConsoleApp7.Board.Ships;
using ConsoleApp7.Board;
using ConsoleApp7.Interface;
using ConsoleApp7.utils;

namespace ConsoleApp7.Players
{

    public class PlayerAi : Player
    {
        private enum Difficulty
        {
            Easy = 1,
            Medium = 2,
            Hard = 3
        }
        private Difficulty DifficultyLevel { get;}
        private AiAttackStrategy AiStrategy { get; set; }
        public PlayerAi(IDisplay display)
        {
            PlayerBoard = new Ocean(10, 10);
            Display = display;
            DifficultyLevel = SetDifficultyLevel();
            PlayerNick = $"Computer {DifficultyLevel.ToString()}";
            SetShips(PlayerBoard, Display.DisplayOcean);
        }

        public override string Attack() => AiStrategy.Attack();
        
        public override bool[] UpdateMyBoard(string attackPosition)
        {
            var attackedPositionXy = Utils.ConvertAttackedPositionToXy(attackPosition);
            var attackResult = PlayerBoard.GetShot(attackedPositionXy);
            return attackResult;
        }
        
        public override void SaveAttackResults(string attackedPosition, bool isAttackSuccess, bool isHitAndSink)
        {
            AiStrategy.SaveAttackResults(attackedPosition, isAttackSuccess, isHitAndSink);
        }
        protected override void SetShips(Ocean playerBoard, IOceanDisplay oceanDisplay)
        {
            var fleetForAi = ShipsCreation.CreateFleet();

            foreach (var shipAi in fleetForAi)
            {
                shipAi.Orientation = GenerateOrientation();
                shipAi.StartPositions = ShipFirstFieldPosition(shipAi); 
                playerBoard.AddNewShip(shipAi);
            }
        }
        private int [] ShipFirstFieldPosition(Ship shipToCheck)
        {
            var posXy = new int[2];
            do
            {
                posXy[0] = Utils.GenerateRandomFromToRange();
                posXy[1] = Utils.GenerateRandomFromToRange();
            } while (!Validation.IsSpaceForShip(posXy, PlayerBoard, shipToCheck));
            
            return posXy;
        }
        private static int GenerateOrientation() => Utils.GenerateRandomFromToRange(1, 2);
        private static void PrintDifficultyOptionsToSelect()
        {
            Console.Clear();
            Console.WriteLine("Choose difficulty level for computer you want to play with: ");
            Console.WriteLine("1. Easy");
            Console.WriteLine("2. Medium");
            Console.WriteLine("3. Hard");
        }

        private static int GetDifficultyOptionFromPlayer()
        {
            var input = Console.ReadLine();
            Int32.TryParse(input, out var number);
            Console.Clear();
            return number;
        }
        
        private Difficulty SetDifficultyLevel()
        {
            PrintDifficultyOptionsToSelect();
            var chosenDifficultyOption = GetDifficultyOptionFromPlayer();
            switch (chosenDifficultyOption)
            { 
                case (int)Difficulty.Easy:
                    AiStrategy = new EasyStrategy(PlayerBoard);
                    return Difficulty.Easy;
                case (int)Difficulty.Medium:
                    AiStrategy = new MediumStrategy(PlayerBoard);
                    return Difficulty.Medium;
                case (int)Difficulty.Hard:
                    AiStrategy = new HardStrategy(PlayerBoard);
                    return Difficulty.Hard;
            }
            return Difficulty.Easy;
        }
    }
}