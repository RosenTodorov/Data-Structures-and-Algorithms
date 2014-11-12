/*Define classes File { string name, int size } and Folder { string name, File[] files, Folder[] childFolders }
 * and using them build a tree keeping all files and folders on the hard drive starting from C:\WINDOWS.
 * Implement a method that calculates the sum of the file sizes in given subtree of the tree and test it
 * accordingly. Use recursive DFS traversal.
*/

namespace FileTree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.IO;

    public class FileTree
    {
        private static DirectoryInfo initialDir = new DirectoryInfo(@"C:\Windows\ADFS");

        public static void Main()
        {
            var winDir = BuildFileTree(initialDir);
            Console.WriteLine("Tree building process is completed");
            Console.WriteLine(winDir.SubFolders[6].CalculateSize());
        }

        private static Folder BuildFileTree(DirectoryInfo initialD)
        {
            string name = initialD.Name;
            List<File> files = new List<File>();
            List<Folder> subs = new List<Folder>();

            try
            {
                var containedFiles = initialD.GetFiles();
                foreach (var file in containedFiles)
                {
                    files.Add(new File(file.Name, (int)file.Length));
                }

                var containedDirs = initialD.GetDirectories();
                foreach (var dir in containedDirs)
                {
                    subs.Add(BuildFileTree(dir));
                }
            }
            catch (UnauthorizedAccessException)
            {
            }
            catch (DirectoryNotFoundException)
            {
            }
            catch (System.Security.SecurityException)
            {
            }

            return new Folder(name, files, subs);
        }
    }
}