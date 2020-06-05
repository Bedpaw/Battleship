using System;
using System.Collections.Generic;

namespace ConsoleApp7.utils
{
    public class Validation
    {

        public static bool IsLetterFromAToJ(char letter)
        {
            var columnLetters = new List<char>
            {
                'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J'
            };
            return columnLetters.Contains(letter);
        }

        public static bool IsNumberFrom1To10(char [] charsToValidate)
        {   // Checking if it is 10 
            if (charsToValidate.Length == 3)
            {
                if (charsToValidate[1] == '1' && charsToValidate[2] == '0') return true;

            }
            // Check 1-9
            else if (char.IsDigit(charsToValidate[1]) && charsToValidate[1] != '0') return true;

            return false;
        }
        public static bool IsProperAttackPosition(string attackedPosition, List<string> allPositionsAttackedByPlayer)
        {
            var charsToValidate = attackedPosition.ToCharArray();

            if (charsToValidate.Length != 2 && charsToValidate.Length != 3) return false;
            if (!IsLetterFromAToJ(charsToValidate[0])) return false;
            if (!IsNumberFrom1To10(charsToValidate)) return false;
            if (allPositionsAttackedByPlayer.Contains(attackedPosition)) return false;
            
            return true;

        }
    }
}