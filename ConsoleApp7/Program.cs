using System;
using ConsoleApp7;

namespace ConsoleApp7
{
    static class Program
    {
        static void Main(string[] args)
        {
            while (true)
            { 
                GameMenu.DisplayMenu();
                var game = GameMenu.GetUserChoice();
                game.GameLoop();
                game.DisplayEndGameMessage();
            }
        }
    }
}
