using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using ConsoleApp7.Board.Ships;
using ConsoleApp7.Board;
using ConsoleApp7.Game;
using ConsoleApp7.Interface;

namespace ConsoleApp7.Players
{

    public class PlayerAI : Player
    {
        protected List<int> UniqueShootsArray = new List<int>();
        protected List<int> ShipsFirstFieldCords = new List<int>();
        public PlayerAI()
        {
            PlayerBoard = new Ocean(10, 10);
            DifficultyLevel = SetDifficultyLevel();
            PlayerNick = $"Computer {Difficulty.Easy}";
            SetShips(PlayerBoard);
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
           int [] arrOfnum = {(int) Math.Floor((decimal) (randomNum / 10)), randomNum % 10};
           return arrOfnum;
        }

        private string NumberConvertionToLetter(int someNumber)
        {
            const int firstNumericRepresentationOfChar = 65;
            return ((char)(someNumber + firstNumericRepresentationOfChar)).ToString();
        }
        
        
        public override string Attack()
        {
            var randomNum = GenerateAndMakeUniqueRandomNumber(UniqueShootsArray);
            int[] numericArrOfPositions = generateRandomNumericRepresentationOfShootPosition(randomNum);
            var literalShootPosition = NumberConvertionToLetter(numericArrOfPositions[0]);
            literalShootPosition += numericArrOfPositions[1].ToString();
            return literalShootPosition;

        }
        private int GenerateAndMakeUniqueRandomNumber(List<int> listOfItems)
        {
            int randomNumber;
            do
            {
                randomNumber = utils.Utils.GenerateRandomFromToRange();
            } while (UniqueShootsArray.Contains(randomNumber));
            listOfItems.Add(randomNumber);
            return randomNumber;
        }

        public int GenerateOrientation()
        {
            var randomNumber = utils.Utils.GenerateRandomFromToRange(1, 2);
            // ShipOrientation randomOrientation = (ShipOrientation) randomNumber;
            return randomNumber;
        }

        private int [] ShipFirstFieldPosition()
        {
            var shipFirstCords = GenerateAndMakeUniqueRandomNumber(ShipsFirstFieldCords);
            // Validation TODO
            int [] posXbyY = {(int) Math.Floor((decimal) (shipFirstCords / 10)), shipFirstCords % 10};
            
            return posXbyY;
        }
        
        protected override void SetShips(Ocean playerBoard)
        {
            // AI fleet initialisation
            var fleetForAi = ShipsCreation.CreateFleet();

            foreach (var shipAi in fleetForAi)
            {
                shipAi.Orientation = GenerateOrientation();
                shipAi.StartPositions = ShipFirstFieldPosition();
                playerBoard.AddNewShip(shipAi);
            }
            
        }

        public override bool[] UpdateMyBoard(string attackPosition)
        {
            throw new NotImplementedException();
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