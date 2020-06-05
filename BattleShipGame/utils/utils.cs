using System;
using System.Collections.Generic;

namespace ConsoleApp7.utils
{
    public class utils
    {
        public static int[] ConvertAttackedPositionToXY(string attackedPosition)
        {
            var bigLetters = new List<char>
            {
                'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J'
            };
            var y = attackedPosition.Length == 3 ? 10 : Convert.ToInt32(attackedPosition[1]);
            var x = bigLetters.IndexOf(attackedPosition[0]);
            return new[] {x, y};
        }
    }
}