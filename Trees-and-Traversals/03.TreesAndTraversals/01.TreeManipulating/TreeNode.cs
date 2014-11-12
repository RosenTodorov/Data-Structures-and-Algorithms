namespace TreeManipulating
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TreeNode<T>
    {
        private List<TreeNode<T>> children;
        private T value;
        private TreeNode<T> parent;

        public TreeNode(T value)
        {
            this.Value = value;
            this.children = new List<TreeNode<T>>();
        }

        public TreeNode(T value, TreeNode<T> parent)
            : this(value)
        {
            this.Parent = parent;
            this.Parent.AddChild(this);
        }

        public T Value
        {
            get
            {
                return this.value;
            }

            private set
            {
                this.value = value;
            }
        }

        public bool HasParent
        {
            get
            {
                if (this.parent != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public TreeNode<T> Parent
        {
            get
            {
                return this.parent;
            }

            private set
            {
                this.parent = value;
            }
        }

        public List<TreeNode<T>> Children
        {
            get
            {
                return this.children;
            }
        }

        public void AddChild(TreeNode<T> newNode)
        {
            this.children.Add(newNode);
        }

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}