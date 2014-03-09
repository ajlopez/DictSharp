namespace DictSharp.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
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
        public void SetAndGetTwoItems()
        {
            Dictionary<int> dictionary = new Dictionary<int>();

            dictionary.SetItem("alpha", 1);
            dictionary.SetItem("beta", 2);
            Assert.AreEqual(1, dictionary.GetItem("alpha"));
            Assert.AreEqual(2, dictionary.GetItem("beta"));
        }

        [TestMethod]
        public void SetInInverseOrderAndGetTwoItems()
        {
            Dictionary<int> dictionary = new Dictionary<int>();

            dictionary.SetItem("beta", 2);
            dictionary.SetItem("alpha", 1);
            Assert.AreEqual(1, dictionary.GetItem("alpha"));
            Assert.AreEqual(2, dictionary.GetItem("beta"));
        }

        [TestMethod]
        public void SetResetAndGetItem()
        {
            Dictionary<int> dictionary = new Dictionary<int>();

            dictionary.SetItem("one", 1);
            dictionary.SetItem("one", 2);
            Assert.AreEqual(2, dictionary.GetItem("one"));
        }

        [TestMethod]
        public void SetItemAndGetUnknownItem()
        {
            Dictionary<int> dictionary = new Dictionary<int>();

            dictionary.SetItem("one", 1);
            Assert.AreEqual(0, dictionary.GetItem("two"));
        }

        [TestMethod]
        public void SetAndGetTenItems()
        {
            Dictionary<int> dictionary = new Dictionary<int>();

            for (var k = 1; k <= 10; k++)
                dictionary.SetItem(string.Format("key{0:00}", k), k);

            for (var k = 1; k <= 10; k++)
                Assert.AreEqual(k, dictionary.GetItem(string.Format("key{0:00}", k)));
        }

        [TestMethod]
        public void SetInInverseOrderAndGetTenItems()
        {
            Dictionary<int> dictionary = new Dictionary<int>();

            for (var k = 10; k >= 1; k--)
                dictionary.SetItem(string.Format("key{0:00}", k), k);

            for (var k = 1; k <= 10; k++)
                Assert.AreEqual(k, dictionary.GetItem(string.Format("key{0:00}", k)));
        }

        [TestMethod]
        public void SetAndGetTwentyItems()
        {
            Dictionary<int> dictionary = new Dictionary<int>();

            for (var k = 1; k <= 20; k++)
                dictionary.SetItem(string.Format("key{0:00}", k), k);

            for (var k = 1; k <= 20; k++)
                Assert.AreEqual(k, dictionary.GetItem(string.Format("key{0:00}", k)));
        }

        [TestMethod]
        public void SetInInverseOrderAndGetTwentyItems()
        {
            Dictionary<int> dictionary = new Dictionary<int>();

            for (var k = 20; k >= 1; k--)
                dictionary.SetItem(string.Format("key{0:00}", k), k);

            for (var k = 1; k <= 20; k++)
                Assert.AreEqual(k, dictionary.GetItem(string.Format("key{0:00}", k)));
        }

        [TestMethod]
        public void SetAndGetTwentyItemsWithSizeTen()
        {
            Dictionary<int> dictionary = new Dictionary<int>(10);

            for (var k = 1; k <= 20; k++)
                dictionary.SetItem(string.Format("key{0:00}", k), k);

            for (var k = 1; k <= 20; k++)
                Assert.AreEqual(k, dictionary.GetItem(string.Format("key{0:00}", k)));
        }

        [TestMethod]
        public void SetAndGetTwentyItemsWithSizeEight()
        {
            Dictionary<int> dictionary = new Dictionary<int>(8);

            for (var k = 1; k <= 20; k++)
                dictionary.SetItem(string.Format("key{0:00}", k), k);

            for (var k = 1; k <= 20; k++)
                Assert.AreEqual(k, dictionary.GetItem(string.Format("key{0:00}", k)));
        }

        [TestMethod]
        public void SetAndGetTwentyItemsWithSizeSix()
        {
            Dictionary<int> dictionary = new Dictionary<int>(6);

            for (var k = 1; k <= 20; k++)
                dictionary.SetItem(string.Format("key{0:00}", k), k);

            for (var k = 1; k <= 20; k++)
                Assert.AreEqual(k, dictionary.GetItem(string.Format("key{0:00}", k)));
        }

        [TestMethod]
        public void SetAndGetTwentyItemsWithSizeFive()
        {
            Dictionary<int> dictionary = new Dictionary<int>(5);

            for (var k = 1; k <= 20; k++)
                dictionary.SetItem(string.Format("key{0:00}", k), k);

            for (var k = 1; k <= 20; k++)
                Assert.AreEqual(k, dictionary.GetItem(string.Format("key{0:00}", k)));
        }
    }
}

