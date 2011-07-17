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
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void RaiseWhenAddressIsNegative()
        {
            ByteMemory bytememory = new ByteMemory();
            bytememory.GetBytes(-20, 10);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void RaiseWhenRangeIsCrossingBoundary()
        {
            ByteMemory bytememory = new ByteMemory();
            bytememory.GetBytes(90, 20);
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

        [TestMethod]
        public void SetAndGetOneByte()
        {
            ByteMemory bytememory = new ByteMemory();
            bytememory.SetBytes(10, new byte[] { (byte) 16 });

            byte[] result = bytememory.GetBytes(10, 1);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Length);
            Assert.AreEqual(16, result[0]);
        }

        [TestMethod]
        public void SetAndGetOneHundredBytes()
        {
            byte[] values = new byte[100];

            for (int k = 0; k < values.Length; k++)
                values[k] = (byte) k;

            ByteMemory bytememory = new ByteMemory(1000);
            bytememory.SetBytes(10, values);

            byte[] result = bytememory.GetBytes(10, values.Length);

            Assert.IsNotNull(result);
            Assert.AreEqual(100, result.Length);

            for (int k = 0; k < values.Length; k++)
                Assert.AreEqual(values[k], result[k]);
        }

        [TestMethod]
        public void ChangeValuesAndTriggerChangeMemoryEvent()
        {
            int count = 0;

            ByteMemory bytememory = new ByteMemory();

            bytememory.ChangedMemory += () => count++;

            bytememory.NewValues(10, new byte[] { 1, 2, 3 });

            Assert.AreEqual(1, count);
        }

        [TestMethod]
        public void SameValuesDontTriggerChangeMemoryEvent()
        {
            int count = 0;

            ByteMemory bytememory = new ByteMemory();

            bytememory.ChangedMemory += () => count++;

            bytememory.NewValues(10, new byte[] { 0, 0, 0 });

            Assert.AreEqual(0, count);
        }

        [TestMethod]
        public void SetBitsToOne()
        {
            ByteMemory memory = new ByteMemory();

            memory.SetBit(0, true);
            Assert.AreEqual(0x01, memory.GetBytes(0, 1)[0]);
            memory.SetBit(1, true);
            Assert.AreEqual(0x03, memory.GetBytes(0, 1)[0]);
            memory.SetBit(7, true);
            Assert.AreEqual(0x83, memory.GetBytes(0, 1)[0]);
            memory.SetBit(8, true);
            Assert.AreEqual(0x01, memory.GetBytes(1, 1)[0]);
            memory.SetBit(9, true);
            Assert.AreEqual(0x03, memory.GetBytes(1, 1)[0]);
        }

        [TestMethod]
        public void SetBitsToZero()
        {
            ByteMemory memory = new ByteMemory();

            memory.SetBytes(0, new byte[] { 0xff, 0xff });

            memory.SetBit(0, false);
            Assert.AreEqual(0xfe, memory.GetBytes(0, 1)[0]);
            memory.SetBit(1, false);
            Assert.AreEqual(0xfc, memory.GetBytes(0, 1)[0]);
            memory.SetBit(7, false);
            Assert.AreEqual(0x7c, memory.GetBytes(0, 1)[0]);
            memory.SetBit(8, false);
            Assert.AreEqual(0xfe, memory.GetBytes(1, 1)[0]);
            memory.SetBit(9, false);
            Assert.AreEqual(0xfc, memory.GetBytes(1, 1)[0]);
        }

        [TestMethod]
        public void GetBits()
        {
            ByteMemory memory = new ByteMemory();

            memory.SetBytes(0, new byte[] { 0xff, 0xff });

            for (int k = 0; k < 16; k++)
                Assert.IsTrue(memory.GetBit(k));

            for (int k = 16; k < 32; k++)
                Assert.IsFalse(memory.GetBit(k));
        }
    }
}
