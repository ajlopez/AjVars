namespace AjVars.Tests
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class VariableTests
    {
        [TestMethod]
        public void CreateIntegerVariableAndGetValue()
        {
            Variable variable = new IntegerVariable();
            Assert.AreEqual(0, variable.Value);
        }

        [TestMethod]
        public void CreateIntegerVariableSetAndGetValue()
        {
            Variable variable = new IntegerVariable();
            variable.Value = 1;
            Assert.AreEqual(1, variable.Value);
        }

        [TestMethod]
        public void SetIntegerVariableWithStringValue()
        {
            Variable variable = new IntegerVariable();
            variable.Value = "1";
            Assert.AreEqual(1, variable.Value);
        }

        [TestMethod]
        public void CreateShortVariableAndGetValue()
        {
            Variable variable = new ShortVariable();
            Assert.AreEqual((short) 0, variable.Value);
        }

        [TestMethod]
        public void CreateShortVariableSetAndGetValue()
        {
            Variable variable = new ShortVariable();
            variable.Value = (short) 1;
            Assert.AreEqual((short) 1, variable.Value);
        }

        [TestMethod]
        public void SetShortVariableWithStringValue()
        {
            Variable variable = new ShortVariable();
            variable.Value = "1";
            Assert.AreEqual((short) 1, variable.Value);
        }
    }
}
