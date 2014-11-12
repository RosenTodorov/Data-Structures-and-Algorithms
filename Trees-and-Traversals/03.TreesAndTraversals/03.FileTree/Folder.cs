namespace FileTree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Numerics;

    public class Folder
    {
        private string name;
        private List<File> files;
        private List<Folder> subFolders;
        private BigInteger size;

        public Folder(string name, List<File> files, List<Folder> subFolders)
        {
            this.name = name;
            this.files = files;
            this.subFolders = subFolders;
        }

        public string Name
        {
            get { return this.name; }
            private set { this.name = value; }
        }

        public List<File> Files
        {
            get { return this.files; }
            private set { this.files = value; }
        }

        public List<Folder> SubFolders
        {
            get { return this.subFolders; }
            private set { this.subFolders = value; }
        }

        public BigInteger CalculateSize()
        {
            for (int i = 0; i < this.Files.Count; i++)
            {
                this.size += this.Files[i].Size;
            }

            for (int i = 0; i < this.SubFolders.Count; i++)
            {
                this.size += this.SubFolders[i].CalculateSize();
            }

            return size;
        }
    }
}