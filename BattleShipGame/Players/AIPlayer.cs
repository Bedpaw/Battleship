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
        protected List<int> UniqueShootsArray = new List<int>();
        protected List<int> ShipsFirstFieldCords = new List<int>();
        
        private int[] lastAiAttack = new int [2];
        private int[] _lastAiAttackSuccess = new int[2];
        public static bool LastAttackSuccess = false;
        private AttackSuccessDirection _direction = AttackSuccessDirection.North;

        public PlayerAI()
        {
            PlayerBoard = new Ocean(10, 10);
            DifficultyLevel = SetDifficultyLevel();
            PlayerNick = $"Computer {Difficulty.Easy.ToString()}";
            SetShips(PlayerBoard);
        }

        private enum AttackSuccessDirection
        {
            North,
            East,
            South,
            West
        }
        public enum Difficulty
        {
            Easy = 1,
            Medium = 2,
            Hard = 3
        }
        public enum ShipOrientation
        {
            Horizontal,
            Vertical
        }

        private Difficulty DifficultyLevel { get;}

        private int[] generateRandomNumericRepresentationOfShootPosition(int randomNum)
        {
           int [] arrOfnum = {Utils.GenerateRandomFromToRange(), Utils.GenerateRandomFromToRange()};
           return arrOfnum;
        }

        private string NumberConvertionToLetter(int someNumber)
        {
            const int firstNumericRepresentationOfChar = 65;
            return ((char)(someNumber + firstNumericRepresentationOfChar)).ToString();
        }

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
            var randomNum = GenerateAndMakeUniqueRandomNumber(UniqueShootsArray);
            int[] numericArrOfPositions = generateRandomNumericRepresentationOfShootPosition(randomNum);
            var literalShootPosition = NumberConvertionToLetter(numericArrOfPositions[0]);
            literalShootPosition += numericArrOfPositions[1].ToString();
            return literalShootPosition;
        }
        private string MediumAttack()
        {
            //Medium attack randomly search for ship but when it hit into ship the ship will be
            //destroyed in less possible moves
            if (LastAttackSuccess)
            {
                // remember last good position and try another direction
                _lastAiAttackSuccess = lastAiAttack;
                
                // If human ship is attack but computer choose wrong direction to shoot

                
                // validation if direction are possible
                // direction of shoot should be wise chosen
                // remember good direction if second shoot is successful


                // If ship is sink LastAttackSuccess become again false
                // 
            }
            else
            {
                return EasyAttack();
            }

            return " ";
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
        private int GenerateAndMakeUniqueRandomNumber(List<int> listOfItems)
        {
            int randomNumber;
            do
            {
                randomNumber = Utils.GenerateRandomFromToRange();
            } while (UniqueShootsArray.Contains(randomNumber));
            listOfItems.Add(randomNumber);
            return randomNumber;
        }

        public int GenerateOrientation() => Utils.GenerateRandomFromToRange(1, 2);

        private int [] ShipFirstFieldPosition(Ship shipToCheck)
        {
            int[] posXY = new int[2];
            do
            {
                // var shipFirstCords = GenerateAndMakeUniqueRandomNumber(ShipsFirstFieldCords);
                posXY[0] = Utils.GenerateRandomFromToRange();
                posXY[1] = Utils.GenerateRandomFromToRange();
                Console.WriteLine($"{posXY[0]}, {posXY[1]}");
                Console.WriteLine($"{shipToCheck.Orientation}");
            } while (!Validation.IsSpaceForShip(posXY, PlayerBoard, shipToCheck));

            Console.WriteLine($"{posXY[0]}, {posXY[1]}");
            Console.ReadKey();
            
            return posXY;
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
            var attackedPositionXY = Utils.ConvertAttackedPositionToXy(attackPosition);
            var attackResult = PlayerBoard.GetShot(attackedPositionXY);
            return attackResult;
        }

        public override bool IsFleetAlive()
        {
            throw new System.NotImplementedException();
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