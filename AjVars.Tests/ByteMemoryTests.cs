namespace AjVars.Tests
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ByteMemoryTests
    {
        [TestMethod]
        public void GetFirstBytesFromMemory()
        {
            ByteMemory bytememory = new ByteMemory();
            byte[] bytes = bytememory.GetBytes(0, 10);

            Assert.IsNotNull(bytes);
            Assert.AreEqual(10, bytes.Length);
            Assert.IsTrue(bytes.All(b => b == 0));
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void RaiseWhenAddressIsBeyondLimits()
        {
            ByteMemory bytememory = new ByteMemory();
            bytememory.GetBytes(200, 10);
        }

        [TestMethod]
        public void GetLastBytesFromBigMemory()
        {
            ByteMemory bytememory = new ByteMemory(1000);
            byte[] bytes = bytememory.GetBytes(900, 100);

            Assert.IsNotNull(bytes);
            Assert.AreEqual(100, bytes.Length);
            Assert.IsTrue(bytes.All(b => b == 0));
        }
    }
}
