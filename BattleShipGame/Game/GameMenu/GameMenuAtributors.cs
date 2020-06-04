using System;
using ConsoleApp7.Board;
using static System.Console;
using static System.Text.StringBuilder;

namespace ConsoleApp7.Game
{
    public class GameMenuAtributors
    {
        public static void DisplayMenuOptions()
        {
            WriteLine($"\n[1] Start new console human vs human game\n" +
                      $"[2] Start new console human vs AI game\n" +
                      $"[3] Start new LAN human vs human game\n" +
                      $"[4] Show high scores\n"+
                      $"[5] Exit game\n");
        }

        public static int DisplayMenuChoice()
        {
            Write("Select one option above: ");
            string input = ReadLine();
            int selector = Convert.ToInt32(input);
            
                switch (selector)
                {
                    case 1:
                        // Ocean gameOcean = new Ocean(10, 10);
                        // gameOcean.DisplayBothOceans();
                        new Game();
                        
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
                    case 5:
                        Write("Are you sure you want to exit? [y/n]: ");
                        ConsoleKeyInfo keyPress = ReadKey();
                        if (keyPress.Key == ConsoleKey.Y)
                        {
                            Environment.Exit(0);
                        }
                        else
                        {
                            DisplayMenuOptions();
                            WriteLine("\nPlease select proper option!\n");
                        }
                        break;

                    default:
                        WriteLine("You have chosen worng value please try again!");
                        break;
                        
                }
                return selector;
        }
        
    }
}