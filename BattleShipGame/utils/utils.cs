using System;
using System.Collections.Generic;

namespace ConsoleApp7.utils
{
    public static class Utils
    {
        public static int[] ConvertAttackedPositionToXY(string attackedPosition)
        {
            var columnLetters = new List<char>
            {
                'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J'
            };
            var x = attackedPosition.Length == 3 ? 9 : int.Parse(attackedPosition[1].ToString()) - 1;
            var y = columnLetters.IndexOf(attackedPosition[0]);
            return new[] {x, y};
        }

        public static int GenerateRandomFromToRange(int minIncl=0, int maxIncl=100)
        {
            Random rand = new Random();
            return rand.Next(minIncl, maxIncl + 1);
        }

    }
}