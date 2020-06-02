using System;
using System.Collections;
using static System.Console;
using System.Collections.Generic;
using System.Text;


namespace ConsoleApp7.Board
{
    public class MyOcean: Ocean
    {
        // public new List<List<Field>> board;
        public MyOcean(int initX, int initY) : base(initX, initY)
        {   
            this.initX = initX;
            this.initY = initY;
            board = initNewBoard(this.initX, this.initY);
        }
    }
}