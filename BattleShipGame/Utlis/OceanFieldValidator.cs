using System.Collections.Generic;
using ConsoleApp7.Board;
using ConsoleApp7.utils;

namespace ConsoleApp7.Utlis
{
    public class OceanFieldValidator
    {
        private int[] OceanField { get; set; }
        private Ocean PlayerBoard { get; set; }
        private List<int[]> ForbiddenPositions { get; set; }
        private int X { get; set; }
        private int Y { get; set; }

        private int[] Up { get; set; }
        private int[] Down { get; set; }
        private int[] Right { get; set; }
        private int[] Left { get; set; }

        public OceanFieldValidator(string attackedPosition, Ocean playerBoard, List<int[]> forbiddenPositions)
        {
            OceanField = Utils.ConvertAttackedPositionToXy(attackedPosition);
            PlayerBoard = playerBoard;
            ForbiddenPositions = forbiddenPositions;
            SetProperties();
        }

        public OceanFieldValidator(int[] attackedPositionXy, Ocean playerBoard, List<int[]> forbiddenPositions)
        {
            OceanField = attackedPositionXy;
            PlayerBoard = playerBoard;
            ForbiddenPositions = forbiddenPositions;
            SetProperties();
        }

        public void AddToForbiddenList(int [] num)
        {
            ForbiddenPositions.Add(num);
        }

        private void SetProperties()
        {
            X = OceanField[0];
            Y = OceanField[1];
            Up = new[] {X, Y - 1};
            Down = new[] {X, Y + 1};
            Right = new[] {X + 1, Y};
            Left = new[] {X - 1, Y};

        }

        private bool IsInForbiddenPositions(int[] position) => Utils.IsArrayDuplicateInList(ForbiddenPositions, position);
        
        private bool IsRightValid () => Validation.IsFieldInBoardWidth(PlayerBoard, X + 1) && !IsInForbiddenPositions(Right);
        private bool IsLeftValid () => Validation.IsFieldInBoardWidth(PlayerBoard, X - 1) && !IsInForbiddenPositions(Left);
        private bool IsUpValid () => Validation.IsFieldInBoardHeight(PlayerBoard, Y - 1) && !IsInForbiddenPositions(Up);
        private bool IsDownValid () => Validation.IsFieldInBoardHeight(PlayerBoard, Y + 1) && !IsInForbiddenPositions(Down);

        public bool IsValidHorizontal () => IsRightValid() || IsLeftValid();
        public bool IsValidVertical () => IsUpValid() || IsDownValid();

        public bool IsValidFieldAround () => IsValidHorizontal() || IsValidVertical();

        public int[] GetValidHorizontal() => IsRightValid() ? Right : Left;
        public int[] GetValidVertical() => IsUpValid() ? Up : Down;
        public int[] GetValidFieldAround() => IsValidHorizontal() ? GetValidHorizontal() : GetValidVertical();

        public string GetAsString(int[] position) => Utils.ConvertXYtoStringRepresentationOfCords(position);

    }
    
    
    
    
}