using System.Collections.Generic;
using ConsoleApp7.Board;
using ConsoleApp7.utils;
using ConsoleApp7.Utlis;

namespace ConsoleApp7.Players
{
    public class HardStrategy : AiAttackStrategy
    {
        private int[,] WeightsOfShootsForHard { get; set; } = InitWeightList();
        public override string Attack()
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
            if (!IsShipHitNotSink)
            {
                var attackedPosition = ChoseMaxWeightFromList();
                UpdateWeightsBoardAfterAttack(attackedPosition);
                return Utils.ConvertXYtoStringRepresentationOfCords(attackedPosition);
            }
            //:TODO Refactor 
            var positionToAttack = KillShipIfShoot();
            var attackedPos = Utils.ConvertAttackedPositionToXy(positionToAttack);
            var fakedAttackedPositionAsXy = new [] {attackedPos[1], attackedPos[0]};
            UpdateWeightsBoardAfterAttack(fakedAttackedPositionAsXy);
            return positionToAttack;
        }
        private int[] ChoseMaxWeightFromList()
        {
            int posX = 0;
            int posY = 0;
            int maxValue = 0;
            // iterate over list of arrays
            for (int i = 0; i < 10; i++)
            {
                // iterate over array of elements in order to find max element
                for (int j = 0; j < 10; j++)
                {
                    if (maxValue < WeightsOfShootsForHard[i, j])
                    {
                        maxValue = WeightsOfShootsForHard[i, j];
                        posX = i;
                        posY = j;
                    }
                }
            }

            return new[] {posX, posY};
        }
        private static int[,] InitWeightList()
        { 
            int maxSizeX = 9; // as array index
            int maxSizeY = 9; // as array index
            var tempArrToReturn = new int [maxSizeX + 1, maxSizeY + 1];
            
            bool IsBoardCorner(int i, int j) => (i == 0 || i == maxSizeX) && (j == 0 || j == maxSizeY);
            bool IsBoardBorder(int i, int j) => j == 0 || i == 0 || j == maxSizeY || i == maxSizeX;
            
            for (int i = 0; i <= maxSizeX; i++)
            {
                for (int j = 0; j <= maxSizeY; j++)
                {
                    tempArrToReturn[i,j] = IsBoardCorner(i, j) ? 2 : IsBoardBorder(i, j) ? 3 : 4;
                }
            }
            return tempArrToReturn;
        }


        private void UpdateWeightsBoardAfterAttack(int [] attackedPos) 
        {
            WeightsOfShootsForHard[attackedPos[0] ,attackedPos[1]] = 0;
            var posAttack = new OceanFieldValidator(attackedPos, PlayerBoard, new List<int[]>());
            
            while(posAttack.IsValidFieldAround())
            {
                var posXy = posAttack.GetValidFieldAround(); // x, y
                posAttack.AddToForbiddenList(posXy);
                WeightsOfShootsForHard[posXy[0], posXy[1]]--;
            }
        }

        public HardStrategy(Ocean playerBoard) : base(playerBoard)
        {
        }
    }
    
}