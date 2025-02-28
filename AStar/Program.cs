namespace AStar
{
    internal class Program
    {
        private static void FindPath()
        {
            int[,] level = new int[100, 100];
            level[0, 0] = 1;
            Random rnd = new Random();
            int[] target = { rnd.Next(2, level.GetLength(0)), rnd.Next(2, level.GetLength(1)) };
            level[target[0],target[1]]=1;

            for (int i = 0; i < level.GetLength(0); i++)
            {
                for (int j = 0; j < level.GetLength(1); j++)
                {
                    if (level[i,j]==1)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.BackgroundColor = ConsoleColor.Blue;
                    }
                    else if (level[i, j] == 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.BackgroundColor= ConsoleColor.Red;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.White;
                    }
                    Console.Write(level[i, j]);
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine();
            List<int[]> open = new List<int[]>();
            open.Add(new int[] { 0, 0 });
            int[,,] nodes = new int[level.GetLength(0), level.GetLength(1),6];
            for (int i = 0;i < level.GetLength(0);i++)
            {
                for(int j = 0;j < level.GetLength(1);j++)
                {
                    nodes[i,j,0] = level[i,j];
                }
            }
            while (open.Count > 0)
            {
                open = open.OrderBy(x => nodes[x[0], x[1],3]).ThenBy(x => nodes[x[0], x[1], 5]).ToList();
                int[] curent = open[0];
                open.RemoveAt(0);
                if (nodes[curent[0], curent[1], 0] == 0) nodes[curent[0], curent[1], 0] = -1;
                int i;
                int j = curent[1];
                for (i = curent[0] - 1; i <= curent[0] + 1; i += 2)
                {

                    if (i >= 0 && j >= 0 && i < level.GetLength(0) && j < level.GetLength(1) && (nodes[i, j, 0] == 0 || nodes[i, j, 0] == 1))
                    {
                        int g = 10 + nodes[curent[0], curent[1], 4];
                        int h = (int)(Math.Sqrt((i - target[0]) * (i - target[0]) + (j - target[1]) * (j - target[1])) * 10);
                        int f = g + h;
                        if (nodes[i, j, 3] == 0 || nodes[i, j, 3] > f)
                        {
                            nodes[i, j, 5] = h;
                            nodes[i, j, 4] = g;
                            nodes[i, j, 3] = f;
                            nodes[i, j, 2] = curent[1];
                            nodes[i, j, 1] = curent[0];
                            open.Add(new int[] { i, j });
                        }
                        if (i == target[0] && j == target[1]) break;
                    }

                }
                i = curent[0];
                for (j = curent[1] - 1; j <= curent[1] + 1; j += 2)
                {

                    if (i >= 0 && j >= 0 && i < level.GetLength(0) && j < level.GetLength(1) && (nodes[i, j, 0] == 0 || nodes[i, j, 0] == 1))
                    {
                        int g = 10 + nodes[curent[0], curent[1], 4];
                        int h = (int)(Math.Sqrt((i - target[0]) * (i - target[0]) + (j - target[1]) * (j - target[1])) * 10);
                        int f = g + h;
                        if (nodes[i, j, 3] == 0 || nodes[i, j, 3] > f)
                        {
                            nodes[i, j, 5] = h;
                            nodes[i, j, 4] = g;
                            nodes[i, j, 3] = f;
                            nodes[i, j, 2] = curent[1];
                            nodes[i, j, 1] = curent[0];
                            open.Add(new int[] { i, j });
                        }
                        if (i == target[0] && j == target[1]) break;
                    }

                }
            }
            int[] start = target;
            while (start[0]!=0 || start[1]!=0)
            {
                start = new int[]{ nodes[start[0], start[1],1],nodes[start[0], start[1], 2]};
                if(level[start[0], start[1]]==0) level[start[0], start[1]] = 2;
            }
            for (int i = 0; i < level.GetLength(0); i++)
            {
                for (int j = 0; j < level.GetLength(1); j++)
                {
                    if (level[i, j] == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.BackgroundColor = ConsoleColor.Blue;
                    }
                    else if (level[i, j] == 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.BackgroundColor = ConsoleColor.Red;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.White;
                    }
                    Console.Write(level[i, j]);
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }
        static void Main(string[] args)
        {
            FindPath();
        }
    }
}