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
            Variable variable = new IntegerVariable(0, new ByteMemory());
            Assert.AreEqual(0, variable.Value);
        }

        [TestMethod]
        public void CreateIntegerVariableSetAndGetValue()
        {
            Variable variable = new IntegerVariable(10, new ByteMemory());
            variable.Value = 1;
            Assert.AreEqual(1, variable.Value);
        }

        [TestMethod]
        public void SetIntegerVariableWithStringValue()
        {
            Variable variable = new IntegerVariable(20, new ByteMemory());
            variable.Value = "1";
            Assert.AreEqual(1, variable.Value);
        }

        [TestMethod]
        public void SetIntegerVariableWithMinMaxValues()
        {
            Variable variable = new IntegerVariable(20, new ByteMemory());
            variable.Value = Int32.MaxValue;
            Assert.AreEqual(Int32.MaxValue, variable.Value);
            variable.Value = Int32.MinValue;
            Assert.AreEqual(Int32.MinValue, variable.Value);
        }

        [TestMethod]
        public void CreateShortVariableAndGetValue()
        {
            Variable variable = new ShortVariable(0, new ByteMemory());
            Assert.AreEqual((short) 0, variable.Value);
        }

        [TestMethod]
        public void CreateShortVariableSetAndGetValue()
        {
            Variable variable = new ShortVariable(10, new ByteMemory());
            variable.Value = (short) 1;
            Assert.AreEqual((short) 1, variable.Value);
        }

        [TestMethod]
        public void SetShortVariableWithStringValue()
        {
            Variable variable = new ShortVariable(20, new ByteMemory());
            variable.Value = "1";
            Assert.AreEqual((short) 1, variable.Value);
        }

        [TestMethod]
        public void SetShortVariableWithMinMaxValues()
        {
            Variable variable = new ShortVariable(20, new ByteMemory());
            variable.Value = Int16.MaxValue;
            Assert.AreEqual(Int16.MaxValue, variable.Value);
            variable.Value = Int16.MinValue;
            Assert.AreEqual(Int16.MinValue, variable.Value);
        }

        [TestMethod]
        public void RaiseNewValueEvent()
        {
            int count = 0;

            Variable variable = new IntegerVariable(0, new ByteMemory());
            variable.NewValue += (oldvalue, newvalue) => { count++; };

            variable.Value = 1;

            Assert.AreEqual(1, count);
        }

        [TestMethod]
        public void RaiseNewValueEvents()
        {
            int count = 0;

            Variable variable = new IntegerVariable(0, new ByteMemory());
            variable.NewValue += (oldvalue, newvalue) => { count++; };

            variable.Value = 1;
            variable.Value = 2;
            variable.Value = 2; // no event raised

            Assert.AreEqual(2, count);
        }

        [TestMethod]
        public void RaiseNewValueEventsWithExtremeValues()
        {
            int count = 0;

            Variable variable = new IntegerVariable(0, new ByteMemory());
            variable.NewValue += (oldvalue, newvalue) => { count++; };

            variable.Value = 0; // no event raised
            variable.Value = Int32.MaxValue;
            variable.Value = Int32.MinValue;

            Assert.AreEqual(2, count);
        }
    }
}
