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
        private int nkeys;

        public TreeLeafNode(int size)
        {
            this.values = new T[size];
            this.keys = new string[size];
            this.nkeys = 0;
        }

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
                return InsertItem(key, value, -1 - position);
        }

        virtual protected T NotFound(string key, int position)
        {
            return default(T);
        }

        private ITreeNode<T> InsertItem(string key, T value, int newposition)
        {
            if (this.nkeys >= this.keys.Length)
            {
                ITreeNode<T> newnode = this.Split();
                newnode.SetItem(key, value);
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

        private ITreeNode<T> Split()
        {
            var newleaf = new TreeLeafNode<T>(this.keys.Length);
            int rightpos = this.keys.Length / 2 + 1;
            int rightlen = this.keys.Length - rightpos;

            for (int k = 0; k < rightlen; k++)
            {
                newleaf.values[k] = this.values[k + rightpos];
                newleaf.keys[k] = this.keys[k + rightpos];
            }

            newleaf.nkeys = rightlen;
            this.nkeys = rightpos - 1;

            var newnode = new TreeNode<T>(this.keys.Length, this, newleaf);
            newnode.values[0] = this.values[rightpos - 1];
            newnode.keys[0] = this.keys[rightpos - 1];
            newnode.nkeys = 1;

            return newnode;
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
