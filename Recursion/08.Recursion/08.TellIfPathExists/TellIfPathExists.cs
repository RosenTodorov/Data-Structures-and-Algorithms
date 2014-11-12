/*Modify the above program to check whether a path exists
 * between two cells without finding all possible paths. 
 * Test it over an empty 100 x 100 matrix.
*/

namespace TellIfPathExists
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Diagnostics;

    class TellIfPathExists
    {
        static char[,] labyrinth = new char[100, 100];
        static List<Tuple<int, int>> paths = new List<Tuple<int, int>>();
        static bool pathExists = false;

        static void Main()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int starCol = 0;
            int starRow = 0;
            GetPathsInLabyrinth(starRow, starCol);
            if(!pathExists)
            {
                Console.WriteLine("No Path");
            }
            sw.Stop();
            Console.WriteLine(sw.Elapsed);
        }

        private static void GetPathsInLabyrinth(int row, int col)
        {
            if(pathExists)
            {
                return;
            }

            if (!ValidateData(row, col))
            {
                return;
            }

            if (row == labyrinth.GetLength(0) - 1 && col == labyrinth.GetLength(1) - 1)
            {
                pathExists = true;
                Console.WriteLine("Path exists!");
                return;
            }

            if (labyrinth[row, col] != '\0')
            {
                return;
            }

            labyrinth[row, col] = 'v';
            paths.Add(new Tuple<int, int>(row, col));
            GetPathsInLabyrinth(row + 1, col);
            GetPathsInLabyrinth(row - 1, col);
            GetPathsInLabyrinth(row, col + 1);
            GetPathsInLabyrinth(row, col - 1);
            labyrinth[row, col] = '\0';
            paths.RemoveAt(paths.Count - 1);
        }

        private static bool ValidateData(int row, int col)
        {
            if ((row < labyrinth.GetLength(0) && row >= 0) && (col >= 0 && col < labyrinth.GetLength(1)))
            {
                return true;
            }

            return false;
        }
    }
}