namespace StudentsAndDetails
{
    using System;
    using System.Linq;

    public class Student
    {
        public string  FirstName { get; set; }
        public string LastName { get; set; }

        public Student(string fname, string lname)
        {
            this.FirstName = fname;
            this.LastName = lname;
        }
    }
}
