﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp7.utils
{
    public static class Utils
    {
        public static int[] ConvertAttackedPositionToXy(string attackedPosition)
        {
            var columnLetters = new List<char>
            {
                'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J'
            };
            var y = columnLetters.IndexOf(attackedPosition[0]);
            var x = attackedPosition.Length == 3 ? 9 : int.Parse(attackedPosition[1].ToString()) - 1;
            return new[] {x, y};
        }

        public static int GenerateRandomFromToRange(int minIncl=0, int maxIncl=9)
        {
            Random rand = new Random();
            return rand.Next(minIncl, maxIncl + 1);
        }
        
        public static string NumberConversionToLetter(int someNumber)
        {
            const int firstNumericRepresentationOfChar = 65;
            return ((char)(someNumber + firstNumericRepresentationOfChar)).ToString();
        }
        public static string ConvertXYtoStringRepresentationOfCords(params int [] posXy)
        {    
            var literalShootPosition = NumberConversionToLetter(posXy[0]);
            var numberShotPosition = posXy[1] + 1;
            return literalShootPosition + numberShotPosition;
        }

        public static int[] GenerateAndMakeUniqueRandomArray(List<int[]> listOfItems)
        {
            var arrOfRandNums = new int [2];
            do
            {
                arrOfRandNums[0] = GenerateRandomFromToRange();
                arrOfRandNums[1] = GenerateRandomFromToRange();
            } while (IsArrayDuplicateInList(listOfItems, arrOfRandNums));
            
            listOfItems.Add(arrOfRandNums);
            return arrOfRandNums;
        }
        public static int CalcLengthOfInt(int x)
        {
            return x.ToString().Length;
        }

        public static bool IsArrayDuplicateInList(List<int[]> list, IEnumerable<int> array)
        {
            return list.Exists(forbiddenPosition => forbiddenPosition.SequenceEqual(array));
        }
    }
    
}