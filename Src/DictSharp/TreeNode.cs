namespace DictSharp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    internal class TreeNode<T> : TreeLeafNode<T>
    {
        private ITreeNode<T>[] children;

        public TreeNode(int size, ITreeNode<T> left, ITreeNode<T> right)
            : base(size)
        {
            this.children = new TreeLeafNode<T>[size + 1];

            this.children[0] = left;
            this.children[1] = right;
        }

        protected override T NotFound(string key, int position)
        {
            return this.children[position].GetItem(key);
        }
    }
}
