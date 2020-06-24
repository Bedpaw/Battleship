using System;
using System.Collections.Generic;
using ConsoleApp7.Board;
using ConsoleApp7.utils;
using ConsoleApp7.Utlis;

namespace ConsoleApp7.Players
{
    public abstract class AiAttackStrategy
    {
        protected Ocean PlayerBoard { get; set; } 
        protected bool IsShipHitNotSink => PositionsOfHitShip.Count != 0;
        private List<int []> PositionsOfHitShip { get; set; } = new List<int[]>();
        private bool IsShipHorizontal { get; set; }
        private bool ShipOrientationIsKnown => PositionsOfHitShip.Count > 1;

        protected List<int[]> UniqueShootsArray = new List<int[]>();

        protected AiAttackStrategy(Ocean playerBoard) => PlayerBoard = playerBoard;
        public abstract string Attack();

        protected string KillShipIfShoot()
        {
            foreach (var shipPosition in PositionsOfHitShip)
            {
                var shipPos = new OceanFieldValidator(shipPosition, PlayerBoard, UniqueShootsArray);

                if (!ShipOrientationIsKnown) return shipPos.GetAsString(shipPos.GetValidFieldAround());

                if (IsShipHorizontal) if (shipPos.IsValidHorizontal()) return shipPos.GetAsString(shipPos.GetValidHorizontal());
                if (!IsShipHorizontal) if (shipPos.IsValidVertical()) return shipPos.GetAsString(shipPos.GetValidVertical());
            }
            throw new InvalidOperationException();
        }
        private bool CheckIfOrientationIsHorizontal(int [] attackedPosition)
        {   
            return PositionsOfHitShip[0][0] + 1 == attackedPosition[0] || PositionsOfHitShip[0][0] - 1 == attackedPosition[0];
        }
        public void SaveAttackResults(string attackedPosition, bool isAttackSuccess, bool isHitAndSink)
        {
            var attackedPositionAsXy = Utils.ConvertAttackedPositionToXy(attackedPosition);
            var fakedAttackedPositionAsXy = new [] {attackedPositionAsXy[1], attackedPositionAsXy[0]};
        
            UniqueShootsArray.Add(fakedAttackedPositionAsXy);

            if (isHitAndSink)
            {
                PositionsOfHitShip = new List<int[]>();
            }
                        
            else if (isAttackSuccess)
            {    
                PositionsOfHitShip.Add(fakedAttackedPositionAsXy);
                
                if (PositionsOfHitShip.Count == 2) IsShipHorizontal = CheckIfOrientationIsHorizontal(fakedAttackedPositionAsXy);
            }
        }
    }
    
    
    
}