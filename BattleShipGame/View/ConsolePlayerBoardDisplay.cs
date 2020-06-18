using System;
using static System.Console;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using ConsoleApp7.Board;
using ConsoleApp7.Board.Ships;
using ConsoleApp7.Players;
using ConsoleApp7.utils;
namespace ConsoleApp7.View

{
    public class ConsolePlayerBoardDisplay
    {
        
        public static List<string> CreateMiddleMap(Ocean myOcean, bool isEnemy)
        {
            int i = 0;
            List<String> MiddleMap = new List<string>();
            
            foreach (var row in myOcean.board)
            {
                StringBuilder ContainerRowLine = new StringBuilder();
                ContainerRowLine.Append($"{new String(' ', (10 - Utils.CalcLengthOfInt(i+1)))}{i+1} ");
                foreach (var field in row)
                {
                    if (isEnemy && field.IsShipOn && !field.FieldIsShut) ContainerRowLine.Append(" . ");
                    else ContainerRowLine.Append(field.FieldSymbol);
                }
                MiddleMap.Add(ContainerRowLine.ToString());
                i++;
            }
            return MiddleMap;
        }
        public static StringBuilder MapDivider()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(new String(' ', 0));
            return sb;
        }
        public static void DisplayBothOceans(Ocean MyOcean, Ocean EnemyOcean)
        {

            var arrOcean1 = JoinPartsToArray(MyOcean);
            var arrOcean2 = JoinPartsToArray(EnemyOcean, true);
            for (int i = 0; i < arrOcean2.Count; i++)
            {
                Write(arrOcean1[i]);
                Write(MapDivider());
                Write(arrOcean2[i]);
                WriteLine();
            }
        }
        
        public static void DisplayMyOcean(Ocean MyOcean)
        {
            var arrOcean = JoinPartsToArray(MyOcean);

            foreach (var row in arrOcean)
            {
                WriteLine(row);
            }
             
        }
        public static List<String> JoinPartsToArray(Ocean someOcean, bool isEnemy = false)
        {
            List<String> playerOcean = new List<string>();
            string cordsOcean = someOcean.CreateUpperCords();
            List<String> oceanDrawing = CreateMiddleMap(someOcean, isEnemy);
            playerOcean.Add(cordsOcean);

            foreach (var row in oceanDrawing)
            {
                playerOcean.Add(row);
            }
            
            return playerOcean;
        }
    }
}