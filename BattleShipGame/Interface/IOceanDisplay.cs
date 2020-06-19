using ConsoleApp7.Board;

namespace ConsoleApp7.Interface
{
    public interface IOceanDisplay
    {
        void MyOcean(Ocean myOcean);
        
        void BothOceans(Ocean myOcean, Ocean enemyOcean);
    }
}