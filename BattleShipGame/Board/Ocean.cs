using System;
using System.Collections;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ConsoleApp7.Board
{
    public class Ocean
    {
        public List<Ship> Fleet = new List<Ship>();
        public List<List<Field>> board ;
        protected int initX;
        protected int initY;

        public Ocean(int initX, int initY)
        {
             this.initX = initX;
             this.initY = initY;
             board = initNewBoard(this.initX, this.initY);
        }

        public void AddNewShip(Ship newShip)
        {
            Fleet.Add(newShip);
            for (int i = 0; i < newShip.Size; i++)
            {
                int[] PosXY = newShip.StartPositions;
                if (newShip.Orientation == 1)
                {
                    board[PosXY[0]+i][PosXY[1]].shipOn = newShip;
                    board[PosXY[0]+i][PosXY[1]].isShipOn = true;

                }
                else if(newShip.Orientation == 2)
                {
                    board[PosXY[0]][PosXY[1]+i].shipOn = newShip;
                    board[PosXY[0]+i][PosXY[1]].isShipOn = true;

                }
            }
            
            
        }
        public static List<List<Field>> initNewBoard(int sizeX, int sizeY)
        {
            List<List<Field>> firstLevelList = new List<List<Field>>();
            
            for (int i = 0; i < sizeX; i++)
            {
               List<Field> secondLevelList = new List<Field>();
                for (int j = 0; j < sizeY; j++)
                { 
                    Field tempField = new Field(i, j);
                    secondLevelList.Add(tempField);
                }
                firstLevelList.Add(secondLevelList);
            }
            return firstLevelList;
        }

        public bool[] GetShot(int[] attackedPostionXY)
        {    
            WriteLine($"{attackedPostionXY[0]}{attackedPostionXY[1]}");
            var shotField = board[attackedPostionXY[0]][attackedPostionXY[1]];
            var isAttackSuccess = shotField.isShipOn;
            var isHitAndSink = false;
            
            
            shotField.fieldIsShut = true;
            
            if (isAttackSuccess)
            {
                shotField.shipOn.Size--;
                isHitAndSink = shotField.shipOn.IsSunk;
            } 

            return new[] {isAttackSuccess, isHitAndSink};
        }
 
        public StringBuilder MapDivider()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(new String(' ', 0));
            return sb;
        }
        public string CreateUpperCords()
        {
            StringBuilder sb = new StringBuilder();
            string SpaceHolder = new String(' ', 11);
            sb.Append(SpaceHolder);
            for (int i = 65; i < (65 + initY); i++)
            {
                sb.Append(Convert.ToChar(i));
            }
            return sb.ToString();
        }

        public int CalcLengthOfInt(int x)
        {
            return x.ToString().Length;
        }

        public List<String> CreateMiddleMap()
        {
            int i = 0;
            List<String> MiddleMap = new List<string>();
            
            foreach (var row in board)
            {
                StringBuilder ContainerRowLine = new StringBuilder();
                ContainerRowLine.Append($"{new String(' ', (10 - CalcLengthOfInt(i+1)))}{i+1} ");
                foreach (var element in row)
                {
                    string cell;
                    cell = element.ReturnSymbolWithColor();
                    ContainerRowLine.Append(cell);
                }

                MiddleMap.Add(ContainerRowLine.ToString());
                i++;
            }
            return MiddleMap;
        }

        public List<String> JoinPartsToArray()
        {
            List<String> playerOcean = new List<string>();
            string cordsOcean = CreateUpperCords();
            List<String> oceanDrawing = CreateMiddleMap();
            playerOcean.Add(cordsOcean);

            foreach (var row in oceanDrawing)
            {
                playerOcean.Add(row);
            }
            return playerOcean;
        }
        public static void DisplayMyOceans(List<Board> MyOcean)
        {

            for (int i = 0; i < MyOcean.Capacity; i++)
            {
                Write(MyOcean[i]);
                Write(MapDivider());
                WriteLine();
            }
        }
        
        public static void DisplayBothOceans(List<Board> MyOcean, List<Board> EnemyOcean)
        {

            for (int i = 0; i < MyOcean.Capacity; i++)
            {
                Write(MyOcean[i]);
                Write(MapDivider());
                Write(EnemyOcean[i]);
                WriteLine();
            }
        }
    }
}
