﻿using System;
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
            
        }
        public char fieldSymbol = '.';


        public void ReturnSymbolWithColor()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Write(fieldSymbol );
        }
    }
}
