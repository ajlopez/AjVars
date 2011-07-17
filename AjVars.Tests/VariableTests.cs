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
            Variable variable = Variable.MakeIntegerVariable(0, new ByteMemory());
            Assert.AreEqual(0, variable.Value);
        }

        [TestMethod]
        public void CreateIntegerVariableSetAndGetValue()
        {
            Variable variable = Variable.MakeIntegerVariable(10, new ByteMemory());
            variable.Value = 1;
            Assert.AreEqual(1, variable.Value);
        }

        [TestMethod]
        public void SetIntegerVariableWithStringValue()
        {
            Variable variable = Variable.MakeIntegerVariable(20, new ByteMemory());
            variable.Value = "1";
            Assert.AreEqual(1, variable.Value);
        }

        [TestMethod]
        public void SetIntegerVariableWithMinMaxValues()
        {
            Variable variable = Variable.MakeIntegerVariable(20, new ByteMemory());
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
        public void TriggerNewValueEvent()
        {
            int count = 0;

            Variable variable = Variable.MakeIntegerVariable(0, new ByteMemory());
            variable.NewValue += (oldvalue, newvalue) => { count++; };

            variable.Value = 1;

            Assert.AreEqual(1, count);
        }

        [TestMethod]
        public void TriggerNewValueEvents()
        {
            int count = 0;

            Variable variable = Variable.MakeIntegerVariable(0, new ByteMemory());
            variable.NewValue += (oldvalue, newvalue) => { count++; };

            variable.Value = 1;
            variable.Value = 2;
            variable.Value = 2; // no event raised

            Assert.AreEqual(2, count);
        }

        [TestMethod]
        public void TriggerNewValueEventsWithExtremeValues()
        {
            int count = 0;

            Variable variable = Variable.MakeIntegerVariable(0, new ByteMemory());
            variable.NewValue += (oldvalue, newvalue) => { count++; };

            variable.Value = 0; // no event raised
            variable.Value = Int32.MaxValue;
            variable.Value = Int32.MinValue;

            Assert.AreEqual(2, count);
        }

        [TestMethod]
        public void ChangeInMemoryTriggerVariableNewValue()
        {
            object oldvalue = -1;
            object newvalue = -1;

            ByteMemory memory = new ByteMemory();
            Variable variable = Variable.MakeIntegerVariable(0, memory);

            variable.NewValue += (oldv, newv) => { oldvalue = oldv; newvalue = newv; };

            memory.NewValues(0, new byte[] { 1, 2, 3, 4 });

            Assert.AreEqual(0, oldvalue);
            Assert.AreEqual(0x01020304, newvalue);
        }

        [TestMethod]
        public void ChangeInMemoryDontTriggerVariableNewValue()
        {
            object oldvalue = -1;
            object newvalue = -1;

            ByteMemory memory = new ByteMemory();
            Variable variable = Variable.MakeIntegerVariable(4, memory);

            variable.NewValue += (oldv, newv) => { oldvalue = oldv; newvalue = newv; };

            memory.NewValues(0, new byte[] { 1, 2, 3, 4 });

            Assert.AreEqual(-1, oldvalue);
            Assert.AreEqual(-1, newvalue);
        }

        [TestMethod]
        public void CreateSetAndGetBitVariable()
        {
            ByteMemory memory = new ByteMemory();
            Variable variable = Variable.MakeBitVariable(10, memory);

            Assert.AreEqual(false, variable.Value);
            variable.Value = true;
            Assert.AreEqual(true, variable.Value);
            Assert.IsTrue(memory.GetBit(10));
        }

        [TestMethod]
        public void BitVariableTriggerNewValueWhenNewValuesInMemory()
        {
            int count = 0;

            ByteMemory memory = new ByteMemory();
            Variable variable = Variable.MakeBitVariable(10, memory);

            variable.NewValue += (oldvalue, newvalue) => count++;

            memory.NewValues(1, new byte[] { 0xff });

            Assert.AreEqual(1, count);
        }

        [TestMethod]
        public void VariableChangesType()
        {
            ByteMemory memory = new ByteMemory();
            Variable variable = Variable.MakeIntegerVariable(0, memory);

            variable.Value = 0x01020304;

            variable.TypeValue = ShortTypeValue.Instance;

            Assert.AreEqual((short) 0x0102, variable.Value);
        }

        [TestMethod]
        public void VariableChangedTypeTriggerNewValue()
        {
            object oldvalue = -1;
            object newvalue = -1;

            ByteMemory memory = new ByteMemory();
            Variable variable = Variable.MakeIntegerVariable(0, memory);

            variable.Value = 0x01020304;

            variable.NewValue += (oldv, newv) => { oldvalue = oldv; newvalue = newv; };

            variable.TypeValue = ShortTypeValue.Instance;

            Assert.AreEqual(0x01020304, oldvalue);
            Assert.AreEqual((short)0x0102, newvalue);
        }
    }
}
