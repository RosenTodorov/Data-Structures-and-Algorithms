/** We are given a labyrinth of size N x N. Some of its cells are empty (0) 
 * and some are full (x). We can move from an empty cell to another empty 
 * cell if they share common wall. Given a starting position (*) calculate
 * and fill in the array the minimal distance from this position to any other
 * cell in the array. Use "u" for all unreachable cells.*/

// TODO: needs optimization
namespace MinimalDistance
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        private static string[,] maze = new string[6, 6]
        {
            {"0", "0" , "0" , "x" , "0" , "x" },
            {"0" , "x" , "0" , "x" , "0" , "x" },
            {"0", "0", "x" , "0" , "x" , "0" },
            {"0" , "x" , "0" , "0" , "0" ,"0" },
            {"0", "0", "0" , "x" , "x" , "0" },
            {"0" , "0" , "0" , "x" , "0" , "x" }
        };

        private static string[,] output = CopyContent(maze);

        private static Stack<Position> path = new Stack<Position>();

        private static Position startPosition = new Position() { Row = 2, Col = 1, Value = 0 };

        public static void Main()
        {
            path.Push(startPosition);
            Solve(startPosition);
            output[startPosition.Row, startPosition.Col] = "*";
            PrintMatrix(output);
        }

        public static void Solve(Position startPos)
        {
            Position currentPosition = startPos;

            if (currentPosition.Col > 0 && maze[currentPosition.Row, currentPosition.Col - 1] != "x")
            {
                var next = new Position() { Row = currentPosition.Row, Col = currentPosition.Col - 1, Value = currentPosition.Value + 1 };
                if (!CheckForExistance(next, path))
                {
                    path.Push(next);
                    Solve(path.Peek());
                }
            }

            if (currentPosition.Col < maze.GetLength(1) - 1 && maze[currentPosition.Row, currentPosition.Col + 1] != "x")
            {
                var next = new Position() { Row = currentPosition.Row, Col = currentPosition.Col + 1, Value = currentPosition.Value + 1 };
                if (!CheckForExistance(next, path))
                {
                    path.Push(next);
                    Solve(path.Peek());
                }
            }

            if (currentPosition.Row > 0 && maze[currentPosition.Row - 1, currentPosition.Col] != "x")
            {
                var next = new Position() { Row = currentPosition.Row - 1, Col = currentPosition.Col, Value = currentPosition.Value + 1 };
                if (!CheckForExistance(next, path))
                {
                    path.Push(next);
                    Solve(path.Peek());
                }
            }

            if (currentPosition.Row < maze.GetLength(0) - 1 && maze[currentPosition.Row + 1, currentPosition.Col] != "x")
            {
                var next = new Position() { Row = currentPosition.Row + 1, Col = currentPosition.Col, Value = currentPosition.Value + 1 };
                if (!CheckForExistance(next, path))
                {
                    path.Push(next);
                    Solve(path.Peek());
                }
            }

            var printElement = path.Pop();
            output[printElement.Row, printElement.Col] = printElement.Value.ToString();
        }

        public static string[,] CopyContent(string[,] target)
        {
            var rows = target.GetLength(0);
            var cols = target.GetLength(1);
            string[,] result = new string[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    result[row, col] = target[row, col];
                }
            }

            return result;
        }

        public static bool CheckForExistance(Position current, Stack<Position> elements)
        {
            foreach (var el in elements)
            {
                if (current.CompareTo(el) == 0)
                {
                    return true;
                }
            }

            return false;
        }

        public static void PrintMatrix(string[,] target)
        {
            var rows = target.GetLength(0);
            var cols = target.GetLength(1);

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write("{0,3}", target[row, col]);
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }
    }
}