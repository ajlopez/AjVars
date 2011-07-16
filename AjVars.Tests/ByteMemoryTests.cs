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
    }
}
