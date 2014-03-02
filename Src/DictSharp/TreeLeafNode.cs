namespace DictSharp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    internal class TreeLeafNode<T>
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

            return default(T);
        }

        public void SetItem(string key, T value)
        {
            int position = this.GetPosition(key);

            if (position >= 0)
            {
                this.values[position] = value;
            }
            else
            {
                int newposition = -1 - position;

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
