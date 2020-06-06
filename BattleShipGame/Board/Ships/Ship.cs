using ConsoleApp7.Interface;

namespace ConsoleApp7.Board
{
    public class Ship: IShip
    {
        public string Name { get; set; }
        public int Size{ get; set; }
        public char FieldSymbol { get; set; }
        public int Orientation { get; set; }
        public int[] StartPositions { get; set; }
        public bool IsSunk => Size == 0;
    }
}