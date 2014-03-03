namespace DictSharp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    internal class TreeLeafNode<T> : ITreeNode<T>
    {
        private T[] values;
        private string[] keys;
        private short size;
        private TreeNode<T> parent;
        private short nkeys;

        public TreeLeafNode(short size)
        {
            this.values = new T[size];
            this.keys = new string[size];
            this.nkeys = 0;
            this.size = size;
        }

        public short NoKeys { get { return this.nkeys; } }

        public T GetItem(string key)
        {
            int position = this.GetPosition(key);

            if (position >= 0)
                return this.values[position];

            return this.NotFound(key, -1 - position);
        }

        public ITreeNode<T> SetItem(string key, T value)
        {
            int position = this.GetPosition(key);

            if (position >= 0)
            {
                this.values[position] = value;
                return null;
            }
            else
                return this.InsertItem(key, value, -1 - position);
        }

        protected virtual T NotFound(string key, int position)
        {
            return default(T);
        }

        protected virtual ITreeNode<T> InsertItem(string key, T value, int newposition)
        {
            if (this.nkeys >= this.keys.Length)
            {
                ITreeNode<T> newnode = this.Split();
                this.GetTopNode().SetItem(key, value);
                return newnode;
            }

            if (newposition >= this.nkeys)
            {
                this.values[this.nkeys] = value;
                this.keys[this.nkeys++] = key;
            }
            else
            {
                for (int k = this.nkeys; k > newposition; k--)
                {
                    this.values[k] = this.values[k - 1];
                    this.keys[k] = this.keys[k - 1];
                }

                this.values[newposition] = value;
                this.keys[newposition] = key;
                this.nkeys++;
            }

            return null;
        }

        private ITreeNode<T> GetTopNode()
        {
            if (this.parent == null)
                return this;

            return this.parent.GetTopNode();
        }

        private ITreeNode<T> Split()
        {
            var newleaf = new TreeLeafNode<T>(this.size);
            short rightpos = (short)((this.size / 2) + 1);
            short rightlen = (short)(this.size - rightpos);

            Array.Copy(this.values, rightpos, newleaf.values, 0, rightlen);
            Array.Copy(this.keys, rightpos, newleaf.keys, 0, rightlen);

            newleaf.nkeys = rightlen;
            this.nkeys = (short)(rightpos - 1);

            string pivotkey = this.keys[this.nkeys];
            T pivotvalue = this.values[this.nkeys];

            for (int k = this.nkeys; k < this.size; k++)
            {
                this.keys[k] = null;
                this.values[k] = default(T);
            }

            if (this.parent != null)
            {
                int childposition = this.parent.GetChildPosition(this);
                var newnode = this.parent.InsertItem(pivotkey, pivotvalue, childposition, newleaf);

                return newnode;
            }
            else
            {
                var newnode = new TreeNode<T>(this.size, this, newleaf);
                newnode.values[0] = pivotvalue;
                newnode.keys[0] = pivotkey;
                newnode.nkeys = 1;
                this.parent = newnode;
                newleaf.parent = newnode;

                return newnode;
            }
        }

        private int GetPosition(string key)
        {
            int k;

            for (k = 0; k < this.nkeys; k++)
            {
                int compare = this.keys[k].CompareTo(key);

                if (compare < 0)
                    continue;

                if (compare == 0)
                    return k;

                break;
            }

            return -k - 1;
        }
    }
}
