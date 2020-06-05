using ConsoleApp7.Interface;

namespace ConsoleApp7.Board
{
    // public struct Position
    // {
    //     public char Row;
    //     public char Column;
    // };
    // public struct Point
    // {
    //     public int Row;
    //     public int Column;
    // }
    public class Ship: IShip
    {
        public string Name { get; set; }
        public int Size{ get; set; }
        public int Hits { get; set; }
        public static char fieldSymbol = 'S';
        public int Orientation { get; set; }
        
        public int[] StartPositions { get; set; }

        public bool IsSunk => Size == 0;
    }
}