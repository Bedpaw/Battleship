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
             board = InitNewBoard(this.initX, this.initY);
        }

        public void AddNewShip(Ship newShip)
        {
            Fleet.Add(newShip);
            for (int i = 0; i < newShip.Size; i++)
            {
                int[] PosXY = newShip.StartPositions;
                if (newShip.Orientation == 1)
                {
                    board[PosXY[0]+i][PosXY[1]].ShipOn = newShip;
                    board[PosXY[0]+i][PosXY[1]].IsShipOn = true;

                }
                else if(newShip.Orientation == 2)
                {
                    board[PosXY[0]][PosXY[1]+i].ShipOn = newShip;
                    board[PosXY[0]][PosXY[1]+i].IsShipOn = true;
                }
            }
        }
        public static List<List<Field>> InitNewBoard(int sizeX, int sizeY)
        {
            List<List<Field>> firstLevelList = new List<List<Field>>();
            
            for (int i = 0; i < sizeX; i++)
            {
               List<Field> secondLevelList = new List<Field>();
                for (int j = 0; j < sizeY; j++)
                { 
                    Field tempField = new Field();
                    secondLevelList.Add(tempField);
                }
                firstLevelList.Add(secondLevelList);
            }
            return firstLevelList;
        }

        public bool[] GetShot(int[] attackedPositionXy)
        {   
            var shotField = board[attackedPositionXy[0]][attackedPositionXy[1]];
            var isAttackSuccess = shotField.IsShipOn;
            var isHitAndSink = false;

            shotField.FieldIsShut = true;
            
            if (isAttackSuccess)
            {
                shotField.ShipOn.Size--;
                isHitAndSink = shotField.ShipOn.IsSunk;
            } 

            return new[] {isAttackSuccess, isHitAndSink};
        }
    }
}
