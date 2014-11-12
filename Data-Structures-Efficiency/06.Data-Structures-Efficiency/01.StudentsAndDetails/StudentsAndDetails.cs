/*A text file students.txt holds information about students and their 
 * courses in the following format (see the *.txt file).
	Using SortedDictionary<K,T> print the courses in alphabetical
 * order and for each of them prints the students ordered by family and then by name:
    C#: Ivan Grigorov, Kiril Ivanov, Milena Petrova
    Java: Stela Mineva
    SQL: Ivan Kolev, Stefka Nikolova
*/
namespace StudentsAndDetails
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.IO;
    using System.Text;

    class StudentsAndDetails
    {
        static void Main()
        {
            SortedDictionary<string, List<Student>> courseAttendants;
            courseAttendants = FillAttendants();

            foreach(var course in courseAttendants)
            {
                var output = new StringBuilder();
                var collection = course.Value.OrderBy(x => x.LastName).ThenBy(x => x.FirstName);
                output.AppendFormat("{0}: ", course.Key);
                foreach(var student in collection)
                {
                    output.AppendFormat("{0} {1}, ", student.FirstName, student.LastName);
                }
                output.Length -= 2;
                Console.WriteLine(output);
            }
        }

        private static SortedDictionary<string, List<Student>> FillAttendants()
        {
            SortedDictionary<string, List<Student>> result = new SortedDictionary<string, List<Student>>();
            using (var reader = new StreamReader("../../students.txt"))
            {
                string line = reader.ReadLine();
                while(line != null)
                {
                    var detail = line.Split(new char[] { ' ', '|' }, StringSplitOptions.RemoveEmptyEntries);

                    if(result.ContainsKey(detail[2]))
                    {
                        result[detail[2]].Add(new Student(detail[0],detail[1]));
                    }
                    else
                    {
                        result.Add(detail[2], new List<Student>());
                        result[detail[2]].Add(new Student(detail[0], detail[1]));
                    }
                    line = reader.ReadLine();
                }
            }

            return result;
        }
    }
}
         