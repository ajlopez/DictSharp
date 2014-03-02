namespace DictSharp.Tests
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DictionaryTests
    {
        [TestMethod]
        public void GetUnknowIntegerItem()
        {
            Dictionary<int> dictionary = new Dictionary<int>();

            Assert.AreEqual(0, dictionary.GetItem("foo"));
        }

        [TestMethod]
        public void GetUnknowStringItem()
        {
            Dictionary<string> dictionary = new Dictionary<string>();

            Assert.IsNull(dictionary.GetItem("foo"));
        }

        [TestMethod]
        public void SetAndGetItem()
        {
            Dictionary<int> dictionary = new Dictionary<int>();

            dictionary.SetItem("one", 1);
            Assert.AreEqual(1, dictionary.GetItem("one"));
        }

        [TestMethod]
        public void SetItemAndGetUnknownItem()
        {
            Dictionary<int> dictionary = new Dictionary<int>();

            dictionary.SetItem("one", 1);
            Assert.AreEqual(0, dictionary.GetItem("two"));
        }
    }
}

