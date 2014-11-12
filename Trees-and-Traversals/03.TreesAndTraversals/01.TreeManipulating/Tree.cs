namespace TreeManipulating
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Tree<T>
    {
        private List<TreeNode<T>> elements;
        private int count;

        public Tree()
        {
            this.elements = new List<TreeNode<T>>();
            this.count = 0;
        }

        public List<TreeNode<T>> Elements
        {
            get
            {
                return this.elements;
            }
        }

        public int Count
        {
            get
            {
                return this.count;
            }

            private set
            {
                this.count = value;
            }
        }

        public void AddNode(TreeNode<T> node)
        {
            this.elements.Add(node);
            this.Count++;
        }

        public TreeNode<T> DetermineRoot()
        {
            foreach (var child in this.Elements)
            {
                if (!child.HasParent)
                {
                    return child;
                }
            }

            return null;
        }

        public List<TreeNode<T>> GetLeafes()
        {
            var res = new List<TreeNode<T>>();

            foreach (var child in this.Elements)
            {
                if (child.Children.Count == 0)
                {
                    res.Add(child);
                }
            }

            return res;
        }

        public List<TreeNode<T>> GetMiddleNodes()
        {
            var res = new List<TreeNode<T>>();

            foreach (var child in this.Elements)
            {
                if (child.Children.Count > 0 && child.HasParent)
                {
                    res.Add(child);
                }
            }

            return res;
        }
    }
}