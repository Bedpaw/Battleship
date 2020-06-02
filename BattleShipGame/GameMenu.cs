using System;
using static System.Console;

namespace ConsoleApp7
{
    public class GameMenu
    {
        public static void DisplayMenu()
        {
            WriteLine("[1] Start new console human vs human game");
            WriteLine("[2] Start new console human vs AI game");
            WriteLine("[3] Start new LAN human vs human game");
            WriteLine("[4] Show high scores");
            WriteLine("[5] Exit game");
        }

        public static Game.Game GetUserChoice()
        {
            var choice = Console.Read();
            switch (choice)
            {
                case 1:
                    WriteLine("111111");
                    break;
                case 2:
                    WriteLine("2222222");
                    break;
                case 3:
                    WriteLine("3333333");
                    break;

                case 4:
                    WriteLine("4444444");
                    break;

                default:
                    WriteLine("5555555");
                    break;
            }
            // return game with proper 
            return new Game.Game();
        }
    }
}