using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;

namespace Tests
{
    [TestClass]
    public class LinkedList_Tests
    {
        [TestMethod]
        public void MyLinkedList_test1()
        {

            var lst = new ClrViaDotNet.MyLinkedList
            {
                0, DateTime.Now, 1, "Try", 1, 2, 1, 5, 4
            };

            Debug.WriteLine(lst);

            Assert.IsTrue(lst.Remove(0));

            Assert.IsTrue(lst.Size == 8);

            Assert.IsTrue(lst.Remove(1));

            lst.RemoveAll(1);

            Assert.IsTrue(lst.Size == 5);

            lst.RemoveHead();

            Assert.IsTrue(lst.Size == 4);

            Assert.AreEqual(Convert.ToInt32(lst[1]), 2);

            Assert.AreEqual(lst.HeadData.ToString(), "Try");

            Assert.AreEqual(Convert.ToInt32(lst.TailData), 4);

            Debug.WriteLine(lst);

            lst.Reverse();
            Debug.WriteLine(lst);

            Assert.AreEqual(Convert.ToInt32(lst.HeadData), 4);
            Assert.AreEqual(lst.TailData.ToString(), "Try");


        }
    }
}
