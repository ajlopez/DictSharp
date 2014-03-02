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
            for (int k = 0; k < this.nkeys; k++)
                if (this.keys[k] == key)
                    return this.values[k];

            return default(T);
        }

        public void SetItem(string key, T value)
        {
            this.values[this.nkeys] = value;
            this.keys[this.nkeys++] = key;
        }
    }
}
