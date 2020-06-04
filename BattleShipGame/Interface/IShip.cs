using ConsoleApp7.Board;

namespace ConsoleApp7.Interface
{
    public interface IShip
    {
        public interface IShip
        {
            bool ValidateStartPosition(char[] rows, char[] columns, string[,] grid);
            bool ValidateOrientation(char orientation);
            bool ValidateCellContents(string candidateCellContents);

            int Size { get; set; }
            bool IsDestroyed { get; set; }

            string Legend { get; set; }
            string PlacingString { get; set; }

            char[] LocationRows { get; set; }
            char[] LocationColumns { get; set; }
            
        }

    }
    
}