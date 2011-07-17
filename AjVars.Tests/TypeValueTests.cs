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
    }
}
