/*We are given a matrix of passable and non-passable cells.
 * Write a recursive program for finding all paths between two cells in the matrix.*/

namespace PathsInLabirynth
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Diagnostics;

    class PathsInLabirynth
    {
        private static char[,] labyrinth = new char[,]
       {
           {' ' , 'x' , ' ' , ' ' , ' ' , ' ' , ' '},
           {' ' , 'x' , 'x' , 'x' , ' ' , 'x' , ' '},
           {' ' , ' ' , 'x' , 'x' , ' ' , ' ' , ' '},
           {'x' , ' ' , ' ' , 'x' , ' ' , 'x' , ' '},
           {' ' , 'x' , ' ' , 'x' , ' ' , 'x' , ' '},
           {' ' , ' ' , ' ' , ' ' , ' ' , ' ' , ' '},
           {' ' , ' ' , ' ' , ' ' , 'x' , 'x' , 'e'}
       };

        static List<Tuple<int, int>> paths = new List<Tuple<int, int>>();
        static int totalPaths = 0;

        static void Main()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            int starCol = 0;
            int starRow = 0;
            GetPathsInLabyrinth(starRow, starCol);
            Console.WriteLine("Total paths: " + totalPaths);
            sw.Stop();
            Console.WriteLine(sw.Elapsed);
        }

        private static void GetPathsInLabyrinth(int row, int col)
        {
            if(!ValidateData(row, col))
            {
                return;
            }

            if(labyrinth[row, col] == 'e')
            {
                totalPaths++;
                Print(row, col);
                return;
            }

            if(labyrinth[row, col] != ' ')
            {
                return;
            }

            labyrinth[row, col] = 'v';
            paths.Add(new Tuple<int, int>(row, col));
            GetPathsInLabyrinth(row + 1, col);
            GetPathsInLabyrinth(row - 1, col);
            GetPathsInLabyrinth(row, col + 1);
            GetPathsInLabyrinth(row, col - 1);
            labyrinth[row, col] = ' ';
            paths.RemoveAt(paths.Count - 1);
        }

        private static void Print(int row, int col)
        {
            foreach (var cell in paths)
            {
                Console.Write("({0},{1}) -> ", cell.Item1, cell.Item2);
            }
            Console.WriteLine("({0},{1})", row, col);
            Console.WriteLine();
        }

        private static bool ValidateData(int row, int col)
        {
            if((row < labyrinth.GetLength(0) && row >= 0) && (col < labyrinth.GetLength(1) && col >= 0))
            {
                return true;
            }

            return false;
        }
    }
}


