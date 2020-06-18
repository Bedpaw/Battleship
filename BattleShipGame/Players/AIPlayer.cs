using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleApp7.Board.Ships;
using ConsoleApp7.Board;
using ConsoleApp7.utils;

namespace ConsoleApp7.Players
{

    public class PlayerAI : Player
    {
        private List<int[]> UniqueShootsArray = new List<int[]>();
        private bool IsShipHorizontal { get; set; }
        private bool ShipOrientationIsKnown => PositionsOfHitShip.Count > 1;
        
        private List<int []> PositionsOfHitShip { get; set; }
        private bool IsShipHitNotSink => PositionsOfHitShip.Count != 0;


        public PlayerAI()
        {
            PlayerBoard = new Ocean(10, 10);
            DifficultyLevel = SetDifficultyLevel();
            PlayerNick = $"Computer {Difficulty.Easy.ToString()}";
            SetShips(PlayerBoard);
        }

        private enum Difficulty
        {
            Easy = 1,
            Medium = 2,
            Hard = 3
        }
        private Difficulty DifficultyLevel { get;}

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
            var randomPositionsAttack = GenerateAndMakeUniqueRandomArray(UniqueShootsArray);
            return Utils.ConvertXYtoStringRepresentationOfCords(randomPositionsAttack);
        }

        private string MediumAttack()
        {
            //Medium attack randomly search for ship but when it hit into ship the ship will be
            //destroyed in less possible moves

            if (!IsShipHitNotSink) return EasyAttack();
            
            int[] positionToAttack = new int [2];
            // Doesn't work yet, have to check 'contains'
            foreach (var shitPosition in PositionsOfHitShip)
            {
                var x = shitPosition[0];
                var y = shitPosition[1];

                var up = new[] {x, y - 1};
                var down = new[] {x, y + 1};
                var left = new[] {x - 1, y};
                var right = new[] {x + 1, y};

                var checkRight = Validation.IsFieldInBoardWidth(PlayerBoard, x + 1);
                var checkUp = Validation.IsFieldInBoardHeight(PlayerBoard, y - 1);
                var checkDown = Validation.IsFieldInBoardHeight(PlayerBoard, y + 1);

                if (ShipOrientationIsKnown)
                    positionToAttack = IsShipHorizontal
                        ? checkRight
                            ? right
                            : left
                        : checkDown
                            ? down
                            : up;
                else
                {
                    if (checkUp) positionToAttack = up;
                    else if (checkDown) positionToAttack = down;
                    else if (checkRight) positionToAttack = right;
                    else positionToAttack = left;
                }
            }
            return Utils.ConvertXYtoStringRepresentationOfCords(positionToAttack);

        }

        private static string HardAttack()
        {
            //Hard attack follow algorithm and kill ship in less possible moves like medium
            return " ";
        }

        private static int[] GenerateAndMakeUniqueRandomArray(List<int[]> listOfItems)
        {
            var arrOfRandNums = new int [2];
            do
            {
                arrOfRandNums[0] = Utils.GenerateRandomFromToRange();
                arrOfRandNums[1] = Utils.GenerateRandomFromToRange();
            } while (listOfItems.Contains(arrOfRandNums));
            listOfItems.Add(arrOfRandNums);
            return arrOfRandNums;
        }

        private static int GenerateOrientation() => Utils.GenerateRandomFromToRange(1, 2);

        private int [] ShipFirstFieldPosition(Ship shipToCheck)
        {
            var posXY = new int[2];
            do
            {
                posXY[0] = Utils.GenerateRandomFromToRange();
                posXY[1] = Utils.GenerateRandomFromToRange();
            } while (!Validation.IsSpaceForShip(posXY, PlayerBoard, shipToCheck));
            
            return posXY;
        }

        private bool ReadOrientatationFromLastShoots(int [] attackedPosition)
        {
            return PositionsOfHitShip[0][0] + 1 == attackedPosition[0] || PositionsOfHitShip[0][0] - 1 == attackedPosition[0];
        }
        
        protected override void SetShips(Ocean playerBoard)
        {
            // AI fleet initialisation
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
            if (isHitAndSink) PositionsOfHitShip = new List<int[]>();
            
            else if (isAttackSuccess)
            {    
                PositionsOfHitShip.Add(Utils.ConvertAttackedPositionToXy(attackedPosition));
                
                if (ShipOrientationIsKnown) return;
                var convAttackedPosition = Utils.ConvertAttackedPositionToXy(attackedPosition);
                IsShipHorizontal = ReadOrientatationFromLastShoots(convAttackedPosition);
            }
            
        }

        private void PrintDifficultyOptionsToSelect()
        {
            Console.WriteLine("Choose difficulty level for computer you want to play with: ");
            Console.WriteLine("1. Easy");
            Console.WriteLine("2. Medium");
            Console.WriteLine("3. Hard");
        }

        private int GetDifficultyOptionFromPlayer()
        {
            var input = Console.ReadLine();
            Int32.TryParse(input, out var number);
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