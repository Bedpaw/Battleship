using System;
using System.Collections.Generic;

namespace ConsoleApp7.utils
{
    public class utils
    {
        public static int[] ConvertAttackedPositionToXY(string attackedPosition)
        {
            char [] aP = attackedPosition.ToCharArray();
            var bigLetters = new List<char>
            {
                'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J'
            };
            var x = bigLetters.IndexOf(aP[0]);
            var y = attackedPosition.Length == 3 ? 9 : int.Parse(aP[1].ToString());
            return new[] {x, y};
        }
    }
}