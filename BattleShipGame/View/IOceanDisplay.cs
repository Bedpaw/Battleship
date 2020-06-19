using ConsoleApp7.Board;

namespace ConsoleApp7.View
{
    public interface IOceanDisplay
    {
        abstract void MyOcean(Ocean myOcean);
        
        abstract void BothOceans(Ocean myOcean, Ocean enemyOcean);
    }
}