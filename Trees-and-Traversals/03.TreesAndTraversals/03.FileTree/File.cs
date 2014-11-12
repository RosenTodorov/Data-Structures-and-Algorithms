namespace FileTree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class File
    {
        private string name;
        private int size;

        public File(string name, int size)
        {
            this.name = name;
            this.size = size;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                this.name = value;
            }
        }

        public int Size
        {
            get
            {
                return this.size;
            }

            private set
            {
                this.size = value;
            }
        }
    }
}