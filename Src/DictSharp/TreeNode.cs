namespace DictSharp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    internal class TreeNode<T> : TreeLeafNode<T>
    {
        private ITreeNode<T>[] children;

        public TreeNode(short size, ITreeNode<T> left, ITreeNode<T> right)
            : base(size)
        {
            this.children = new TreeLeafNode<T>[size + 1];

            this.children[0] = left;
            this.children[1] = right;
        }

        public int GetChildPosition(ITreeNode<T> child)
        {
            for (int k = 0; k < this.NoKeys + 1; k++)
                if (this.children[k] == child)
                    return k;

            return -1;
        }

        public ITreeNode<T> InsertItem(string key, T value, int newposition, ITreeNode<T> newchild)
        {
            base.InsertItem(key, value, newposition);

            for (int k = this.NoKeys; k > newposition + 1; k--)
                this.children[k] = this.children[k - 1];

            this.children[newposition + 1] = newchild;

            return this;
        }

        protected override T NotFound(string key, int position)
        {
            return this.children[position].GetItem(key);
        }

        protected override ITreeNode<T> InsertItem(string key, T value, int newposition)
        {
            return this.children[newposition].SetItem(key, value);
        }
    }
}
