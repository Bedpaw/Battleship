﻿using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleApp7.Board.Ships;
using ConsoleApp7.Board;
using ConsoleApp7.Interface;
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
        
        private List<int[]> WeightsOfShootsForHard {get; set;} = new List<int[]>();
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
            if (DifficultyLevel == Difficulty.Hard) 
                WeightsOfShootsForHard = InitWeightList();
            PlayerNick = $"Computer {DifficultyLevel.ToString()}";
            SetShips(PlayerBoard, Display.DisplayOcean);
        }

        private List<int[]> InitWeightList() // initX, initY TODO improve
        {
           var tempListToReturn = new List<int[]>();
            for (int i = 0; i < 10; i++)
            {
                var tempArrToReturn = new int [10];
                for (int j = 0; j < 10; j++)
                {
                    tempArrToReturn[j] = i == 0 && j == 0 ? 4 - 2 : i == 0 || j == 0 ? 4 - 1 : 4;
                }

                tempListToReturn.Append(tempArrToReturn);
            }

            return tempListToReturn;
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
        private string HardAttack()
        {
            /*
             *                                    ------- IDEA -------
             * Every field gonna have its own weight which will be calculated based on possible neighbours
             * If field is shoot and there is nothing the field automatically become 0 and its neighbours loose weight -1
             * but only neighbourns up right down left are updated cross neighbourns remain same
             *
             * If field is has ship on it the algorithm used for detecting ship starts to work till ship is not destroyed
             * and then searching algorithm starts work again is quite a loop like that till end of game!
             * 
             */
            var thislistneededhere = WeightsOfShootsForHard;
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
        private bool CheckIfOrientationIsHorizontal(int [] attackedPosition)
        {
            return PositionsOfHitShip[0][0] + 1 == attackedPosition[0] || PositionsOfHitShip[0][0] - 1 == attackedPosition[0];
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
        public override bool[] UpdateMyBoard(string attackPosition)
        {
            var attackedPositionXy = Utils.ConvertAttackedPositionToXy(attackPosition);
            var attackResult = PlayerBoard.GetShot(attackedPositionXy);
            return attackResult;
        }
        
        public override void SaveAttackResults(string attackedPosition, bool isAttackSuccess, bool isHitAndSink)
        {
            var attackedPositionAsXy = Utils.ConvertAttackedPositionToXy(attackedPosition);
            var fakedAttackedPositionAsXy = new [] {attackedPositionAsXy[1], attackedPositionAsXy[0]};
            
            UniqueShootsArray.Add(fakedAttackedPositionAsXy);
            
            if (isHitAndSink) PositionsOfHitShip = new List<int[]>();
                        
            else if (isAttackSuccess)
            {    
                PositionsOfHitShip.Add(fakedAttackedPositionAsXy);
                
                if (ShipOrientationIsKnown) return;
                IsShipHorizontal = CheckIfOrientationIsHorizontal(attackedPositionAsXy);
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