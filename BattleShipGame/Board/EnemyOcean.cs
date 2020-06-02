namespace ConsoleApp7.Board
{
    public class EnemyOcean: Ocean
    {
        public EnemyOcean(int initX, int initY) : base(initX, initY)
        {   
            this.initX = initX;
            this.initY = initY;
            board = initNewBoard(this.initX, this.initY);
        }
    }
}