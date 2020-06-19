using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleApp7.Board.Ships;
using ConsoleApp7.Board;
using ConsoleApp7.utils;
using ConsoleApp7.Utlis;
using ConsoleApp7.View;

namespace ConsoleApp7.Players
{

    public class PlayerAI : Player
    {
        private int _round; //ONLY FOR TESTS
        private List<int[]> UniqueShootsArray = new List<int[]>();
        private List<int []> PositionsOfHitShip { get; set; } = new List<int[]>();
        private bool IsShipHorizontal { get; set; }
        private bool ShipOrientationIsKnown => PositionsOfHitShip.Count > 1;
        private bool IsShipHitNotSink => PositionsOfHitShip.Count != 0;
        
        private enum Difficulty
        {
            Easy = 1,
            Medium = 2,
            Hard = 3
        }
        private Difficulty DifficultyLevel { get;}

        public PlayerAI(IDisplay display)
        {    
            PlayerBoard = new Ocean(10, 10);
            Display = display;
            DifficultyLevel = SetDifficultyLevel();
            PlayerNick = $"Computer {DifficultyLevel.ToString()}";
            SetShips(PlayerBoard);
        }
        public override string Attack()
        {
            switch (DifficultyLevel)
            {
                case Difficulty.Easy:
                    return EasyAttack();
                case Difficulty.Medium:
                    return MediumAttack();
                default:
                    return HardAttack();
            }
        }
        
        private string EasyAttack()
        {
            // Easy attack is totally random attack even though CPU hit into ship
            // it will still generate random positions
            var randomPositionsAttack = Utils.GenerateAndMakeUniqueRandomArray(UniqueShootsArray);
            return Utils.ConvertXYtoStringRepresentationOfCords(randomPositionsAttack);
        }

        private string MediumAttack()
        {
            //Medium attack randomly search for ship but when it hit into ship the ship will be
            //destroyed in less possible moves
            _round++;
            if (_round == 1) return "A1"; // ONLY FOR TESTS
            
            if (!IsShipHitNotSink) return EasyAttack();

            foreach (var shipPosition in PositionsOfHitShip)
            {
                var shipPos = new OceanFieldValidator(shipPosition, PlayerBoard, UniqueShootsArray);

                if (!ShipOrientationIsKnown) return shipPos.GetAsString(shipPos.GetValidFieldAround());

                if (IsShipHorizontal) if (shipPos.IsValidHorizontal) return shipPos.GetAsString(shipPos.GetValidHorizontal());
                if (!IsShipHorizontal) if (shipPos.IsValidVertical) return shipPos.GetAsString(shipPos.GetValidVertical());
            }
            return null;
        }
        private static string HardAttack()
        {
            //Hard attack follow algorithm and kill ship in less possible moves like medium
            return " ";
        }
        
        private static int GenerateOrientation() => Utils.GenerateRandomFromToRange(1, 2);

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
        private bool ReadOrientationFromLastShoots(int [] attackedPosition)
        {
            return PositionsOfHitShip[0][0] + 1 == attackedPosition[0] || PositionsOfHitShip[0][0] - 1 == attackedPosition[0];
        }
        protected override void SetShips(Ocean playerBoard)
        {
            var fleetForAi = ShipsCreation.CreateFleet();

            foreach (var shipAi in fleetForAi)
            {
                shipAi.Orientation = GenerateOrientation();
                shipAi.StartPositions = ShipFirstFieldPosition(shipAi); 
                playerBoard.AddNewShip(shipAi);
            }
        }
        public override bool[] UpdateMyBoard(string attackPosition)
        {
            var attackedPositionXy = Utils.ConvertAttackedPositionToXy(attackPosition);
            var attackResult = PlayerBoard.GetShot(attackedPositionXy);
            return attackResult;
        }
        
        public override void SaveAttackResults(string attackedPosition, bool isAttackSuccess, bool isHitAndSink)
        {
            var attackedPositionAsXy = Utils.ConvertAttackedPositionToXy(attackedPosition);
            attackedPositionAsXy = new [] {attackedPositionAsXy[1], attackedPositionAsXy[0]};
            UniqueShootsArray.Add(attackedPositionAsXy);
            
            if (isHitAndSink) PositionsOfHitShip = new List<int[]>();
                        
            else if (isAttackSuccess)
            {    
                PositionsOfHitShip.Add(attackedPositionAsXy);
                
                if (ShipOrientationIsKnown) return;
                IsShipHorizontal = ReadOrientationFromLastShoots(attackedPositionAsXy);
            }
        }

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
                    return Difficulty.Easy;
                case (int)Difficulty.Medium:
                    return Difficulty.Medium;
                case (int)Difficulty.Hard:
                    return Difficulty.Hard;
            }
            return Difficulty.Easy;
        }
    }
}