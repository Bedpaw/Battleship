using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using ConsoleApp7.Board.Ships;
using ConsoleApp7.Board;
using ConsoleApp7.utils;
using ConsoleApp7.Game;
using ConsoleApp7.Interface;

namespace ConsoleApp7.Players
{

    public class PlayerAI : Player
    {
        protected List<int[]> UniqueShootsArray = new List<int[]>();
        protected bool isShipHorizontal;
        protected bool doYouKnowShipOrientation;
        
        private int[] lastAiAttack = new int [2];
        private int[] _lastAiAttackSuccess = new int[2];
        public static bool LastAttackSuccess;


        public PlayerAI()
        {
            PlayerBoard = new Ocean(10, 10);
            DifficultyLevel = SetDifficultyLevel();
            PlayerNick = $"Computer {Difficulty.Easy.ToString()}";
            SetShips(PlayerBoard);
        }
        
        public enum Difficulty
        {
            Easy = 1,
            Medium = 2,
            Hard = 3
        }
        private Difficulty DifficultyLevel { get;}
        
        protected string LevelAttackSelection()
        {
            if (DifficultyLevel == Difficulty.Easy)
            {
                return EasyAttack();
            }
            else if (DifficultyLevel == Difficulty.Medium)
            {
                return MediumAttack();
            }
            return HardAttack();

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
            if (LastAttackSuccess)
            {
                if (doYouKnowShipOrientation)
                {
                    if (isShipHorizontal)
                    {
                        if (Validation.IsFieldInBoardWidth(PlayerBoard, _lastAiAttackSuccess[0] + 1)
                            && UniqueShootsArray.Contains(_lastAiAttackSuccess))
                        {
                            return Utils.ConvertXYtoStringRepresentationOfCords(_lastAiAttackSuccess[0] + 1,
                                _lastAiAttackSuccess[1]);
                        }
                        else
                        {
                            return Utils.ConvertXYtoStringRepresentationOfCords(_lastAiAttackSuccess[0] - 1,
                                _lastAiAttackSuccess[1]);
                        }
                    }
                    else
                    {
                        if (Validation.IsFieldInBoardHeight(PlayerBoard, _lastAiAttackSuccess[1] + 1)
                            && UniqueShootsArray.Contains(_lastAiAttackSuccess))
                        {
                            return Utils.ConvertXYtoStringRepresentationOfCords(_lastAiAttackSuccess[0],
                                _lastAiAttackSuccess[1]+1);
                        }
                        else
                        {
                            return Utils.ConvertXYtoStringRepresentationOfCords(_lastAiAttackSuccess[0],
                                _lastAiAttackSuccess[1]-1);
                        }
                    }
                }
                else
                {   
                    var x = _lastAiAttackSuccess[0];
                    var y = _lastAiAttackSuccess[1];
                    var up = new [] {x, y - 1};
                    var down = new [] {x, y + 1};
                    var left = new [] {x - 1, y};
                    var right = new [] {x + 1, y};
                    if (Validation.IsFieldInBoard(PlayerBoard, up) && UniqueShootsArray.Contains(up)) 
                        return Utils.ConvertXYtoStringRepresentationOfCords(up);
                    if (Validation.IsFieldInBoard(PlayerBoard, down) && UniqueShootsArray.Contains(down))
                        return Utils.ConvertXYtoStringRepresentationOfCords(down);;
                    if (Validation.IsFieldInBoard(PlayerBoard, right) && UniqueShootsArray.Contains(left))
                        return Utils.ConvertXYtoStringRepresentationOfCords(left);
                    if (Validation.IsFieldInBoard(PlayerBoard, left) && UniqueShootsArray.Contains(right))
                        return Utils.ConvertXYtoStringRepresentationOfCords(right);
                }
            }
            return EasyAttack();
        }
        private string HardAttack()
        {
            //Hard attack follow algorithm and kill ship in less possible moves like medium
            return " ";
        }

        public override string Attack()
        {
            return LevelAttackSelection();

        }
        private int[] GenerateAndMakeUniqueRandomArray(List<int[]> listOfItems)
        {
            int[] arrOfrandNums = new int [2];
            do
            {
                arrOfrandNums[0] = Utils.GenerateRandomFromToRange();
                arrOfrandNums[1] = Utils.GenerateRandomFromToRange();
            } while (listOfItems.Contains(arrOfrandNums));
            listOfItems.Add(arrOfrandNums);
            return arrOfrandNums;
        }

        public int GenerateOrientation() => Utils.GenerateRandomFromToRange(1, 2);

        private int [] ShipFirstFieldPosition(Ship shipToCheck)
        {
            int[] posXY = new int[2];
            do
            {
                posXY[0] = Utils.GenerateRandomFromToRange();
                posXY[1] = Utils.GenerateRandomFromToRange();
                Console.WriteLine($"{posXY[0]}, {posXY[1]}");
                Console.WriteLine($"{shipToCheck.Orientation}");
            } while (!Validation.IsSpaceForShip(posXY, PlayerBoard, shipToCheck));
            
            return posXY;
        }

        protected bool readOrientatationFromLastShoots(int [] attackedPosition, int [] lastAiAttack)
        {
            if (lastAiAttack[0] + 1 == attackedPosition[0] || lastAiAttack[0] - 1 == attackedPosition[0])
                return true;
            if (lastAiAttack[1] + 1 == attackedPosition[1] || lastAiAttack[1] - 1 == attackedPosition[1])
                return false;
            return false;
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
        public override bool[] UpdateMyBoard(string attackPosition) // here is the magic of attacking
        {
            var attackedPositionXy = Utils.ConvertAttackedPositionToXy(attackPosition);
            
            var attackResult = PlayerBoard.GetShot(attackedPositionXy);
            return attackResult;
        }

        public override bool IsFleetAlive()
        {
            return PlayerBoard.Fleet.Exists(ship => ship.IsSunk == false);
        }

        public override void SaveAttackResults(string attackedPosition, bool isAttackSuccess, bool isHitAndSink)
        {
            if (isAttackSuccess && !isHitAndSink)
            {
                if (!LastAttackSuccess)
                {
                    lastAiAttack = Utils.ConvertAttackedPositionToXy(attackedPosition);
                    LastAttackSuccess = true;
                }
                else if(!doYouKnowShipOrientation)
                {
                    var convAttackedPosition = Utils.ConvertAttackedPositionToXy(attackedPosition);
                    isShipHorizontal = readOrientatationFromLastShoots(convAttackedPosition, lastAiAttack);
                    doYouKnowShipOrientation = true;
                }
                else
                {
                    //TODO
                }
                
            }

            if (isHitAndSink)
            {
                lastAiAttack = new int[]{};
                LastAttackSuccess = false;
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
            string input = Console.ReadLine();
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