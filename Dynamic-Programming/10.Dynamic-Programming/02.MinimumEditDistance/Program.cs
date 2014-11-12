/*Write a program to calculate the "Minimum Edit Distance" (MED) between two words. MED(x, y)
 * is the minimal sum of costs of edit operations used to transform x to y. Sample costs are given below:
cost (replace a letter) = 1
cost (delete a letter) = 0.9
cost (insert a letter) = 0.8
*/


// implementation of ordinary MED
namespace MinimumEditDistance
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class MinimumEditDistance
    {
        static void Main()
        {

            Console.WriteLine(GetMinimumDistance("developer", "enveloped"));
        }
        static int GetMinimumDistance(string givenString, string targetString)
        {
            if (givenString == targetString)
                return 0;
            if (givenString.Length == 0)
                return targetString.Length;
            if (targetString.Length == 0)
                return givenString.Length;

            // create two work vectors of integer distances
            int[] v0 = new int[targetString.Length + 1];
            int[] v1 = new int[targetString.Length + 1];
            bool[] correctPlacement = new bool[targetString.Length];

            // initialize v0 (the previous row of distances)
            // this row is A[0][i]: edit distance for an empty s
            // the distance is just the number of characters to delete from t
            for (int i = 0; i < v0.Length; i++)
                v0[i] = i;

            for (int i = 0; i < givenString.Length; i++)
            {
                // calculate v1 (current row distances) from the previous row v0

                // first element of v1 is A[i+1][0]
                //   edit distance is delete (i+1) chars from s to match empty t
                v1[0] = i + 1;

                // use formula to fill in the rest of the row
                for (int j = 0; j < targetString.Length; j++)
                {
                    var cost = (givenString[i] == targetString[j]) ? 0 : 1;
                    if (givenString[j] == targetString[j])
                    {
                        correctPlacement[j] = true;
                    }
                    v1[j + 1] = Math.Min(v1[j] + 1, Math.Min(v0[j + 1] + 1, v0[j] + cost));
                }

                // copy v1 (current row) to v0 (previous row) for next iteration
                for (int j = 0; j < v0.Length; j++)
                    v0[j] = v1[j];
            }
            int changes = v1[targetString.Length];

            return changes;
        }
    }
}