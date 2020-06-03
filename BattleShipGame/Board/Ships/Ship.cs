using ConsoleApp7.Interface;

namespace ConsoleApp7.Board
{
    public struct Position
    {
        public char Row;
        public char Column;
    };
    public struct Point
    {
        public int Row;
        public int Column;
    }
    public class Ship: IShip
    {
        public string Name { get; set; }
        public int Size{ get; set; }
        public int Hits { get; set; }
        public Orientations Orientation { get; set; }
        
        public Position EndPosition;
        public Position StartPosition;
        
        public bool checkIfSunk { get; set; }
        
        public enum Orientations
        {
            Vertical,
            Horizontal
        }
        
        

    }
}