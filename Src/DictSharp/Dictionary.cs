namespace DictSharp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Dictionary<T>
    {
        private ITreeNode<T> root = new TreeLeafNode<T>(10);

        public void SetItem(string key, T value)
        {
            var newroot = this.root.SetItem(key, value);

            if (newroot != null)
                this.root = newroot;
        }

        public T GetItem(string key)
        {
            return this.root.GetItem(key);
        }
    }
}
