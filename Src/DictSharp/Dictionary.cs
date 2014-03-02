namespace DictSharp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Dictionary<T>
    {
        private TreeLeafNode<T> node = new TreeLeafNode<T>(10);

        public void SetItem(string key, T value)
        {
            this.node.SetItem(key, value);
        }

        public T GetItem(string key)
        {
            return this.node.GetItem(key);
        }
    }
}
