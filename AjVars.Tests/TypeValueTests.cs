namespace AjVars.Tests
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TypeValueTests
    {
        [TestMethod]
        public void IntegerTypeValueParseStrings()
        {
            TypeValue type = IntegerTypeValue.Instance;

            Assert.AreEqual(1, type.ParseString("1"));
            Assert.AreEqual(1000, type.ParseString("1000"));
            Assert.AreEqual(-2000, type.ParseString("-2000"));
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void RaiseIfTryParseFloatAsInteger()
        {
            TypeValue type = IntegerTypeValue.Instance;
            type.ParseString("1.2");
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void RaiseIfTryParseTextAsInteger()
        {
            TypeValue type = IntegerTypeValue.Instance;
            type.ParseString("foo");
        }

        [TestMethod]
        public void ShortTypeValueParseStrings()
        {
            TypeValue type = ShortTypeValue.Instance;

            Assert.AreEqual((short) 1, type.ParseString("1"));
            Assert.AreEqual((short) 1000, type.ParseString("1000"));
            Assert.AreEqual((short) -2000, type.ParseString("-2000"));
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void RaiseIfTryParseFloatAsShort()
        {
            TypeValue type = ShortTypeValue.Instance;
            type.ParseString("1.2");
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void RaiseIfTryParseTextAsShort()
        {
            TypeValue type = ShortTypeValue.Instance;
            type.ParseString("foo");
        }

        [TestMethod]
        public void IntegerToAndFromBytes()
        {
            BytesTypeValue type = IntegerTypeValue.Instance;

            Assert.AreEqual(10, type.FromBytes(type.ToBytes(10)));
            Assert.AreEqual(-1, type.FromBytes(type.ToBytes(-1)));
            Assert.AreEqual(Int32.MaxValue, type.FromBytes(type.ToBytes(Int32.MaxValue)));
            Assert.AreEqual(Int32.MinValue, type.FromBytes(type.ToBytes(Int32.MinValue)));
        }

        [TestMethod]
        public void ShortToAndFromBytes()
        {
            BytesTypeValue type = ShortTypeValue.Instance;

            Assert.AreEqual((short)10, type.FromBytes(type.ToBytes((short)10)));
            Assert.AreEqual((short)-1, type.FromBytes(type.ToBytes((short)-1)));
            Assert.AreEqual(Int16.MaxValue, type.FromBytes(type.ToBytes(Int16.MaxValue)));
            Assert.AreEqual(Int16.MinValue, type.FromBytes(type.ToBytes(Int16.MinValue)));
        }

        [TestMethod]
        public void IntegerToAndFromMemory()
        {
            ByteMemory memory = new ByteMemory();
            TypeValue type = IntegerTypeValue.Instance;

            type.ToMemory(memory, 0, 10);
            Assert.AreEqual(10, type.FromMemory(memory, 0));
            type.ToMemory(memory, 10, -1);
            Assert.AreEqual(-1, type.FromMemory(memory, 10));
            type.ToMemory(memory, 20, Int32.MaxValue);
            Assert.AreEqual(Int32.MaxValue, type.FromMemory(memory, 20));
            type.ToMemory(memory, 30, Int32.MinValue);
            Assert.AreEqual(Int32.MinValue, type.FromMemory(memory, 30));
        }

        [TestMethod]
        public void ShortToAndFromMemory()
        {
            ByteMemory memory = new ByteMemory();
            TypeValue type = ShortTypeValue.Instance;

            type.ToMemory(memory, 0, (short) 10);
            Assert.AreEqual((short) 10, type.FromMemory(memory, 0));
            type.ToMemory(memory, 10, (short) -1);
            Assert.AreEqual((short) -1, type.FromMemory(memory, 10));
            type.ToMemory(memory, 20, Int16.MaxValue);
            Assert.AreEqual(Int16.MaxValue, type.FromMemory(memory, 20));
            type.ToMemory(memory, 30, Int16.MinValue);
            Assert.AreEqual(Int16.MinValue, type.FromMemory(memory, 30));
        }

        [TestMethod]
        public void ParseBitTypeValueFromBooleanString()
        {
            TypeValue type = BitTypeValue.Instance;

            Assert.AreEqual(false, type.ParseString("false"));
            Assert.AreEqual(true, type.ParseString("true"));

            Assert.AreEqual(false, type.ParseString("False"));
            Assert.AreEqual(true, type.ParseString("True"));

            Assert.AreEqual(false, type.ParseString("FALSE"));
            Assert.AreEqual(true, type.ParseString("TRUE"));
        }

        [TestMethod]
        public void ParseBitTypeValueFromZeroOneString()
        {
            TypeValue type = BitTypeValue.Instance;

            Assert.AreEqual(false, type.ParseString("0"));
            Assert.AreEqual(true, type.ParseString("1"));
        }

        [TestMethod]
        public void SetAndGetBitTypeValueUsingMemory()
        {
            ByteMemory memory = new ByteMemory();
            TypeValue type = BitTypeValue.Instance;

            type.ToMemory(memory, 10, true);
            Assert.IsTrue(memory.GetBit(10));
            Assert.IsFalse(memory.GetBit(9));
            Assert.IsFalse(memory.GetBit(11));
            Assert.AreEqual(true, type.FromMemory(memory, 10));
            Assert.AreEqual(false, type.FromMemory(memory, 9));
            Assert.AreEqual(false, type.FromMemory(memory, 11));
        }
    }
}
