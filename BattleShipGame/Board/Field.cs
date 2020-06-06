using System;
using System.Collections.Generic;

namespace ConsoleApp7.Board
{
    public class Field
    {
        public Ship ShipOn { get; set; }
        public bool IsShipOn { get; set; }
        public bool FieldIsShut { get; set; }
        public char FieldSymbol
        {
            get
            {
                if (FieldIsShut && IsShipOn) return 'X';
                if (!FieldIsShut && IsShipOn) return ShipOn.FieldSymbol;
                return FieldIsShut ? 'O' : '~';
            }
        }
    }
}
