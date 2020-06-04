namespace ConsoleApp7.Board.ShipType
{
    public class Carrier : Ship
    {
        public Carrier()
        {
            Name = "Aircraft Carrier";
            Size = 5;
            // Horizont = isHorizont; 
        }
        public char fieldSymbol = 'B';
    }
}