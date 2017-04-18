namespace exercises
{
    using System;

    public class IslandFinder
    {
        public static void Main(string[] args)
        {
            int[][] sea = new int[][] {
                new int[] {0,  1,  0,  1,  1},
                new int[] {0,  0,  1,  1,  0},
                new int[] {1,  0,  0,  0,  0},
                new int[] {0,  1,  1,  0,  1},
                new int[] {1,  0,  1,  0,  1}
            };

            var islandFinder = new IslandFinder();
            int biggestIslandSize = islandFinder.GetBiggestIslandSize(sea);

            Console.WriteLine($"Biggest island size is {biggestIslandSize}");
            Console.ReadKey();
        }

        private int GetBiggestIslandSize(int[][] sea)
        {
            bool[][] visited = new bool[sea.Length][];
            for (int i = 0; i < sea.Length; i++)
            {
                visited[i] = new bool[sea.Length];
                for (int j = 0; j < sea.Length; j++)
                {
                    visited[i][j] = false;
                }
            }
            return FindIslands(sea, visited);
        }

        private int FindIslands(int[][] sea, bool[][] visited)
        {
            int currentIslandSize = 0;
            int biggestIslandSize = 0;
            
            for (int i = 0; i < sea.Length; i++)
            {
                for (int j = 0; j < sea.Length; j++)
                {
                    if (visited[i][j])
                        continue;

                    if (sea[i][j] == 0)
                    {
                        visited[i][j] = true;
                        currentIslandSize = 0;
                        continue;
                    }

                    FloodFill(i, j, sea, visited, ref currentIslandSize, 0);

                    if (currentIslandSize > biggestIslandSize)
                        biggestIslandSize = currentIslandSize;
                }
            }
            return biggestIslandSize;
        }

        private void FloodFill(int row, int col, int[][] sea, bool[][] visited, ref int currentIslandSize, int currentLevel)
        {
            if (sea[row][col] == 0 || visited[row][col] || currentLevel == 3) return;
            visited[row][col] = true;
            currentIslandSize++;
            if (col < sea.Length - 1) FloodFill(row, col + 1, sea, visited, ref currentIslandSize, currentLevel + 1);
            if (row < sea.Length - 1) FloodFill(row + 1, col, sea, visited, ref currentIslandSize, currentLevel + 1);
            if (col > 0) FloodFill(row, col - 1, sea, visited, ref currentIslandSize, currentLevel + 1);
            if (row > 0) FloodFill(row - 1, col, sea, visited, ref currentIslandSize, currentLevel + 1);
        }
    }
}