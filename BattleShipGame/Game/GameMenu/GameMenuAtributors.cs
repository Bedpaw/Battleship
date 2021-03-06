﻿using System;
using ConsoleApp7.Players;
using ConsoleApp7.View;
using static System.Console;

namespace ConsoleApp7.Game.GameMenu
{
    public static class GameMenuAtributors
    {
        public static void DisplayMenuOptions()
        {
            WriteLine("\n[1] Start new console human vs human game\n" +
                          "[2] Start new console human vs AI game\n" +
                          "[3] Watch AI vs AI game\n" +
                          "[4] Start new LAN human vs human game\n" +
                          "[5] Show high scores\n"+
                          "[6] Exit game\n");
        }

        public static int DisplayMenuChoice()
        {
            Write("Select one option above: ");
            var input = ReadLine();
            var selector = Convert.ToInt32(input);
            
                switch (selector)
                {
                    case 1:
                        var game = new GameEngine.Game
                        (
                            new ConsolePlayer(new ConsoleDisplay()),
                            new ConsolePlayer(new ConsoleDisplay())
                            );
                        game.GameLoop();
                        break;
                    case 2:
                        var gameWithComputer = new GameEngine.Game
                        (
                            new ConsolePlayer(new ConsoleDisplay()),
                            new PlayerAi(new ConsoleDisplayAI())
                        );
                        gameWithComputer.GameLoop();
                        break;
                    case 3:
                        var gameAIvsAi = new GameEngine.Game
                        (
                            new PlayerAi(new ConsoleDisplay()),
                            new PlayerAi(new ConsoleDisplay())
                        );
                        gameAIvsAi.GameLoop();
                        break;
                    case 4:
                        WriteLine("Not implemented yet");
                        break;
                    case 5:
                        Write("Are you sure you want to exit? [y/n]: ");
                        var keyPress = ReadKey();
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
                        WriteLine("You have chosen wrong value please try again!");
                        break;
                        
                }
                return selector;
        }
        
    }
}