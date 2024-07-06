namespace LifeGameSimulator
{
    public class Program
    {
        static void Main(string[] args)
        {
            var environmentUtils = new EnvironmentUtils();

            int[,] environment = environmentUtils.GetInitialEnvironment();

            environmentUtils.SetAliveCell(environment);
            environmentUtils.PrintEnvironemnt(environment);
            environmentUtils.Start(environment);
        }
    }
}
