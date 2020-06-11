using System;
using System.Collections.Generic;
using ConsoleApp7.Board;
using ConsoleApp7.Board.Ships;

namespace ConsoleApp7.utils
{
    public static class Validation
    {
        private static bool IsLetterFromAToJ(char letter)
        {
            var columnLetters = new List<char>
            {
                'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J'
            };
            return columnLetters.Contains(letter);
        }

        private static bool IsNumberFrom1To10(char [] charsToValidate)
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

        public static bool IsProperStartPosition(string startPosition, Ocean myBoard, Ship ship)
        {
            var charsToValidate = startPosition.ToCharArray();

            if (charsToValidate.Length != 2 && charsToValidate.Length != 3) return false;
            if (!IsLetterFromAToJ(charsToValidate[0])) return false;
            if (!IsNumberFrom1To10(charsToValidate)) return false;
            
            return IsSpaceForShip(startPosition, myBoard, ship);
        }

        private static bool IsSpaceForShip(string startPosition, Ocean ocean, Ship ship)
        {
            var posXy = Utils.ConvertAttackedPositionToXY(startPosition);
            
            for (var i = 0; i < ship.Size; i++)
            {
                var shipFieldToCheck = ship.Orientation == 1 // 1 = horizontal else vertical
                    ? new[] {posXy[0] + i, posXy[1]}
                    : new[] {posXy[0], posXy[1] + i};

                if (IsShipInOrAroundField(ocean, shipFieldToCheck)) return false;
            }
            return true;
        }
        private static bool IsFieldInBoardWidth(Ocean ocean, int posX) => 0 < posX && posX < ocean.initX;
        private static bool IsFieldInBoardHeight(Ocean ocean, int posY) => 0 < posY && posY < ocean.initY;
        private static bool IsFieldInBoard(Ocean ocean, int[] posXy) => IsFieldInBoardWidth(ocean, posXy[0]) && IsFieldInBoardHeight(ocean, posXy[1]);
        private static bool IsShipInOrAroundField(Ocean ocean, int [] posXy)
        {
            var x = posXy[0];
            var y = posXy[1];
            var up = new [] {x, y - 1};
            var down = new [] {x, y + 1};
            var left = new [] {x - 1, y};
            var right = new [] {x + 1, y};
            
            if (IsFieldInBoard(ocean, posXy)) if (ocean.board[x][y].IsShipOn) return true;
            if (IsFieldInBoard(ocean, up)) if (ocean.board[x][y - 1].IsShipOn) return true;
            if (IsFieldInBoard(ocean, down)) if (ocean.board[x][y + 1].IsShipOn) return true;
            if (IsFieldInBoard(ocean, right)) if (ocean.board[x + 1][y].IsShipOn) return true;
            if (IsFieldInBoard(ocean, left)) if (ocean.board[x - 1][y].IsShipOn) return true;

            return false;
        }

    }
}
