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
            bool fieldIsShut = false;
            bool isShipOn = false;
            var fieldColor = ConsoleColor.Cyan; //TODO
        }
        public char fieldSymbol = ' ';
    }
}
