using System;
using System.Collections.Generic;

namespace ConsoleApp7.utils
{
    public class utils
    {
        public static int[] ConvertAttackedPositionToXY(string attackedPosition)
        {
            var columnLetters = new List<char>
            {
                'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J'
            };
            var x = columnLetters.IndexOf(attackedPosition[0]);
            var y = attackedPosition.Length == 3 ? 9 : int.Parse(attackedPosition[1].ToString()) - 1;
            return new[] {x, y};
        }
    }
}