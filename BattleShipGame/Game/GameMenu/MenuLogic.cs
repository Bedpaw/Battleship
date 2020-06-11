namespace ConsoleApp7.Game.GameMenu
{
    public static class MenuLogic
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