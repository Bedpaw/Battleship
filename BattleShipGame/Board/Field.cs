using System;
using System.Collections.Generic;

namespace ConsoleApp7.Board
{
    public class Field
    {
        public Field(int x, int y)
        {
            int posX = x;
            int posY = y;

        }
        public char fieldSymbol = '~';
        public Ship shipOn;
        public bool isShipOn = false;
        public bool fieldIsShut = false;


        // public string ReturnSymbol()
        // {
        //     string returnSymbol = Char.ToString(fieldSymbol);
        //     return returnSymbol;
        // }
    }
}
