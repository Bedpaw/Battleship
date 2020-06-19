using System;
using static System.Console;
using System.Collections.Generic;
using System.Text;
using ConsoleApp7.Board.Ships;
using ConsoleApp7.utils;

namespace ConsoleApp7.Board
{
    public class Ocean
    {
        public List<Ship> Fleet = new List<Ship>();
        public List<List<Field>> board ;
        public int initX;
        public int initY;

        public Ocean(int initX, int initY)
        {
             this.initX = initX;
             this.initY = initY;
             board = InitNewBoard(initX, initY);
        }
        
        private static List<List<Field>> InitNewBoard(int sizeX, int sizeY)
        {
            var firstLevelList = new List<List<Field>>();
            
            for (var i = 0; i < sizeX; i++)
            {
               var secondLevelList = new List<Field>();
                for (var j = 0; j < sizeY; j++)
                { 
                    var tempField = new Field();
                    secondLevelList.Add(tempField);
                }
                firstLevelList.Add(secondLevelList);
            }
            return firstLevelList;
        }
        
        public void AddNewShip(Ship newShip)
        {
            Fleet.Add(newShip);
            for (var i = 0; i < newShip.Size; i++)
            {
                var posXy = newShip.StartPositions;
                
                switch (newShip.Orientation)
                {
                    case 1:
                        board[posXy[0]+i][posXy[1]].ShipOn = newShip;
                        board[posXy[0]+i][posXy[1]].IsShipOn = true;
                        break;
                    case 2:
                        board[posXy[0]][posXy[1]+i].ShipOn = newShip;
                        board[posXy[0]][posXy[1]+i].IsShipOn = true;
                        break;
                }
            }
        }
        public bool[] GetShot(int[] attackedPositionXy)
        {   
            var shotField = board[attackedPositionXy[0]][attackedPositionXy[1]];
            shotField.FieldIsShut = true;

            var isAttackSuccess = shotField.IsShipOn;
            var isHitAndSink = false;
            
            if (isAttackSuccess)
            {
                shotField.ShipOn.Size--;
                isHitAndSink = shotField.ShipOn.IsSunk;
            } 

            return new[] {isAttackSuccess, isHitAndSink};
        }
    }
}
