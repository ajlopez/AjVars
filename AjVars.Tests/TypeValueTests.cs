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
            TypeValue type = new IntegerTypeValue();

            Assert.AreEqual(1, type.ParseString("1"));
            Assert.AreEqual(1000, type.ParseString("1000"));
            Assert.AreEqual(-2000, type.ParseString("-2000"));
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void RaiseIfTryParseFloatAsInteger()
        {
            TypeValue type = new IntegerTypeValue();
            type.ParseString("1.2");
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void RaiseIfTryParseTextAsInteger()
        {
            TypeValue type = new IntegerTypeValue();
            type.ParseString("foo");
        }

        [TestMethod]
        public void ShortTypeValueParseStrings()
        {
            TypeValue type = new ShortTypeValue();

            Assert.AreEqual((short) 1, type.ParseString("1"));
            Assert.AreEqual((short) 1000, type.ParseString("1000"));
            Assert.AreEqual((short) -2000, type.ParseString("-2000"));
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void RaiseIfTryParseFloatAsShort()
        {
            TypeValue type = new ShortTypeValue();
            type.ParseString("1.2");
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void RaiseIfTryParseTextAsShort()
        {
            TypeValue type = new ShortTypeValue();
            type.ParseString("foo");
        }
    }
}
