using System;
using static System.Console;
using System.Collections.Generic;
using System.Text;
using ConsoleApp7.Board;
using ConsoleApp7.utils;
namespace ConsoleApp7.View

{
    public class ConsoleOceanDisplay : IOceanDisplay
    {
        private static string CreateUpperCords(Ocean myOcean)
        {
            StringBuilder sb = new StringBuilder();
            string spaceHolder = new String(' ', 11);
            sb.Append(spaceHolder);
            for (int i = 65; i < (65 + myOcean.initY); i++)
            {
                sb.Append($" {Convert.ToChar(i)} ");
            }
            return sb.ToString();
        }
        private static List<string> CreateMiddleMap(Ocean myOcean, bool isEnemy)
        {
            int i = 0;
            List<String> middleMap = new List<string>();
            
            foreach (var row in myOcean.board)
            {
                StringBuilder containerRowLine = new StringBuilder();
                containerRowLine.Append($"{new String(' ', (10 - Utils.CalcLengthOfInt(i+1)))}{i+1} ");
                foreach (var field in row)
                {
                    if (isEnemy && field.IsShipOn && !field.FieldIsShut) containerRowLine.Append(" . ");
                    else containerRowLine.Append(field.FieldSymbol);
                }
                middleMap.Add(containerRowLine.ToString());
                i++;
            }
            return middleMap;
        }
        private static StringBuilder MapDivider()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(new String(' ', 0));
            return sb;
        }

        private static List<String> JoinPartsToArray(Ocean someOcean, bool isEnemy = false)
        {
            List<String> playerOcean = new List<string>();
            string cordsOcean = CreateUpperCords(someOcean);
            List<String> oceanDrawing = CreateMiddleMap(someOcean, isEnemy);
            playerOcean.Add(cordsOcean);
            
            foreach (var row in oceanDrawing)
            {
                playerOcean.Add(row);
            }
            
            return playerOcean;
        }

        public void MyOcean(Ocean myOcean)
        {
            {   
                Clear(); 
                var arrOcean = JoinPartsToArray(myOcean);

                foreach (var row in arrOcean)
                {
                    WriteLine(row);
                }
            }
        }
        public void BothOceans(Ocean myOcean, Ocean enemyOcean)
        {
            {
                Clear();
                var arrOcean1 = JoinPartsToArray(myOcean);
                var arrOcean2 = JoinPartsToArray(enemyOcean, true);
                for (int i = 0; i < arrOcean2.Count; i++)
                {
                    Write(arrOcean1[i]);
                    Write(MapDivider());
                    Write(arrOcean2[i]);
                    WriteLine();
                }
            }
        }
    }
}