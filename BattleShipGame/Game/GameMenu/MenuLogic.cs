using System;
using System.Security;
using static System.Console;

namespace ConsoleApp7.Game
{
    public class MenuLogic
    {
        public static void DisplayMainMenu()
        {
            int x;
            GameMenuAtributors.DisplayMenuOptions();
            do
            {
                x = GameMenuAtributors.DisplayMenuChoice();
            } while (x < 1 || x > 4);
        }

    }
}