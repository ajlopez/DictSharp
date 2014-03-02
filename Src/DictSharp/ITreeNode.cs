namespace DictSharp
{
    using System;

    internal interface ITreeNode<T>
    {
        T GetItem(string key);

        ITreeNode<T> SetItem(string key, T value);
    }
}
