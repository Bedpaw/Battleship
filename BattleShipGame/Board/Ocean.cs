using System;
using System.Collections;
using static System.Console;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp7.Board
{
    public abstract class Ocean
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

        public void PrintUpperCords()
        {
            StringBuilder sb = new StringBuilder();
            string SpaceHolder = new String(' ', 11);
            sb.Append(SpaceHolder);
            for (int i = 65; i < (65 + initY); i++)
            {
                sb.Append(Convert.ToChar(i));
            }
            WriteLine(sb.ToString());
        }

        public int CalcLengthOfInt(int x)
        {
            return x.ToString().Length;
        }

        public void PrintMiddleMap()
        {
            int i = 0;
            foreach (var row in board)
            {
                Write($"{new String(' ', (10 - CalcLengthOfInt(i+1)))}{i+1} ");
                foreach (var element in row)
                {
                    // Write(element.fieldSymbol);
                    element.ReturnSymbolWithColor();
                }
                WriteLine();
                ResetColor();
                i++;
            }
        }

        public void DisplayOcean()
        {
            PrintUpperCords();
            PrintMiddleMap();
        }
    }
}
