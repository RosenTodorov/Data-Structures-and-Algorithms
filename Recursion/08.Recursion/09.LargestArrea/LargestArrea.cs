/*Write a recursive program to find the largest connected
 * area of adjacent empty cells in a matrix.*/

namespace LargestArrea
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class LargestArrea
    {
        private static char[,] labyrinth = new char[,]
        {
                {' ' , 'x' , ' ' , ' ' , ' ' , ' ' , ' '}, 
                {' ' , 'x' , 'x' , 'x' , ' ' , 'x' , ' '},
                {' ' , ' ' , 'x' , 'x' , ' ' , ' ' , ' '},
                {'x' , ' ' , ' ' , 'x' , ' ' , 'x' , ' '},
                {' ' , 'x' , ' ' , 'x' , ' ' , 'x' , ' '},
                {' ' , ' ' , ' ' , ' ' , ' ' , ' ' , ' '},
                {' ' , 'x' , ' ' , ' ' , 'x' , 'x' , ' '}
        };

        private static List<Tuple<int, int>> paths = new List<Tuple<int, int>>();
        private static int currentLength = 0;
        private static int maxLength = 0;

        static void Main()
        {
            for (int row = 0; row < labyrinth.GetLength(0); row++)
            {
                for (int col = 0; col < labyrinth.GetLength(1); col++)
                {
                    GetPathInLabyrinth(row, col);
                    if(currentLength > maxLength)
                    {
                        maxLength = currentLength;
                    }

                    currentLength = 0;
                }               
            }

            Console.WriteLine(maxLength);
        }

        private static void GetPathInLabyrinth(int row, int col)
        {
            if (!ValidateData(row, col))
            {
                return;
            }
            if (labyrinth[row, col] != ' ')
            {
                return;
            }

            labyrinth[row, col] = 'v';
            paths.Add(new Tuple<int, int>(row, col));
            currentLength++;
            GetPathInLabyrinth(row - 1, col);
            GetPathInLabyrinth(row + 1, col);
            GetPathInLabyrinth(row, col - 1);
            GetPathInLabyrinth(row, col + 1);
            paths.RemoveAt(paths.Count - 1);
        }

        private static bool ValidateData(int row, int col)
        {
            if ((row >= 0 && row < labyrinth.GetLength(0)) && (col >= 0 && col < labyrinth.GetLength(1)))
            {
                return true;
            }

            return false;
        }
    }
}