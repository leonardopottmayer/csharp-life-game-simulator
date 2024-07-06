using System.Text;

namespace LifeGameSimulator
{
    public class EnvironmentUtils
    {
        public const int DEFAULT_ENVIRONMENT_SIZE = 25;
        public const int DEFAULT_AMOUNT_OF_ROUNDS = 1000;

        public EnvironmentUtils() { }

        /// <summary>
        /// Initializes the environment.
        /// </summary>
        /// <returns></returns>
        public int[,] GetInitialEnvironment()
        {
            return new int[DEFAULT_ENVIRONMENT_SIZE, DEFAULT_ENVIRONMENT_SIZE];
        }

        /// <summary>
        /// Prints the environment.
        /// </summary>
        /// <param name="environment"></param>
        public void PrintEnvironemnt(int[,] environment)
        {
            int rows = environment.GetLength(0);
            int cols = environment.GetLength(1);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("╔" + new string('═', cols * 2) + "╗");

            for (int i = 0; i < rows; i++)
            {
                sb.Append("║");
                for (int j = 0; j < cols; j++)
                {
                    sb.Append(environment[i, j] == 1 ? "X " : "  ");
                }
                sb.AppendLine("║");
            }

            sb.AppendLine("╚" + new string('═', cols * 2) + "╝");

            Console.WriteLine(sb.ToString());
        }

        /// <summary>
        /// Sets an alive cell.
        /// </summary>
        /// <param name="environment"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public int[,] SetAliveCell(int[,] environment)
        {
            var x = GetRandomNumber();
            var y = GetRandomNumber();

            environment[x, y] = 1;

            return environment;
        }

        /// <summary>
        /// Gets a random bool.
        /// </summary>
        /// <returns></returns>
        public bool GetRandomBool()
        {
            Random random = new Random();
            return random.Next(2) == 1;
        }

        /// <summary>
        /// Gets a random number.
        /// </summary>
        /// <returns></returns>
        public int GetRandomNumber()
        {
            Random random = new Random();
            return random.Next(DEFAULT_ENVIRONMENT_SIZE);
        }

        /// <summary>
        /// Counts the alive neighbors.
        /// </summary>
        /// <param name="environment"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int CountAliveNeighbors(int[,] environment, int x, int y)
        {
            int count = 0;
            int rows = environment.GetLength(0);
            int cols = environment.GetLength(1);

            for (int i = x - 1; i <= x + 1; i++)
            {
                for (int j = y - 1; j <= y + 1; j++)
                {
                    if (i >= 0 && i < rows && j >= 0 && j < cols && !(i == x && j == y))
                    {
                        count += environment[i, j];
                    }
                }
            }

            return count;
        }

        /// <summary>
        /// Starts the simulation.
        /// </summary>
        /// <param name="environment"></param>
        public void Start(int[,] environment)
        {
            for (int i = 0; i < DEFAULT_AMOUNT_OF_ROUNDS; i++)
            {
                //var shouldSetAliveCell = GetRandomBool();
                //if (shouldSetAliveCell)
                //{
                //    environment = SetAliveCell(environment);
                //}

                // Colocado aqui para testes
                environment = SetAliveCell(environment);

                PrintEnvironemnt(environment);

                for (int x = 0; x < environment.GetLength(0); x++)
                {
                    for (int y = 0; y < environment.GetLength(1); y++)
                    {
                        int aliveNeighbors = CountAliveNeighbors(environment, x, y);

                        if (environment[x, y] == 1)
                        {
                            if (aliveNeighbors == 0)
                            {
                                environment[x, y] = 0;
                            }
                            else if (aliveNeighbors > 3)
                            {
                                environment[x, y] = 0;
                            }
                        }
                        else
                        {
                            if (aliveNeighbors == 3)
                            {
                                environment[x, y] = 1;
                            }
                        }
                    }
                }

                PrintEnvironemnt(environment);
            }
        }
    }
}
