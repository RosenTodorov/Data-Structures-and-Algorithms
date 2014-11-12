/*You are given a tree of N nodes represented as a set of N-1 pairs of nodes
 * (parent node, child node), each in the range (0..N-1).
     Write a program to read the tree and find:
     a) the root node
     b) all leaf nodes
     c) all middle nodes
 *   d) the longest path in the tree
*    e) all paths in the tree with given sum S of their nodes
*    f) all subtrees with given sum S of their nodes
*/

namespace TreeManipulating
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TreeManipulating
    {
        public static void Main()
        {
            Tree<int> tree = new Tree<int>();
            TreeNode<int> one = new TreeNode<int>(3);
            TreeNode<int> two = new TreeNode<int>(5, one);
            TreeNode<int> three = new TreeNode<int>(2, one);
            TreeNode<int> four = new TreeNode<int>(0, two);
            TreeNode<int> five = new TreeNode<int>(1, two);
            TreeNode<int> six = new TreeNode<int>(6, two);
            TreeNode<int> seven = new TreeNode<int>(4, three);
            tree.AddNode(one);
            tree.AddNode(two);
            tree.AddNode(three);
            tree.AddNode(four);
            tree.AddNode(five);
            tree.AddNode(six);
            tree.AddNode(seven);

            var treeRoot = tree.DetermineRoot(); // a)
            Console.WriteLine(treeRoot);

            var treeLeafes = tree.GetLeafes(); // b)
            Console.WriteLine(string.Join(",", treeLeafes));

            var treeMiddles = tree.GetMiddleNodes(); // c)
            Console.WriteLine(string.Join(",", treeMiddles));

            Console.WriteLine(DetermineLongestPath(one)); // d)

            FindPathsWithSumS(9, one); // e)*
        }

        public static int DetermineLongestPath(TreeNode<int> node)
        {
            if (node.Children.Count == 0)
            {
                return 0;
            }

            int max = 1;

            foreach (var child in node.Children)
            {
                max = Math.Max(max, DetermineLongestPath(child));
            }

            return max + 1;
        }

        public static void FindPathsWithSumS(int sum, TreeNode<int> start)
        {
            var stack = new Stack<TreeNode<int>>();
            var res = new List<List<int>>();
            int currentSum = 0;

            GetAllCombinationsWithSumS(start, stack, currentSum, res, sum);

            foreach (var lis in res)
            {
                lis.Reverse();
                Console.WriteLine(string.Join(",", lis));
            }
        }

        private static void GetAllCombinationsWithSumS(TreeNode<int> start, Stack<TreeNode<int>> stack, int currentSum, List<List<int>> res, int sum)
        {
            stack.Push(start);
            currentSum += start.Value;

            if (start.Children.Count == 0)
            {
                if (currentSum == sum)
                {
                    var r = stack.Select(x => x.Value).ToList();
                    res.Add(r);
                }
                return;
            }

            foreach (var child in start.Children)
            {
                GetAllCombinationsWithSumS(child, stack, currentSum, res, sum);
                stack.Pop();
            }
        }
    }
}