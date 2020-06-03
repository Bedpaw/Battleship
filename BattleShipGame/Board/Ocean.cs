using System;
using System.Collections;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp7.Board
{
    public class Ocean
    {
        public List<List<Field>> board;
        protected int initX;
        protected int initY;

        public Ocean(int initX, int initY)
        {
             this.initX = initX;
             this.initY = initY;
             board = initNewBoard(this.initX, this.initY);
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
                    BackgroundColor = ConsoleColor.DarkBlue;
                    cell = element.ReturnSymbolWithColor();
                    ResetColor();
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
        
        // Players gonna keep boards
        // For now...
        // ProperOne
        // public void DisplayBothOceans(List<String> MyOcean, List<String> EnemyOcean)
        // Version for testing
        public void DisplayBothOceans()
        {
            // For testing
            List<String> OceanToDisplay1 = JoinPartsToArray();
            List<String> OceanToDisplay2 = JoinPartsToArray();

            for (int i = 0; i < OceanToDisplay1.Count; i++)
            {
                Write(OceanToDisplay1[i]);
                Write(MapDivider());
                Write(OceanToDisplay2[i]);
                WriteLine();
            }
            // ProperOne
            // for (int i = 0; i < OceanToDisplay1.Capacity; i++)
            // {
            //     Write(MyOcean[i]);
            //     Write(MapDivider());
            //     Write(EnemyOcean[i]);
            //     WriteLine();
            // }
        }
    }
}
