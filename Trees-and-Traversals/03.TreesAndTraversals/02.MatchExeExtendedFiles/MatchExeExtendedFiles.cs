/*Write a program to traverse the directory C:\WINDOWS and all its subdirectories
 * recursively and to display all files matching the mask *.exe. Use the class
 * System.IO.Directory.
*/

namespace MatchExeExtendedFiles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;

    public class MatchExeExtendedFiles
    {
        public static void Main()
        {
            // may take some time to finish
            DirectoryInfo root = new DirectoryInfo(@"C:/Windows");
            Queue<DirectoryInfo> dirs = new Queue<DirectoryInfo>();
            int count = 0;
            var result = new StringBuilder();

            dirs.Enqueue(root);

            while (dirs.Count > 0)
            {
                try
                {
                    var active = dirs.Dequeue();
                    var files = active.EnumerateFiles();
                    var containDirs = active.EnumerateDirectories();

                    foreach (var file in files)
                    {
                        if (file.Extension == ".exe")
                        {
                            result.AppendLine(file.Name);
                            count++;
                        }
                    }

                    foreach (var cDir in containDirs)
                    {
                        dirs.Enqueue(cDir);
                    }
                }
                catch (UnauthorizedAccessException uae)
                {
                    Console.WriteLine(uae.Message);
                }
            }

            Console.WriteLine(result);
            Console.WriteLine("{0} exes", count);
        }
    }
}